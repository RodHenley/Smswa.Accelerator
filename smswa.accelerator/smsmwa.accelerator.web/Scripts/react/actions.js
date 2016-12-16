import 'fetch';

function loadPeople(){
  return {
    type: 'LOAD'
  }
}

function receivePeople(json){
  return{
    type:'LOADED',
    people: json.people
  }
}

export function fetchPeople(){
  return function(dispatch){
    dispatch(loadPeople())
    return fetch('/person/getList')
      .then(response=>response.json())
      .then(json=>
        dispatch(receivePeople(json))
      )
  }
}
