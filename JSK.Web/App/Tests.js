"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var Tests;
(function (Tests) {
    var Main = /** @class */ (function () {
        function Main(id) {
            this.currentTestId = id;
            this.testRoot = $('#testRoot');
            this.loadForm();
        }
        Main.prototype.loadForm = function () {
            var _this = this;
            $.get('/Home/TestItem/' + this.currentTestId, function (data) {
                _this.testRoot.html(data);
            });
        };
        return Main;
    }());
    Tests.Main = Main;
})(Tests = exports.Tests || (exports.Tests = {}));
