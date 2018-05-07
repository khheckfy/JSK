import 'poper';
import * as $ from "jquery";
import 'bootstrap';
import 'bootstrap/dist/css/bootstrap.min.css';
import 'font-awesome/css/font-awesome.css';
import * as manage from './Manage';
import * as system from './System';
import * as tests from './Tests';

window["Manage"] = manage;
window["tests"] = tests;
window["$"] = $;