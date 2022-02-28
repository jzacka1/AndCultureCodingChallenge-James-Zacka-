import React, { Component } from 'react';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faYoutube, faFacebook, faTwitter, faInstagram } from '@fortawesome/free-brands-svg-icons'

export class Footer extends Component {
    constructor(props) {
        super(props);

        this.state = {

        };
    }

    render() {
        return (
            <footer id="footer" className="footer-1 border-top shadow-lg p-3 mt-3">
                <div className="main-footer widgets-dark typo-light pb-3">
                    <div className="container">
                        <div className="row">

                            <div className="col-xs-12 col-sm-6 col-md-3">
                                <div className="widget subscribe no-box">
                                    <h5 className="widget-title">ANDCULTURE CODING CHALLENGE<span></span></h5>
                                    <p>Here is my project for the coding challenge. </p>
                                </div>
                            </div>

                            <div className="col-xs-12 col-sm-6 col-md-3">
                                <div className="widget no-box">
                                    <h5 className="widget-title">Quick Links<span></span></h5>
                                    <ul className="thumbnail-widget">
                                        <li>
                                            <div className="thumb-content"><a href="/">Home</a></div>
                                        </li>
                                        <li>
                                            <div className="thumb-content"><a href="/counter">Counter</a></div>
                                        </li>
                                        <li>
                                            <div className="thumb-content"><a href="/fetch-data">Fetch Data</a></div>
                                        </li>
                                    </ul>
                                </div>
                            </div>

                            <div className="col-xs-12 col-sm-6 col-md-3">
                                <div className="widget no-box">
                                    <h5 className="widget-title">It is Fun<span></span></h5>
                                    <p>This is my coding challenge.  I plan to continue working on it, and add improvements when needed.  Thank you.</p>
                                </div>
                            </div>

                            <div className="col-xs-12 col-sm-6 col-md-3">

                                <div className="widget no-box">
                                    <h5 className="widget-title">Contact Us<span></span></h5>

                                    <p><a href="mailto:info@domain.com" title="glorythemes">info@domain.com</a></p>
                                    <ul className="social-footer2">
                                        <li className="">
                                            <a title="youtube" href="https://bit.ly/3m9avif">
                                                <FontAwesomeIcon icon={faYoutube} />
                                            </a>
                                         </li>
                                        <li className="">
                                            <a href="https://www.facebook.com/" title="Facebook">
                                                <FontAwesomeIcon icon={faFacebook } />
                                            </a>
                                        </li>
                                        <li className="">
                                            <a href="https://twitter.com" title="Twitter">
                                                <FontAwesomeIcon icon={faTwitter} />
                                            </a>
                                        </li>
                                        <li className="">
                                            <a title="instagram" href="https://www.instagram.com/">
                                                <FontAwesomeIcon icon={ faInstagram } />
                                            </a>
                                        </li>
                                    </ul>
                                </div>
                            </div>
                        </div>
                        <div className="row">
                            <div className="footer-copyright">
                                <div className="container">
                                    <div className="row">
                                        <div className="col-md-12 text-center">
                                            <p>Copyright James Zacka © {new Date().getFullYear()}. All rights reserved.</p>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </footer>
        );
    }
}