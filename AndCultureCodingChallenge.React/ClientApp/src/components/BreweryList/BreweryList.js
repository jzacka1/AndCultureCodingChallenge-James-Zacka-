import React, { Component, useEffect } from 'react';
import './BreweryList.css';
import axios from 'axios';
import ReactTable from "react-table";
import ReactPaginate from "react-paginate";
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faSpinner } from '@fortawesome/free-solid-svg-icons'

const api = axios.create({
    //baseURL: 'https://api.openbrewerydb.org/breweries'
    baseURL: 'https://localhost:7009/api/Breweries'
});

// Initiate paging values
const paging = {
    heading: "",
    list: [],
    perPage: 3,
    page: 0,
    pages: 40,
};

export class BreweryList extends Component {

	constructor(props) {
        super(props);
        this.state = {
            heading: "This is a BreweryList Component!",
            list: [],
            perPage: 20,
            page: 0,
            pages: 0,
            searchName: '',
            loading: true
        }
    }

    componentDidMount() {
        this.makeHttpRequest();
};

    makeHttpRequest = async () => {
        let res = await api.get('')
            .catch(err => console.log(err));

        const { perPage } = this.state;
        this.state.list = res.data;
        this.setState({
            pages: Math.floor(this.state.list.length / perPage),
            loading: false
        });
    };

    handlePageClick = (event) => {
        let page = event.selected;
        this.setState({ page })
    };

    handleSearch = (event) => {
        let searchName = event.target.value;
        this.setState({ searchName });
	}

    render() {
        const { page, perPage, pages, list, searchName, loading } = this.state;

        if (loading) {
            return (<FontAwesomeIcon icon={faSpinner} className="spinner text-center" color="#569bd3" size="5x"/>)
		}

        let items = [];

        if (searchName.length == 0) {
            items = this.state.list
                .slice(page * perPage, (page + 1) * perPage)
                .map(item => {
                    return (
                        <tr>
                            <td>{item.name}</td>
                            <td>{item.breweryType}</td>
                            <td>{item.street}, {item.city}, {item.state}, {item.postal_code}</td>
                            <td><a href={item.website_url}>{item.websiteUrl}</a></td>
                            <td><a href={'/brewery-details/' + item.obdbId}>Details</a></td>
                        </tr>
                    )
                }) || '';
        }
        else {
            items = this.state.list
                .filter((item) => 
                    item.name.toLowerCase().includes(searchName)
				)
                .slice(page * perPage, (page + 1) * perPage)
                .map(item => {
                    return (
                        <tr>
                            <td>{item.name}</td>
                            <td>{item.breweryType}</td>
                            <td>{item.street}, {item.city}, {item.state}, {item.postal_code}</td>
                            <td><a href={item.website_url}>{item.websiteUrl}</a></td>
                            <td><a href={'/brewery-details/' + item.obdbId}>Details</a></td>
                        </tr>
                    )
                }) || '';
		}

        return (
            <div>
                <label htmlFor="search">
                    Search by Name:
                    <input id="search" type="text" onChange={this.handleSearch} />
                </label>
                <ReactPaginate
                    previousLabel={'prev'}
                    nextLabel={'next'}
                    pageCount={this.state.pages}
                    onPageChange={this.handlePageClick}
                    containerClassName={'pagination'}
                    activeClassName={'active'}
                />
                <table>
                    <tr>
                        <td><b>Name</b></td>
                        <td><b>Type</b></td>
                        <td><b>Address</b></td>
                        <td><b>Website URL</b></td>
                        <td><b>Map details</b></td>
                    </tr>
                    {
                        items
                    }
                </table>
            </div>
        )
    }
};