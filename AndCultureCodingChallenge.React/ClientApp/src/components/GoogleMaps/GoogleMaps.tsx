import React, { FC } from 'react';
import PropTypes from 'prop-types';
import GoogleMapReact from 'google-map-react';
import styles from './GoogleMaps.module.css';
import { Icon } from '@iconify/react';
import locationIcon from '@iconify/icons-mdi/map-marker';

const LocationPin = ({ text }: { text: string; lat: number; lng: number;}) => (
    <div className="pin">
        <Icon icon={locationIcon} className="pin-icon" />
        <p className="pin-text">{text}</p>
    </div>
)

interface GoogleMapsProps {
    location: any;
    zoomLevel: number;
    lat: number;
    lng: number;
}

const GoogleMaps: FC<GoogleMapsProps> = ({ location, zoomLevel }) => (
    <div className="map">
        <h2 className="map-h2">Come Visit Us At Our Campus</h2>

        <div className={styles.googleMap}>
            <GoogleMapReact
                defaultCenter={location}
                defaultZoom={zoomLevel}
            >
                <LocationPin
                   lat={location.lat}
                   lng={location.lng}
                   text={location.address}
                />
            </GoogleMapReact>
        </div>
    </div>
);

export default GoogleMaps;
