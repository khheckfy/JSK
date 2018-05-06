"use strict";
/// <reference path="../node_modules/@types/jquery/index.d.ts" />
/// <reference path="../node_modules/@types/bootstrap/index.d.ts" />
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
            var _this = this;
            this.TestId = testId;
            this.questions = new Array();
            this.qModal = $('#qModal');
            this.qTableBody = $('#qTableBody');
            this.tbQName = $('#tbQName');
            this.chIsSingle = $('#chIsSingle');
            this.hfQuestions = $('[name="Questions"]');
            $('#btnQSave').click(function () { _this.saveQuestion(); });
            $('#btnAddQuestion').click(function () { _this.addQuestion(); });
            var qs = this.hfQuestions.val();
            if (qs) {
                this.questions = $.parseJSON(qs);
            }
            this.qTableBody.on('click', 'role="deleteQ"', function (e) {
                console.log(e);
            });
            this.rereshQuestions();
        }
        TestForm.prototype.rereshQuestions = function () {
            var v = this.hfQuestions.val();
            this.questions = v != "" ? $.parseJSON(v) : [];
            var html = '';
            this.questions.forEach(function (q, i) {
                html += '<tr>';
                html += '   <td>' + q.Question + '</td>';
                html += '   <td>' + (q.IsSingleAnswer == true ? 'yes' : 'no') + '</td>';
                html += '   <td><a class="fa fa-edit"></a><a role="deleteQ" class="fa fa-remove text-danger"></a></td>';
                html += '</tr>';
            });
            this.qTableBody.html(html);
        };
        TestForm.prototype.saveQuestion = function () {
            var v = new QuestionItem();
            v.Question = this.tbQName.val();
            v.IsSingleAnswer = this.chIsSingle.is(':checked');
            v.TestId = this.TestId;
            this.questions.push(v);
            this.hfQuestions.val(JSON.stringify(this.questions));
            this.rereshQuestions();
            this.qModal.modal('hide');
        };
        TestForm.prototype.addQuestion = function () {
            this.tbQName.val('');
            this.chIsSingle.removeAttr('checked');
        };
        return TestForm;
    }());
    Manage.TestForm = TestForm;
    var QuestionItem = /** @class */ (function () {
        function QuestionItem() {
        }
        return QuestionItem;
    }());
})(Manage = exports.Manage || (exports.Manage = {}));
