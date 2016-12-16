import React from 'react';

class Person extends React.Component{
    constructor(props){
        super(props);
        this.state = {
            id: props.value.id,
            name: props.value.name,
            url: '/person/personReact/' + props.value.id
        };
    }
    render(){
        return (
            <div className="row">
                <div className="col-xs-4">
                    <a href={this.state.url}>{this.state.id}</a>
                </div>
                <div className="col-xs-4">{this.state.name}</div>
            </div>
        );    
    }
}

export default Person