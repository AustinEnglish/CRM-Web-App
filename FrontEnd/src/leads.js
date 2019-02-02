import React, { Component } from 'react';
import { connect } from 'react-redux';
import { Redirect } from 'react-router-dom'
import { getLeads } from './actions';


class Leads extends Component {
    state = {
        id: '',
        showLead: false
    }


    showAll = leadId=>
    {
        this.setState({showLead:true, id:leadId })
    }

    componentDidMount() {
        this.props.getLeads();
        this.setState({showLead:false})
    }


    render() {
        return (
            <div id="leads">
                <h1>Leads</h1>
                <p>&nbsp;</p>

                <table className = "table">
                    <thead class="thead-dark">
                        <tr>
                            <th scope="col">#</th>
                            <th scope="col">Customer Name</th>
                            <th scope="col">Created</th>
                            <th scope="col">Managed By</th>
                            <th scope="col"></th>
                        </tr>
                    </thead>
                    {
                        this.props.leads && (

                            this.props.leads.map((lead, index) => {

                                return (
                                    <tbody id="element" key={index}>
                                    <tr>
                                    <th scope="row">{index+1}</th>
                                    <td>{lead.customer.name}</td>
                                    <td>{lead.last_contact}</td>
                                    <td>{lead.employee.name}</td>
                                    <td><button type='submit' 
                                        className='btn btn-primary add-button reg-buttons sub-button' 
                                        onClick={()=>this.showAll(lead.lead_id)}> View </button></td>
                                    </tr>
                                    </tbody>
                                )
                            })

                        )

                    }
                </table>
                <div>
                    {
                        this.state.showLead &&(

                        <Redirect to={`/leadData/${this.state.id}`}/>
                        )
                    }

                </div>

            </div>
        );
    }
}


const mapStateToProps = state => ({
    leads: state.leads
});

const mapPropsToDispatch = dispatch => ({
    getLeads: () => dispatch(getLeads())
})

export default connect(mapStateToProps, mapPropsToDispatch)(Leads);

