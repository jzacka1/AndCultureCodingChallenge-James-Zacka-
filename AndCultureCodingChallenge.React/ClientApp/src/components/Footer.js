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
            <footer id="footer" class="footer-1 border-top box-shadow mt-3">
                <div class="main-footer widgets-dark typo-light">
                    <div class="container">
                        <div class="row">

                            <div class="col-xs-12 col-sm-6 col-md-3">
                                <div class="widget subscribe no-box">
                                    <h5 class="widget-title">ANDCULTURE CODING CHALLENGE<span></span></h5>
                                    <p>Here is my project for the coding challenge. </p>
                                </div>
                            </div>

                            <div class="col-xs-12 col-sm-6 col-md-3">
                                <div class="widget no-box">
                                    <h5 class="widget-title">Quick Links<span></span></h5>
                                    <ul class="thumbnail-widget">
                                        <li>
                                            <div class="thumb-content"><a href="#.">Get Started</a></div>
                                        </li>
                                        <li>
                                            <div class="thumb-content"><a href="#.">Top Leaders</a></div>
                                        </li>
                                        <li>
                                            <div class="thumb-content"><a href="#.">Success Stories</a></div>
                                        </li>
                                        <li>
                                            <div class="thumb-content"><a href="#.">Event/Tickets</a></div>
                                        </li>
                                        <li>
                                            <div class="thumb-content"><a href="#.">News</a></div>
                                        </li>
                                        <li>
                                            <div class="thumb-content"><a href="#.">Lifestyle</a></div>
                                        </li>
                                        <li>
                                            <div class="thumb-content"><a href="#.">About</a></div>
                                        </li>
                                    </ul>
                                </div>
                            </div>

                            <div class="col-xs-12 col-sm-6 col-md-3">
                                <div class="widget no-box">
                                    <h5 class="widget-title">Get Started<span></span></h5>
                                    <p>Get access to your full Training and Marketing Suite.</p>
                                </div>
                            </div>

                            <div class="col-xs-12 col-sm-6 col-md-3">

                                <div class="widget no-box">
                                    <h5 class="widget-title">Contact Us<span></span></h5>

                                    <p><a href="mailto:info@domain.com" title="glorythemes">info@domain.com</a></p>
                                    <ul class="social-footer2">
                                        <li class="">
                                            <a title="youtube" href="https://bit.ly/3m9avif">
                                                <FontAwesomeIcon icon={faYoutube} />
                                            </a>
                                         </li>
                                        <li class="">
                                            <a href="https://www.facebook.com/" title="Facebook">
                                                <FontAwesomeIcon icon={faFacebook } />
                                            </a>
                                        </li>
                                        <li class="">
                                            <a href="https://twitter.com" title="Twitter">
                                                <FontAwesomeIcon icon={faTwitter} />
                                            </a>
                                        </li>
                                        <li class="">
                                            <a title="instagram" href="https://www.instagram.com/">
                                                <FontAwesomeIcon icon={ faInstagram } />
                                            </a>
                                        </li>
                                    </ul>
                                </div>

                                <div class="footer-copyright">
                                    <div class="container">
                                        <div class="row">
                                            <div class="col-md-12 text-center">
                                                <p>Copyright James Zacka © {new Date().getFullYear()}. All rights reserved.</p>
                                            </div>
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