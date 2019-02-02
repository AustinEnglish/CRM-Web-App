
import {
  DEFAULT_VALS,
  GET_LEADS_ASYNC,
  GET_LEAD_ASYNC,
  ADD_LEAD_ASYNC
} from '../constants'



const initialState = {
  customers: [],
  leads: [],
  interactions: [],
  lead: null     
}


const rootReducer = (state = initialState, action) => {
  let updatedState;

  switch (action.type) {



    case DEFAULT_VALS:

    updatedState = {
      ...initialState,

    }

    return updatedState;


  /************************************ */

  
    case GET_LEADS_ASYNC:

    console.log(action.payload)

     updatedState = {
      //allows us to leave other data  alone
      ...state,
      //add leads data
      leads : action.payload
    }

    return updatedState;

/**************************************** */

     case GET_LEAD_ASYNC:

     console.log(action.payload)

     updatedState = {
      ...state,
      lead : action.payload
    }
    return updatedState;

/***************************************** */


case ADD_LEAD_ASYNC:

console.log(action.payload)

updatedState = {
 ...state,
 leads : action.payload
}
return updatedState;

/***************************************** */

    default:
      return state;
  }
}

export default rootReducer;