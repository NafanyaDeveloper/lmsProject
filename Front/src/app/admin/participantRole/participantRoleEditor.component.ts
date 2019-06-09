import { Component } from "@angular/core";
import { ParticipantRole } from "src/app/model/ParticipantRole.model";
import { ParticipantRoleRepository } from "src/app/model/repository/participantRoleRepository";
import { Router, ActivatedRoute } from "@angular/router";
import { NgForm } from "@angular/forms";


@Component({
    templateUrl: "template/ParticipantRoleEditor.template.html"
})

export class ParticipantRoleEditorComponent {
    editing: boolean = false;
    participantRole: ParticipantRole = new ParticipantRole();


    constructor(private repo: ParticipantRoleRepository,
        private router: Router,
        activeRoute: ActivatedRoute) {

        this.editing = activeRoute.snapshot.params["mode"] == "edit";
        if (this.editing) {
            this.getParticipantRole(activeRoute.snapshot.params["id"]);
        }
    }

    ngOnInit(){
    }

    getParticipantRole(id: string){
        this.repo.getParticipantRole(id).subscribe(
            data => this.participantRole = data
        );
    }

    save(form: NgForm) {
        if (this.editing){
            this.repo.updateParticipantRole(Object.assign(this.participantRole, form.value)).subscribe(
                data => this.router.navigateByUrl("/admin/main/participantRoles"),
                error => this.router.navigateByUrl("/admin/main/participantRoles")
            );
        } else {
            this.repo.createParticipantRole(Object.assign(this.participantRole, form.value)).subscribe(
                data => this.router.navigateByUrl("/admin/main/participantRoles"),
                error => this.router.navigateByUrl("/admin/main/participantRoles")
            );
        }
    }
}
