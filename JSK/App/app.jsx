import 'poper';
import 'jquery';
import 'bootstrap';

import 'bootstrap/dist/css/bootstrap.min.css';

import React from 'react';
import ReactDOM from 'react-dom';
import { BrowserRouter as Router, Route, Switch } from 'react-router-dom';
import Header from './header/header.jsx';
import Admin from './admin/admin.jsx';
import Home from './home/home.jsx';

export default class App extends React.Component {
    render() {
        return (
            <Router>
                <div>
                    <Header />
                    <main>
                        <Switch>
                            <Route path="/admin" component={Admin} />
                            <Route path="/" component={Home} />
                        </Switch>
                    </main>
                </div>
            </Router>
        );
    }
};