/// <reference path="../node_modules/@types/jquery/index.d.ts" />
/// <reference path="../node_modules/@types/bootstrap/index.d.ts" />
import { System } from "./System";

export namespace Tests {
    export class Main {
        private readonly currentTestId: string;
        private testRoot: JQuery;
        protected btnNextQuestion: JQuery;

        constructor(id: string) {
            this.currentTestId = id;
            this.testRoot = $('#testRoot');

            this.loadForm();
        }

        private loadForm(): void {
            this.testRoot.html('<span class="text-muted">Loading...</span>');
            $.get('/Home/TestItem/' + this.currentTestId, (data: string) => {
                this.testRoot.html(data);
                this.btnNextQuestion = $('#btnNextQuestion');
                this.btnNextQuestion.click((e) => { e.target.setAttribute('disabled', 'disabled'); this.btnNextQuestionOnClick(); });
            });
        }

        private btnNextQuestionOnClick() {
            let obj: UserAnswer = new UserAnswer(this.currentTestId);
            if (!obj.IsValid) {
                alert('Answer is empty!');
                this.btnNextQuestion.removeAttr('disabled');
                return;
            }

            let url = '/Home/UserTestAnswer/';
            let thisRef = this;
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
        }
    }

    class UserAnswer {
        constructor(testId: string) {
            this.UserTetstId = testId;
            this.QuestionId = <number>$('[name="QuestionId"]').val();

            this.IsValid = true;
            this.IsTextAnser = $('[name="answer"]').length == 0;
            if (!this.IsTextAnser) {
                this.Answers = [];
                $('[name="answer"]:checked').each((i, e) => {
                    this.Answers.push(parseInt($(e).attr('id')));
                });
                if (this.Answers.length == 0) {
                    this.IsValid = false;
                }
                this.AnswerText = null;
            }
            else {
                this.Answers = null;
                this.AnswerText = <string>$('#tbAnsertText').val();
                if (this.AnswerText.length == 0) {
                    this.IsValid = false;
                }
            }
        }

        public Answers: Array<number>;
        public AnswerText: string;
        public QuestionId: number;
        public IsTextAnser: boolean;
        public IsValid: boolean;
        public UserTetstId: string;
    }
}