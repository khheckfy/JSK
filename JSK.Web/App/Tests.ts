/// <reference path="../node_modules/@types/jquery/index.d.ts" />
/// <reference path="../node_modules/@types/bootstrap/index.d.ts" />
import { System } from "./System";

export namespace Tests {
    export class Main {
        private readonly currentTestId: string;
        private testRoot: JQuery;

        constructor(id: string) {
            this.currentTestId = id;
            this.testRoot = $('#testRoot');

            this.loadForm();
        }

        private loadForm(): void {
            $.get('/Home/TestItem/' + this.currentTestId, (data: string) => {
                this.testRoot.html(data);
            });
        }
    }
}