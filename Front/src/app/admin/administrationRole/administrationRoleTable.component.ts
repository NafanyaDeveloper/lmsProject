import { Component } from "@angular/core";
import { AdministrationRoleRepository } from "src/app/model/repository/administrationRoleRepository";
import { AdministrationRole } from "src/app/model/AdministrationRole.model";

@Component({
    templateUrl: "./template/administrationRoleTable.template.html"
})

export class AdministrationRoleTableComponent{
    constructor(private repo: AdministrationRoleRepository) {}

    ngOnInit(){
        this.getAdministrationRoles();
    }

    administrationRole: AdministrationRole[];

    getAdministrationRoles(){
        this.repo.getAdministrationRoles().subscribe(
            data => this.administrationRole = data,
            error => this.administrationRole = null)
    }

    deleteAdministrationRole(id: string){
        this.repo.deleteAdministrationRole(id).subscribe(
            data =>  this.administrationRole.splice(this.administrationRole.findIndex(d => d.id == id),1)
        )
    }
}