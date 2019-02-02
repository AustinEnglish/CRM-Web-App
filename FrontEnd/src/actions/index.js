import axios from 'axios';
import {
  DEFAULT_VALS,
  GET_LEADS_ASYNC,
  GET_LEAD_ASYNC,
  ADD_LEAD_ASYNC
} from '../constants'


/**
 *    Here are some sample asynchronous action creators that you'll likely want to use
 *    to handle basic CRUD routes from your REST API / DB
 *    
 *    Not all are necessary and they are not fully implemented as well. 
 *    Treat this as guidance.
 */

// ####################### Leads #######################

export const defaultFunc =() => async dispatch => {
  dispatch({ type: DEFAULT_VALS });
}


export const getLeads = () => async dispatch => {
  let response = await axios.get('http://localhost:5000/api/leads/');
  console.log(response);
  dispatch({ type: GET_LEADS_ASYNC, payload:response.data });
}


export const getLead = id => async dispatch => {
  let response = await axios.get('http://localhost:5000/api/leads/' + id);
  console.log(response);
  dispatch({ type: GET_LEAD_ASYNC, payload:response.data });
}

export const addLead = lead => async dispatch => {
  let response = await axios.post('http://localhost:5000/api/leads/', lead);
  console.log(response);
  dispatch({ type: ADD_LEAD_ASYNC,payload:response.data });
}


