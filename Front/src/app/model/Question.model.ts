import { Answer } from "./Answer.model";

export class Question{
    constructor(public id?: string,
        text?: string,
        blockId?: string,
        blockName?: string,
        answers: Answer[] = new Array()) {}
}