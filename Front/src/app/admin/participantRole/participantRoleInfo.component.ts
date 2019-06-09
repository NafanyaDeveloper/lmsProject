import { Component } from "@angular/core";
import { ParticipantRoleRepository } from "src/app/model/repository/participantRoleRepository";
import { Router, ActivatedRoute } from "@angular/router";
import { ParticipantRole } from "src/app/model/ParticipantRole.model";

@Component({
    templateUrl: "template/participantRoleInfo.template.html"
})

export class ParticipantRoleInfoComponent{
    constructor(private repo: ParticipantRoleRepository, 
        private router: Router,
        activeRoute: ActivatedRoute) {
        this.id = activeRoute.snapshot.params["id"];
        this.getParticipantRole(this.id);
    }

    participantRole: ParticipantRole = new ParticipantRole; 
    id: string;

    getParticipantRole(id: string){
        this.repo.getParticipantRole(id).subscribe(
            data => this.participantRole = data
        );
    }
}