import { Component } from "@angular/core";
import { Direction } from "src/app/model/Direction.model";
import { DirectionRepository } from "src/app/model/repository/directionRepository";
import { Router, ActivatedRoute } from "@angular/router";
import { NgForm } from "@angular/forms";
import { Administration } from "src/app/model/Administration.model";
import { AdministrationRepository } from "src/app/model/repository/administrationRepository";
import { UserRepository } from "src/app/model/repository/userRepository";
import { AdministrationRoleRepository } from "src/app/model/repository/administrationRoleRepository";
import { AdministrationRole } from "src/app/model/AdministrationRole.model";
import { User } from "src/app/model/User.model";

@Component({
    templateUrl: "template/administrationEditor.template.html"
})

export class AdministrationEditorComponent {
    editing: boolean = false;
    administration: Administration = new Administration();
    directions: Direction[];
    users: User[];
    roles: AdministrationRole[];

    constructor(private repo: AdministrationRepository, private repoD: DirectionRepository,
        private repoU: UserRepository, private repoR: AdministrationRoleRepository,
        private router: Router,
        activeRoute: ActivatedRoute) {

        this.editing = activeRoute.snapshot.params["mode"] == "edit";
        if (this.editing) {
            this.getAdministration(activeRoute.snapshot.params["userId"],
            activeRoute.snapshot.params["directionId"]);
        }
    }

    ngOnInit(){
        this.getDirections();
        this.getUsers();
        this.getRoles();
    }
    
    getDirections(){
        this.repoD.getDirections().subscribe(
            data => this.directions = data
        );
    }

    getUsers(){
        this.repoU.getUsers().subscribe(
            data => this.users = data
        );
    }

    getRoles(){
        this.repoR.getAdministrationRoles().subscribe(
            data => this.roles = data
        );
    }

    getAdministration(userId: string, directionId: string){
        this.repo.getAdministration(userId, directionId).subscribe(
            data => this.administration = data
        );
    }

    save(form: NgForm) {
        if (this.editing){
            this.repo.updateAdministration(Object.assign(this.administration, form.value)).subscribe(
                data => this.router.navigateByUrl("/admin/main/administrations"),
                error => this.router.navigateByUrl("/admin/main/administrations")
            );
        } else {
            this.repo.createAdministration(Object.assign(this.administration, form.value)).subscribe(
                data => this.router.navigateByUrl("/admin/main/administrations"),
                error => this.router.navigateByUrl("/admin/main/administrations")
            );
        }
    }
}