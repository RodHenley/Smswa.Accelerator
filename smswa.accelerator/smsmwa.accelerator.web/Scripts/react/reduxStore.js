import actions from 'es6!/Scripts/react/actions'
import { createStore, applyMiddleware  } from 'redux';
import thunkMiddleware from 'reduxthunk'


function reducer(state = {loading: true, people: []}, action) {
  switch (action.type) {
    case 'LOAD':
      return { ...state, loading: true }
    case 'LOADED':
      return { ...state, loading: false, people:action.people }
    default:
      return state
  }
}

var store = createStore(
  reducer,
  applyMiddleware(thunkMiddleware)
  );

store.subscribe(() =>
  console.log(store.getState())
)

export default store;