import React, { Component } from 'react';
import { connect } from 'react-redux';
import { Redirect } from 'react-router-dom'
import { addLead } from './actions';


class Users extends Component {
    state = {

        name: '',
        email: '',
        phone: '',
        age: '',
        preferred_contact: '',
        priotityType: '',

        redirect: false

    }

    submitData = () => {
        var lead = {};
        var detail = {};
        var priority = {};
        var customer = {};

        customer.name = this.state.name;
        customer.email = this.state.email;
        customer.phone = this.state.phone;
        customer.age = parseInt(this.state.age);

        detail.preferred_contact = this.state.preferred_contact;
        customer.detail = detail;
        lead.customer = customer;


        priority.type = this.state.priotityType;
        lead.priority_type = priority;


        this.setState({ redirect: true });

        this.props.addLead(lead);





    }

    render() {
        return (
            <div id="outerUsers">
                <div id='innerUsers'>
                    <div id="centerUsers">
                        <h1 id='titleId'>Create Lead</h1>
                        <input type='text'
                            className="txtBox"
                            placeholder="Full Name"
                            value={this.state.name}
                            onChange={(e) => this.setState({ name: e.target.value })} />
                        <p>&nbsp;</p>

                        <input type='text'
                            className="txtBox"
                            placeholder="Email"
                            value={this.state.email}
                            onChange={(e) => this.setState({ email: e.target.value })} />
                        <p>&nbsp;</p>

                        <input type='text'
                            className="txtBox"
                            placeholder="Phone Number"
                            value={this.state.phone}
                            onChange={(e) => this.setState({ phone: e.target.value })} />
                        <p>&nbsp;</p>

                        <input type='number'
                            className="txtBox"
                            placeholder="Age"
                            value={this.state.age}
                            onChange={(e) => this.setState({ age: e.target.value })} />
                        <p>&nbsp;</p>

                        <select onChange={e => { this.setState({ priotityType: e.target.value }) }}>
                            <option value="">Priority</option>
                            <option value="low">low</option>
                            <option value="middle" >middle</option>
                            <option value="high">high</option>
                        </select>
                        <p>&nbsp;</p>

                        <textarea type='text'
                            className="txtBox largerBox"
                            placeholder=" extra information"
                            value={this.state.preferred_contact}
                            onChange={(e) => this.setState({ preferred_contact: e.target.value })} />
                        <p>&nbsp;</p>




                        <button type='submit' className='btn btn-primary add-button reg-buttons sub-button' onClick={() => this.submitData()}> Add </button>
                        <p>&nbsp;</p>
                    </div>
                </div>
                {
                    this.state.redirect && (
                        <Redirect to='/' />
                    )
                }
            </div>
        );
    }
}



const mapPropsToDispatch = dispatch => ({

    addLead: (lead) => dispatch(addLead(lead))

})

export default connect(null, mapPropsToDispatch)(Users);

