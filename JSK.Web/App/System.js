"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var System;
(function (System) {
    var Guid = /** @class */ (function () {
        function Guid() {
        }
        Guid.New = function () {
            function s4() {
                return Math.floor((1 + Math.random()) * 0x10000)
                    .toString(16)
                    .substring(1);
            }
            return s4() + s4() + '-' + s4() + '-' + s4() + '-' + s4() + '-' + s4() + s4() + s4();
        };
        return Guid;
    }());
    System.Guid = Guid;
})(System = exports.System || (exports.System = {}));
