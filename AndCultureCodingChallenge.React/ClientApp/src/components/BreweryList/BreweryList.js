import React, { Component } from 'react';
import styles from './BreweryList.module.css';
import axios from 'axios';

const api = axios.create({
    //baseURL: 'https://api.openbrewerydb.org/breweries'
    baseURL: 'https://localhost:7009/api/Breweries'
});

export class BreweryList extends React.Component {

	constructor(props) {
        super(props);
        this.state = {
            heading: "This is a BreweryList Component!",
            breweries: []
        }

        api.get('').then(res => {
            this.setState({ breweries: res.data })
        });
    }

    render() {
        return (
            <div>
                <table>
                    <tr>
                        <td><b>Name</b></td>
                        <td><b>Type</b></td>
                        <td><b>Address</b></td>
                        <td><b>Website URL</b></td>
                        <td><b>Map details</b></td>
                    </tr>
                    {
                        this.state.breweries.map(brewery =>
                            <tr>
                                <td>{brewery.name}</td>
                                <td>{brewery.breweryType}</td>
                                <td>{brewery.street}, {brewery.city}, {brewery.state}, {brewery.postal_code}</td>
                                <td><a href={brewery.website_url}>{brewery.websiteUrl}</a></td>
                                <td><a href={'/brewery-details/' + brewery.obdbId}>Details</a></td>
                            </tr>
                        )
                    }
                </table>
            </div>
        );
    }
};