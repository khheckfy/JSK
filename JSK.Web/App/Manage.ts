/// <reference path="../node_modules/@types/jquery/index.d.ts" />
/// <reference path="../node_modules/@types/bootstrap/index.d.ts" />
import { System } from "./System";



export namespace Manage {
    export class TestList {
        constructor() {
            $('[role="removeTest"]').click((h) => { this.OnTestRemove(parseInt($(h.target).attr('testId'))); })
        }

        public OnTestRemove(id: number) {
            if (confirm('Remove test?')) {
                let url = '/Manage/RemoveTest/' + id;
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
        }
    }

    export class TestForm {
        private readonly TestId: number;
        private questions: Array<QuestionItem>;
        private editedQId: number;
        private qTableBody: JQuery;
        private tbQName: JQuery;
        private chIsSingle: JQuery;
        private qModal: JQuery;
        private hfQuestions: JQuery;

        constructor(testId: number) {
            this.TestId = testId;
            this.questions = new Array<QuestionItem>();

            this.qModal = $('#qModal');
            this.qTableBody = $('#qTableBody');
            this.tbQName = $('#tbQName');
            this.chIsSingle = $('#chIsSingle');
            this.hfQuestions = $('[name="Questions"]');


            $('#btnQSave').click(() => { this.saveQuestion(); });
            $('#btnAddQuestion').click(() => { this.addQuestion(); });

            this.qTableBody.on('click', '[role="deleteQ"]', (e) => { this.deleteQuestion($(e.target)); });
            this.qTableBody.on('click', '[role="editQ"]', (e) => { this.editQuestion($(e.target)); });

            this.rereshQuestions();
        }

        private editQuestion(t: JQuery) {
            let id = $(t).parents('tr').attr('qid');
            console.log(id);
        }

        private deleteQuestion(t: JQuery) {
            let id = $(t).parents('tr').attr('qid');
            let obj = null;
            for (let i = 0; i < this.questions.length; i++)
                if (this.questions[i].TempId == id) {
                    this.questions[i].IsActive = false;
                    break;
                }
            this.hfQuestions.val(JSON.stringify(this.questions));
            this.rereshQuestions();
        }

        private rereshQuestions() {
            let v = <string>this.hfQuestions.val();
            this.questions = v != "" ? $.parseJSON(v) : [];
            this.questions.forEach((q, i) => { q.TempId = System.Guid.New(); })
            let html = '';
            this.questions.forEach((q, i) => {
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
        }

        public saveQuestion() {
            let v: QuestionItem = new QuestionItem();

            v.Question = <string>this.tbQName.val();
            v.IsSingleAnswer = this.chIsSingle.is(':checked');
            v.IsActive = true;
            v.TestId = this.TestId;

            this.questions.push(v);
            this.hfQuestions.val(JSON.stringify(this.questions));
            this.rereshQuestions();
            this.qModal.modal('hide');
        }

        public addQuestion() {
            this.tbQName.val('');
            this.chIsSingle.removeAttr('checked');
        }
    }

    class QuestionItem {
        public Question: string;
        public IsSingleAnswer: boolean;
        public TestQuestionId: number;
        public TestId: number;
        public IsActive: boolean;
        public TempId: string;

        constructor() {
            this.TempId = System.Guid.New();
        }
    }

    class Answer {
        TestQuestionAnswerId: number;
        Answer: string;
        IsCorrect: boolean;
        IsActive: boolean;
        TestQuestionId: number;
    }

    export class QuestionForm {
        private tbAName: JQuery;
        private chIsCorrect: JQuery;
        private QusetionId: number;

        constructor(questionId: number) {
            this.chIsCorrect = $('#chIsCorrect');
            this.tbAName = $('#tbAName');
            $('[data-target="#aModal"]').click((e) => { this.OnOpenModal(parseInt($(e.target).attr('qid'))); });
            $('#btnASave').click(() => { this.OnSave(); })
            $('[role="delete"]').click((e) => { this.OnRemove(parseInt($(e.target).attr('answerId'))); });
            $('[role="isCorrect"]').click((e) => { this.OnIsCorrectAnswer(parseInt($(e.target).attr('answerId'))); });
        }

        private OnOpenModal(qid: number) {
            this.tbAName.val('');
            this.QusetionId = qid;
        }

        private OnIsCorrectAnswer(id: number) {
            let url = '/Manage/IsCorrect_Answer/' + id;
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
        }

        private OnSave() {
            let data: Answer = new Answer()
            data.Answer = <string>this.tbAName.val();
            data.IsActive = true;
            data.IsCorrect = this.chIsCorrect.is(':checked');
            data.TestQuestionId = this.QusetionId;

            let url = '/Manage/Create_Answer/';
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
        }

        private OnRemove(id: number) {
            let url = '/Manage/Remove_Answer/' + id;
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

        }
    }

}