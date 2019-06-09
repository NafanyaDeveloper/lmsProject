import { Component, Input } from "@angular/core";
import { Router, ActivatedRoute } from "@angular/router";
import { AdministrationRepository } from "src/app/model/repository/administrationRepository";
import { Administration } from "src/app/model/Administration.model";


@Component({
    templateUrl: "template/AdministrationInfo.template.html"
})

export class AdministrationInfoComponent{
    constructor(private repo: AdministrationRepository,
        private router: Router,
        activeRoute: ActivatedRoute) {
        this.getAdministration(activeRoute.snapshot.params["userId"],
        activeRoute.snapshot.params["directionId"]);
    }

    administration: Administration = new Administration(); 

    getAdministration(userId: string, directionId: string){
        this.repo.getAdministration(userId, directionId).subscribe(
            data => this.administration = data
        );
    }
}