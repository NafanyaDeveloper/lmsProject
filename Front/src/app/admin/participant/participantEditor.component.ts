import { Component } from "@angular/core";
import { GroupRepository } from "src/app/model/repository/groupRepository";
import { Router, ActivatedRoute } from "@angular/router";
import { NgForm } from "@angular/forms";
import { Participant } from "src/app/model/Participant.model";
import { ParticipantRepository } from "src/app/model/repository/participantRepository";
import { UserRepository } from "src/app/model/repository/userRepository";
import { ParticipantRoleRepository } from "src/app/model/repository/participantRoleRepository";
import { ParticipantRole } from "src/app/model/ParticipantRole.model";
import { User } from "src/app/model/User.model";
import { Group } from "src/app/model/Group.model";

@Component({
    templateUrl: "template/participantEditor.template.html"
})

export class ParticipantEditorComponent {
    editing: boolean = false;
    participant: Participant = new Participant();
    groups: Group[];
    users: User[];
    roles: ParticipantRole[];

    constructor(private repo: ParticipantRepository, private repoG: GroupRepository,
        private repoU: UserRepository, private repoR: ParticipantRoleRepository,
        private router: Router,
        activeRoute: ActivatedRoute) {

        this.editing = activeRoute.snapshot.params["mode"] == "edit";
        if (this.editing) {
            this.getParticipant(activeRoute.snapshot.params["userId"],
            activeRoute.snapshot.params["groupId"]);
        }
    }

    ngOnInit(){
        this.getGroups();
        this.getUsers();
        this.getRoles();
    }
    
    getGroups(){
        this.repoG.getGroups().subscribe(
            data => this.groups = data
        );
    }

    getUsers(){
        this.repoU.getUsers().subscribe(
            data => this.users = data
        );
    }

    getRoles(){
        this.repoR.getParticipantRoles().subscribe(
            data => this.roles = data
        );
    }

    getParticipant(userId: string, groupId: string){
        this.repo.getParticipant(userId, groupId).subscribe(
            data => this.participant = data
        );
    }

    save(form: NgForm) {
        if (this.editing){
            this.repo.updateParticipant(Object.assign(this.participant, form.value)).subscribe(
                data => this.router.navigateByUrl("/admin/main/participants"),
                error => this.router.navigateByUrl("/admin/main/participants")
            );
        } else {
            this.repo.createParticipant(Object.assign(this.participant, form.value)).subscribe(
                data => this.router.navigateByUrl("/admin/main/participants"),
                error => this.router.navigateByUrl("/admin/main/participants")
            );
        }
    }
}