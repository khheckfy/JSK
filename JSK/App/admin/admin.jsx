import React from 'react';
import ReactDOM from 'react-dom';
import AdminTestForm from './adminTestForm.jsx';

const testsApi = '/api/tests/';

export default class Admin extends React.Component {
    constructor(props) {
        super(props);
        this.state = { tests: [] };

        this.btnAddTestClick = this.btnAddTestClick.bind(this);
    }

    btnAddTestClick() {

    }

    btnEditTestClick() {
    }

    // загрузка данных
    loadData() {
        var xhr = new XMLHttpRequest();
        xhr.open("get", testsApi, true);
        xhr.onload = function () {
            var data = JSON.parse(xhr.responseText);
            this.setState({ tests: data });
        }.bind(this);
        xhr.send();
    }

    componentDidMount() {
        this.loadData();
    }

    render() {
        return (
            <div>
                <div className="input-group">
                    <div className="input-group-prepend">
                        <span className="input-group-text">Tests:</span>
                    </div>
                    <select className="custom-select">
                        {
                            this.state.tests.map(function (test) {
                                return <option key={test.testId} value={test.testId}>{test.name}</option>
                            })
                        }
                    </select>
                    <div className="input-group-append">
                        <button className="btn btn-outline-success" onClick={this.btnAddTestClick} data-toggle="modal" data-target="#testFormModal"><span className="fa fa-plus" title="Add test"></span></button>
                        <button className="btn btn-outline-primary" onClick={this.btnEditTestClick}><span className="fa fa-edit" title="edit test" data-toggle="modal" data-target="#testFormModal"></span></button>
                        <button className="btn btn-outline-danger" type="button"><span className="fa fa-remove" title="remove test"></span></button>
                    </div>
                </div>
                <AdminTestForm />
            </div>
        );
    }
};