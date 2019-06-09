import { Course } from "./Course.model";
import { Administration } from "./Administration.model";

export class Direction{
    constructor(public id?: string,
        public name?: string,
        description?: string,
        img?: string,
        public loadImg?: string,
        public courses: Course[] = new Array(),
        public administration: Administration[] = new Array()) {}
}