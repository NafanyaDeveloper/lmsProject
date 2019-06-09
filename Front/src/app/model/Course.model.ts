import { Page } from "./Page.model";
import { Group } from "./Group.model";

export class Course{
    constructor(public id?: string,
        public name?: string,
        description?: string,
        public directionId?: string,
        directionName?: string,
        img?: string,
        public loadImg?: string,
        public pages: Page[] = new Array(),
        public groups: Group[] = new Array()) {}
}