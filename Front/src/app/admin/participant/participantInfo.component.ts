import { Component, Input } from "@angular/core";
import { Router, ActivatedRoute } from "@angular/router";
import { ParticipantRepository } from "src/app/model/repository/participantRepository";
import { Participant } from "src/app/model/Participant.model";


@Component({
    templateUrl: "template/participantInfo.template.html"
})

export class ParticipantInfoComponent{
    constructor(private repo: ParticipantRepository,
        private router: Router,
        activeRoute: ActivatedRoute) {
        this.getParticipant(activeRoute.snapshot.params["userId"],
        activeRoute.snapshot.params["groupId"]);
    }

    participant: Participant = new Participant(); 

    getParticipant(userId: string, groupId: string){
        this.repo.getParticipant(userId, groupId).subscribe(
            data => this.participant = data
        );
    }
}