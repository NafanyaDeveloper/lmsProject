import { Component } from "@angular/core";
import { ParticipantRoleRepository } from "src/app/model/repository/participantRoleRepository";
import { ParticipantRole } from "src/app/model/ParticipantRole.model";

@Component({
    templateUrl: "./template/participantRoleTable.template.html"
})

export class ParticipantRoleTableComponent{
    constructor(private repo: ParticipantRoleRepository) {}

    ngOnInit(){
        this.getParticipantRoles();
    }

    participantRole: ParticipantRole[];

    getParticipantRoles(){
        this.repo.getParticipantRoles().subscribe(
            data => this.participantRole = data,
            error => this.participantRole = null)
    }

    deleteParticipantRole(id: string){
        this.repo.deleteParticipantRole(id).subscribe(
            data =>  this.participantRole.splice(this.participantRole.findIndex(d => d.id == id),1)
        )
    }
}