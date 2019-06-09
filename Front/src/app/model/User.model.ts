import { Participant } from "./Participant.model";
import { Administration } from "./Administration.model";

export class User{
    constructor(public id?: string,
        email?: string,
        name?: string,
        surname?: string,
        avatar?: string,
        public loadImg?: string,
        birth?: string,
        password?: string,
        participant: Participant[] = new Array(),
        administration: Administration[] = new Array()) {}
}