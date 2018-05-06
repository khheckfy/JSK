"use strict";
/// <reference path="../node_modules/@types/jquery/index.d.ts" />
Object.defineProperty(exports, "__esModule", { value: true });
var Manage;
(function (Manage) {
    var TestList = /** @class */ (function () {
        function TestList() {
            var _this = this;
            $('[role="removeTest"]').click(function (h) { _this.OnTestRemove(parseInt($(h.target).attr('testId'))); });
        }
        TestList.prototype.OnTestRemove = function (id) {
            if (confirm('Remove test?')) {
                var url = '/Manage/RemoveTest/' + id;
                $.ajax({
                    type: "POST",
                    url: url,
                    dataType: "json",
                    async: true,
                    success: function (msg) {
                        if (msg.error) {
                            alert(msg.error);
                            return;
                        }
                        $('[testId="' + id + '"]').parents('tr').remove();
                    }
                });
            }
        };
        return TestList;
    }());
    Manage.TestList = TestList;
    var TestForm = /** @class */ (function () {
        function TestForm(testId) {
            this.TestId = testId;
        }
        return TestForm;
    }());
    Manage.TestForm = TestForm;
})(Manage = exports.Manage || (exports.Manage = {}));
