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
            this.testRoot.html('<span class="text-muted">Loading...</span>');
            $.get('/Home/TestItem/' + this.currentTestId, function (data) {
                _this.testRoot.html(data);
                _this.btnNextQuestion = $('#btnNextQuestion');
                _this.btnNextQuestion.click(function (e) { e.target.setAttribute('disabled', 'disabled'); _this.btnNextQuestionOnClick(); });
            });
        };
        Main.prototype.btnNextQuestionOnClick = function () {
            var obj = new UserAnswer(this.currentTestId);
            if (!obj.IsValid) {
                alert('Answer is empty!');
                this.btnNextQuestion.removeAttr('disabled');
                return;
            }
            var url = '/Home/UserTestAnswer/';
            var thisRef = this;
            $.ajax({
                type: "POST",
                url: url,
                data: obj,
                dataType: "json",
                async: true,
                success: function (msg) {
                    if (msg.error) {
                        alert(msg.error);
                        return;
                    }
                    thisRef.loadForm();
                }
            });
        };
        return Main;
    }());
    Tests.Main = Main;
    var UserAnswer = /** @class */ (function () {
        function UserAnswer(testId) {
            var _this = this;
            this.UserTetstId = testId;
            this.QuestionId = $('[name="QuestionId"]').val();
            this.IsValid = true;
            this.IsTextAnser = $('[name="answer"]').length == 0;
            if (!this.IsTextAnser) {
                this.Answers = [];
                $('[name="answer"]:checked').each(function (i, e) {
                    _this.Answers.push(parseInt($(e).attr('id')));
                });
                if (this.Answers.length == 0) {
                    this.IsValid = false;
                }
                this.AnswerText = null;
            }
            else {
                this.Answers = null;
                this.AnswerText = $('#tbAnsertText').val();
                if (this.AnswerText.length == 0) {
                    this.IsValid = false;
                }
            }
        }
        return UserAnswer;
    }());
})(Tests = exports.Tests || (exports.Tests = {}));
