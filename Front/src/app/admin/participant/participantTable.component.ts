import { Component, Input } from "@angular/core";
import { ParticipantRepository } from "src/app/model/repository/participantRepository";
import { Participant } from "src/app/model/Participant.model";

@Component({
    selector: "participant-table",
    templateUrl: "template/participantTable.template.html"
})

export class ParticipantTableComponent{
    constructor(private repo: ParticipantRepository) {}

    ngOnInit(){
        if(this.groupId != null)
            this.getParticipantByGroup(this.groupId);
        else if (this.userId != null)
            this.getParticipantByUser(this.userId);
        else if (this.roleId != null)
            this.getParticipantByRole(this.roleId);
        else
            this.getParticipants();
    }

    @Input() groupId: string;
    @Input() userId: string;
    @Input() roleId: string;

    
    participant: Participant[];

    getParticipants(){
        this.repo.getParticipants().subscribe(
            data => this.participant = data,
            error => this.participant = null)
    }

    getParticipantByGroup(id: string){
        this.repo.getParticipantByGroup(id).subscribe(
            data => this.participant = data,
            error => this.participant = null)
    }

    getParticipantByUser(id: string){
        this.repo.getParticipantByUser(id).subscribe(
            data => this.participant = data,
            error => this.participant = null)
    }

    getParticipantByRole(id: string){
        this.repo.getParticipantByRole(id).subscribe(
            data => this.participant = data,
            error => this.participant = null)
    }

    deleteParticipant(userId: string, groupId: string){
        this.repo.deleteParticipant(userId, groupId).subscribe(
            data =>  this.participant.splice(this.participant
                .findIndex(c => c.userId == userId && c.groupId == groupId),1)
        );
    }
}