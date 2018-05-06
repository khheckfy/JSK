/// <reference path="../node_modules/@types/jquery/index.d.ts" />
/// <reference path="../node_modules/@types/bootstrap/index.d.ts" />import { System } from "./System";



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

            let qs = <string>this.hfQuestions.val();
            if (qs) {
                this.questions = $.parseJSON(qs);
            }

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
            $('[qid="' + id + '"]').remove();
        }

        private rereshQuestions() {
            let v = <string>this.hfQuestions.val();
            this.questions = v != "" ? $.parseJSON(v) : [];
            let html = '';
            this.questions.forEach((q, i) => {
                html += '<tr qid="' + q.TestQuestionId + '">';
                html += '   <td>' + q.Question + '</td>';
                html += '   <td>' + (q.IsSingleAnswer == true ? 'yes' : 'no') + '</td>';
                html += '   <td>';
                html += '       <a  class="fa fa-edit" role = "editQ" ></a>';
                html += '       <a role="deleteQ" class="fa fa-remove text-danger"></a >';
                html += '   </td>';
                html += '</tr>';
            });
            this.qTableBody.html(html);
        }

        public saveQuestion() {
            let v: QuestionItem = new QuestionItem();
            v.Question = <string>this.tbQName.val();
            v.IsSingleAnswer = this.chIsSingle.is(':checked');
            v.TestId = this.TestId;
            v.TestQuestionId = 0;

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
    }

}