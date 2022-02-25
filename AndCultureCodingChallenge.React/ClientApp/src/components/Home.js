import React, { Component } from 'react';
import { BreweryList } from './BreweryList/BreweryList'

export class Home extends Component {
    static displayName = Home.name;

  render () {
    return (
        <div>
            <BreweryList/>
      </div>
    );
  }
}
