import React from 'react';


export default class MyComponent extends React.Component {
    handleClick() {
        if (this.refs.myInput !== null) {
            var input = this.refs.myInput;
            var inputValue = input.value;
            alert("Input is " + inputValue);
        }
    }

    handleChange(e) {
        console.log(e.target.value);
    }

    render() {
        return (
            <div>
                <input type="text" ref="myInput" onChange={this.handleChange} />
                <input
                    type="button"
                    value="Alert the text input"
                    onClick={this.handleClick}
                />
            </div>
        );
    }
};
