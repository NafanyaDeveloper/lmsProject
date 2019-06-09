import { Component } from "@angular/core";
import { Router, ActivatedRoute } from "@angular/router";
import { GroupRepository } from "src/app/model/repository/groupRepository";
import { Group } from "src/app/model/Group.model";
import { ParticipantRepository } from "src/app/model/repository/participantRepository";

@Component({
    templateUrl: "template/groupInfo.template.html"
})

export class GroupInfoComponent{
    constructor(private repo: GroupRepository, private repoP: ParticipantRepository,
        private router: Router,
        activeRoute: ActivatedRoute) {
            this.id = activeRoute.snapshot.params["id"];
            this.getGroup(this.id);
    }

    group: Group = new Group();
    id: string;
    getGroup(id: string){
        this.repo.getGroup(id).subscribe(
            data => this.group = data
        );
    }

    deleteParticipant(userId: string, groupId: string){
        this.repoP.deleteParticipant(userId, groupId).subscribe(
            data =>  this.group.participant.splice(
                this.group.participant.findIndex(p => p.userId == userId && p.groupId == groupId),1)
        );
    }
}