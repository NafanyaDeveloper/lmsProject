import { Component } from "@angular/core";
import { AdministrationRole } from "src/app/model/AdministrationRole.model";
import { AdministrationRoleRepository } from "src/app/model/repository/administrationRoleRepository";
import { Router, ActivatedRoute } from "@angular/router";
import { NgForm } from "@angular/forms";

@Component({
    templateUrl: "template/administrationRoleEditor.template.html"
})

export class AdministrationRoleEditorComponent {
    editing: boolean = false;
    administrationRole: AdministrationRole = new AdministrationRole();

    constructor(private repo: AdministrationRoleRepository, 
        private router: Router,
        activeRoute: ActivatedRoute) {

        this.editing = activeRoute.snapshot.params["mode"] == "edit";
        if (this.editing) {
            this.getAdministrationRole(activeRoute.snapshot.params["id"]);
        }
    }

    ngOnInit(){
    }

    getAdministrationRole(id: string){
        this.repo.getAdministrationRole(id).subscribe(
            data => this.administrationRole = data
        );
    }

    save(form: NgForm) {
        if (this.editing){
            this.repo.updateAdministrationRole(Object.assign(this.administrationRole, form.value)).subscribe(
                data => this.router.navigateByUrl("/admin/main/administrationRoles"),
                error => this.router.navigateByUrl("/admin/main/administrationRoles")
            );
        } else {
            this.repo.createAdministrationRole(Object.assign(this.administrationRole, form.value)).subscribe(
                data => this.router.navigateByUrl("/admin/main/administrationRoles"),
                error => this.router.navigateByUrl("/admin/main/administrationRoles")
            );
        }
    }
}
