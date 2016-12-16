import React from 'react';
import ReactDOM from 'reactDOM';

import Loading from 'es6!/Scripts/react/loading';
import Person from 'es6!/Scripts/react/person';
import ReduxStore from 'es6!/Scripts/react/reduxStore';
import {fetchPeople} from 'es6!/Scripts/react/actions';

class PersonListPage extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            loading: true,
            people: []
        };
    }
    componentDidMount (){
        ReduxStore.subscribe(()=>{
            this.setState(ReduxStore.getState());
        });
        // ReduxStore.dispatch({type: 'LOAD'})
        // setTimeout(this.done.bind(this), 2000);
        ReduxStore.dispatch(fetchPeople());
    }
    done() {
        // ReduxStore.dispatch({type: 'LOADED', people:[
        //         {id: 1, name:"jason"},
        //         {id: 2, name:"bob"}
        //     ]})
    }
    render() {
        if (this.state.loading) {
          return <Loading/>  
        } else {
            if (this.state.people.length)
            {
                return(
                <div className="container">
                    <div className="row">
                        <div className="col-sm-4">Id</div>
                        <div className="col-xs-4">Name</div>
                    </div>
                    {
                        this.state.people.map(function(person){
                            return <Person  key={person.id} value={person}/>;
                        })
                    }
                </div>
                );
            }
            else{
                return <h2>No people</h2>
            }
            
        }
        
    }
}

ReactDOM.render(
  <PersonListPage/>,
    document.getElementById('maincontent')
);