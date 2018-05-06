"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
/// <reference path="../node_modules/@types/jquery/index.d.ts" />
/// <reference path="../node_modules/@types/bootstrap/index.d.ts" />
var System_1 = require("./System");
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
            this.qTableBody.on('click', '[role="deleteQ"]', function (e) { _this.deleteQuestion($(e.target)); });
            this.qTableBody.on('click', '[role="editQ"]', function (e) { _this.editQuestion($(e.target)); });
            this.rereshQuestions();
        }
        TestForm.prototype.editQuestion = function (t) {
            var id = $(t).parents('tr').attr('qid');
            console.log(id);
        };
        TestForm.prototype.deleteQuestion = function (t) {
            var id = $(t).parents('tr').attr('qid');
            var obj = null;
            for (var i = 0; i < this.questions.length; i++)
                if (this.questions[i].TempId == id) {
                    this.questions[i].IsActive = false;
                    break;
                }
            this.hfQuestions.val(JSON.stringify(this.questions));
            this.rereshQuestions();
        };
        TestForm.prototype.rereshQuestions = function () {
            var v = this.hfQuestions.val();
            this.questions = v != "" ? $.parseJSON(v) : [];
            this.questions.forEach(function (q, i) { q.TempId = System_1.System.Guid.New(); });
            var html = '';
            this.questions.forEach(function (q, i) {
                if (q.IsActive) {
                    html += '<tr qid="' + q.TempId + '">';
                    html += '   <td>' + q.Question + '</td>';
                    html += '   <td>' + (q.IsSingleAnswer == true ? 'yes' : 'no') + '</td>';
                    html += '   <td>';
                    html += '       <a role="deleteQ" class="fa fa-remove text-danger"></a >';
                    html += '   </td>';
                    html += '</tr>';
                }
            });
            this.qTableBody.html(html);
        };
        TestForm.prototype.saveQuestion = function () {
            var v = new QuestionItem();
            v.Question = this.tbQName.val();
            v.IsSingleAnswer = this.chIsSingle.is(':checked');
            v.IsActive = true;
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
            this.TempId = System_1.System.Guid.New();
        }
        return QuestionItem;
    }());
    var Answer = /** @class */ (function () {
        function Answer() {
        }
        return Answer;
    }());
    var QuestionForm = /** @class */ (function () {
        function QuestionForm(questionId) {
            var _this = this;
            this.chIsCorrect = $('#chIsCorrect');
            this.tbAName = $('#tbAName');
            $('[data-target="#aModal"]').click(function (e) { _this.OnOpenModal(parseInt($(e.target).attr('qid'))); });
            $('#btnASave').click(function () { _this.OnSave(); });
            $('[role="delete"]').click(function (e) { _this.OnRemove(parseInt($(e.target).attr('answerId'))); });
            $('[role="isCorrect"]').click(function (e) { _this.OnIsCorrectAnswer(parseInt($(e.target).attr('answerId'))); });
        }
        QuestionForm.prototype.OnOpenModal = function (qid) {
            this.tbAName.val('');
            this.QusetionId = qid;
        };
        QuestionForm.prototype.OnIsCorrectAnswer = function (id) {
            var url = '/Manage/IsCorrect_Answer/' + id;
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
                    window.location.reload();
                    //$('[answerId="' + id + '"]').parents('li').remove();
                }
            });
        };
        QuestionForm.prototype.OnSave = function () {
            var data = new Answer();
            data.Answer = this.tbAName.val();
            data.IsActive = true;
            data.IsCorrect = this.chIsCorrect.is(':checked');
            data.TestQuestionId = this.QusetionId;
            var url = '/Manage/Create_Answer/';
            $.ajax({
                type: "POST",
                url: url,
                data: data,
                dataType: "json",
                async: true,
                success: function (msg) {
                    if (msg.error) {
                        alert(msg.error);
                        return;
                    }
                    window.location.reload();
                    //$('[answerId="' + id + '"]').parents('li').remove();
                }
            });
        };
        QuestionForm.prototype.OnRemove = function (id) {
            var url = '/Manage/Remove_Answer/' + id;
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
                    $('[answerId="' + id + '"]').parents('li').remove();
                }
            });
        };
        return QuestionForm;
    }());
    Manage.QuestionForm = QuestionForm;
})(Manage = exports.Manage || (exports.Manage = {}));
