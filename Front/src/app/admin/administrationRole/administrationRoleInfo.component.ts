import { Component } from "@angular/core";
import { AdministrationRoleRepository } from "src/app/model/repository/administrationRoleRepository";
import { Router, ActivatedRoute } from "@angular/router";
import { AdministrationRole } from "src/app/model/AdministrationRole.model";

@Component({
    templateUrl: "template/administrationRoleInfo.template.html"
})

export class AdministrationRoleInfoComponent{
    constructor(private repo: AdministrationRoleRepository, 
        private router: Router,
        activeRoute: ActivatedRoute) {
        this.id = activeRoute.snapshot.params["id"];
        this.getAdministrationRole(this.id);
    }

    administrationRole: AdministrationRole = new AdministrationRole; 
    id: string;

    getAdministrationRole(id: string){
        this.repo.getAdministrationRole(id).subscribe(
            data => this.administrationRole = data
        );
    }
}