import React, { Component } from 'react';
import { connect } from 'react-redux';
import { getLead } from './actions';


class LeadData extends Component {
    state = {

    }

    componentDidMount() {
        console.log("here");
        this.props.getLead(this.props.match.params.id)
    }

    render() {
        return (
            <div>
                <h1>Lead Data</h1>
                {
                    this.props.lead && (
                        <table class="table">
                            <thead class="thead-dark">
                                <tr>
                                    <th scope="col">Customer Name</th>
                                    <th scope="col">Customer Email</th>
                                    <th scope="col">Status</th>
                                    <th scope="col">Priority</th>
                                    <th scope="col">info</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <td>{this.props.lead.customer.name}</td>
                                    <td>{this.props.lead.customer.email}</td>
                                    <td>{this.props.lead.status_type.type}</td>
                                    <td>{this.props.lead.priority_type.type}</td>
                                    <td>{this.props.lead.customer.detail.preferred_contact}</td>
                                </tr>
                            </tbody>
                        </table>



                    )

                }

            </div>
        );
    }
}


const mapStateToProps = state => ({

    lead: state.lead


});

const mapPropsToDispatch = dispatch => ({
    getLead: (id) => dispatch(getLead(id))

})

export default connect(mapStateToProps, mapPropsToDispatch)(LeadData);

