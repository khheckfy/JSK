import React from 'react';
import ReactDOM from 'react-dom';
import { connect } from 'react-redux';

export default class AdminTestForm extends React.Component {
    constructor() {
        super();
        this.state = { name: "", isRandom: false };
    }



    render() {
        return (
            <div className="modal fade" id="testFormModal" tabIndex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
                <div className="modal-dialog" role="document">
                    <div className="modal-content">
                        <div className="modal-header">
                            <h5 className="modal-title" id="exampleModalLabel">Modal title</h5>
                            <button type="button" className="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>
                        <div className="modal-body">
                            <div className="form-group">
                                <label htmlFor="exampleInputEmail1">Test name</label>
                                <input type="text" className="form-control" id="tbTestName" placeholder="Enter test name" />
                            </div>
                            <div className="form-group form-check">
                                <input type="checkbox" className="form-check-input" id="chIsRandom" />
                                <label className="form-check-label" htmlFor="chIsRandom">Is random questions</label>
                            </div>
                        </div>
                        <div className="modal-footer">
                            <button type="button" className="btn btn-secondary" data-dismiss="modal">Close</button>
                            <button type="button" className="btn btn-primary">Save changes</button>
                        </div>
                    </div>
                </div>
            </div>
        );
    }
};