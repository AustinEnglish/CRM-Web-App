import React, { Component } from 'react';
import { connect } from 'react-redux';
import { Switch,Route} from 'react-router-dom'
import Navbar from './navbar';
import Leads from './leads';
import Users from './users';
import LeadData from './leadData';
import './app.css';

class App extends Component {
  render() {
    return (
      <div id = "mainPage"> 
      <Navbar/>
        <Switch>
            <Route exact path='/' render={(renderProps) => <Leads/>}/>
            <Route path='/Customers/' render={(renderProps) => <Users/>} />
            <Route path='/leadData/:id/' render={(renderProps) => <LeadData {...renderProps} />} />
        </Switch>
      </div>
    );
  }
}

export default App;