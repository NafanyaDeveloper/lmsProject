import { Component, Input } from "@angular/core";
import { AdministrationRepository } from "src/app/model/repository/administrationRepository";
import { Administration } from "src/app/model/Administration.model";

@Component({
    selector: "administration-table",
    templateUrl: "template/administrationTable.template.html"
})

export class AdministrationTableComponent{
    constructor(private repo: AdministrationRepository) {}

    ngOnInit(){
        if(this.directionId != null)
            this.getAdministrationByDirection(this.directionId);
        else if (this.userId != null)
            this.getAdministrationByUser(this.userId);
        else if (this.roleId != null)
            this.getAdministrationByRole(this.roleId);
        else
            this.getAdministrations();
    }

    @Input() directionId: string;
    @Input() userId: string;
    @Input() roleId: string;

    
    administration: Administration[];

    getAdministrations(){
        this.repo.getAdministrations().subscribe(
            data => this.administration = data,
            error => this.administration = null)
    }

    getAdministrationByDirection(id: string){
        this.repo.getAdministrationByDirection(id).subscribe(
            data => this.administration = data,
            error => this.administration = null)
    }

    getAdministrationByUser(id: string){
        this.repo.getAdministrationByUser(id).subscribe(
            data => this.administration = data,
            error => this.administration = null)
    }

    getAdministrationByRole(id: string){
        this.repo.getAdministrationByRole(id).subscribe(
            data => this.administration = data,
            error => this.administration = null)
    }

    deleteAdministration(userId: string, directionId: string){
        this.repo.deleteAdministration(userId, directionId).subscribe(
            data =>  this.administration.splice(this.administration
                .findIndex(c => c.userId == userId && c.directionId == directionId),1)
        );
    }
}