import { Component, Input } from "@angular/core";
import { PageRepository } from "src/app/model/repository/pageRepository";
import { Page } from "src/app/model/Page.model";

@Component({
    selector: "page-table",
    templateUrl: "template/pageTable.template.html"
})

export class PageTableComponent{
    constructor(private repo: PageRepository) {}

    ngOnInit(){
        if (this.courseId == null)
            this.getPages();
        else
            this.getPageByCourse(this.courseId);
    }

    @Input() courseId: string;

    pages: Page[];

    getPages(){
        this.repo.getPages().subscribe(
            data => this.pages = data,
            error => this.pages = null);
    }

    getPageByCourse(id:string){
        this.repo.getPageByCourse(id).subscribe(
            data => this.pages = data,
            error => this.pages = null);
    }

    deletePage(id: string){
        this.repo.deletePage(id).subscribe(
            data =>  this.pages.splice(this.pages.findIndex(c => c.id == id),1)
        );
    }
}