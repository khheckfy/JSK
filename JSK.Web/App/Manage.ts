/// <reference path="../node_modules/@types/jquery/index.d.ts" />


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
        readonly TestId: number;
        constructor(testId: number) {
            this.TestId = testId;
        }
    }
}