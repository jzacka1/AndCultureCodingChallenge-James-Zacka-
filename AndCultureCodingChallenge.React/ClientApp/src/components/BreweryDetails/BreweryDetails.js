import React, { Component } from 'react';
import './BreweryDetails.css';
import axios from 'axios';
import { GoogleMaps } from '../GoogleMaps/GoogleMaps';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faLocationPin } from '@fortawesome/free-solid-svg-icons'

const api = axios.create({
    //baseURL: 'https://api.openbrewerydb.org/breweries'
    baseURL: 'https://localhost:7009/api/Breweries'
});

export class BreweryDetails extends React.Component {
	constructor(props) {
        super(props);

        const id = this.props.match.params.id;

        this.state = {
            heading: "This is a BreweryDetails Component!",
            brewery: '',
            location: {}
        }

        api.get(id).then(res => {
            this.setState({
                brewery: res.data,
                location: {
                    address: String.prototype.concat(res.data.street, ", ", res.data.city, ", ", res.data.state, ", ", res.data.postalCode),
                    lat: res.data.latitude,
                    lng: res.data.longitude
                }
            })
        });
    }

    render() {
        return (
            <div className="details">
                <GoogleMaps location={this.state.location} zoomLevel={17} />
                <div className="card">
                    <div className="row justify-content-md-left card-body">
                        <h3 className="header">{this.state.brewery.name}</h3>
                        <div className="d-inline-flex">
                            <div className="p-2">
                                c
                            </div>
                            <div className="p-2">
                                <p>{this.state.location.address}</p>
                            </div>
                        </div>
                    </div>
                 </div>
            </div>
        );
    }
};