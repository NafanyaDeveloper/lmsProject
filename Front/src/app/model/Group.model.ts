import { Participant } from "./Participant.model";

export class Group{
    constructor(public id?: string,
        name?: string,
        start?: string,
        finish?: string,
        courseId?: string,
        courseName?: string,
        public participant: Participant[] = new Array()) {}
}