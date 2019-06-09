import { Block } from "./Block.model";

export class Page{
    constructor(public id?: string,
        name?: string,
        number?: number,
        isMilestone?: boolean,
        courseId?: string,
        courseName?: string,
        public blocks: Block[] = new Array()) {}
}