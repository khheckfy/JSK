﻿import React from 'react';
import MyComponent from '../test/test.jsx'

export default class Home extends React.Component {
    render() {
        return (
            <div>
                <MyComponent />
                <div className="jumbotron">
                    <h1 className="display-4">Hello, world!</h1>
                    <p className="lead">This is a simple hero unit, a simple jumbotron-style component for calling extra attention to featured content or information.</p>
                    <hr className="my-4" />
                    <p>It uses utility classes for typography and spacing to space content out within the larger container.</p>
                    <p className="lead">
                        <a className="btn btn-primary btn-lg" href="#" role="button">Start tests</a>
                    </p>
                </div>
            </div>
        );
    }
};