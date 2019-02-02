import React, { Component } from 'react';
import { Link,Switch,Route } from 'react-router-dom'


class Navbar extends Component {
  state = {


  }

  render() {
    return (
      <div id= "navContainer">
        <nav className="navbar navbar-dark bg-lig float-right nav">
          <form className="form-inline">

            <Link className = "link"
               to='/'>Leads&nbsp;&nbsp;&nbsp;
            </Link>
            
            <Link className = "link"
              to='/customers'>Add Lead&nbsp;&nbsp;&nbsp;
            </Link>


          </form>
        </nav>
         <h1 className = "link nav-title" >Customer Relations Manager</h1>
      </div>
    );
  }
}



export default Navbar;

