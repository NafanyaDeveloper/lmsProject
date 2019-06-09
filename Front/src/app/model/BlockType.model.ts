import { Block } from "./Block.model";

export class BlockType{
    constructor(public id?: string,
        public name?: string,
        blocks: Block[] = new Array()) {}
}