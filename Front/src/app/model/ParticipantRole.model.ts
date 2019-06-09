import { Participant } from "./Participant.model";

export class ParticipantRole{
    constructor(public id?: string,
        name?: string,
        participants: Participant[] = new Array()) {}
}