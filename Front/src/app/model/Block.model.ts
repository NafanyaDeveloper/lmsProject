import { Question } from "./Question.model";

export class Block{
    constructor(public id?: string,
        name?: string,
        public blockTypeId?: string,
        blockTypeName?: string,
        img?: string,
        text?: string,
        public loadImg?: string,
        pageId?: string,
        pageName?: string,
        questions: Question[] = new Array()) {}
}