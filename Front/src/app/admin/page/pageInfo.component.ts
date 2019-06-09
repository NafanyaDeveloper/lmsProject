import { Component } from "@angular/core";
import { Router, ActivatedRoute } from "@angular/router";
import { PageRepository } from "src/app/model/repository/pageRepository";
import { Page } from "src/app/model/Page.model";

@Component({
    templateUrl: "template/pageInfo.template.html"
})

export class PageInfoComponent{
    constructor(private repo: PageRepository,
        private router: Router,
        activeRoute: ActivatedRoute) {
        this.id = activeRoute.snapshot.params["id"];
        this.getPage(this.id);
    }

    page: Page = new Page();
    id: string;

    getPage(id: string){
        this.repo.getPage(id).subscribe(
            data => this.page = data
        );
    }
}