import React, { Component } from 'react';
import styles from './GoogleMaps.module.css';
import GoogleMapReact from 'google-map-react';
import { Icon } from '@iconify/react';
import locationIcon from '@iconify/icons-mdi/map-marker';

const LocationPin = ({ text }: { text: string; lat: number; lng: number;}) => (
    <div className="pin">
        <Icon icon={locationIcon} className="pin-icon" />
        <p className="pin-text">{text}</p>
    </div>
)

export class GoogleMaps extends React.Component {
	constructor(props) {
        super(props);

        this.state = {
            heading: "This is a GoogleMaps Component!"
        }
    }

    render() {
        return (
            <div className="map">
                <div className={styles.googleMap}>
                    <GoogleMapReact
                        defaultCenter={this.props.location}
                        defaultZoom={this.props.zoomLevel}
                    >
                        <LocationPin
                            lat={this.props.location.lat}
                            lng={this.props.location.lng}
                            text={this.props.location.address}
                        />
                    </GoogleMapReact>
                </div>
            </div>
        );
    }
};