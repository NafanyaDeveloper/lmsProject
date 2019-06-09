import { Component } from "@angular/core";
import { Router, ActivatedRoute } from "@angular/router";
import { NgForm } from "@angular/forms";
import { Course } from "src/app/model/Course.model";
import { CourseRepository } from "src/app/model/repository/courseRepository";
import { Page } from "src/app/model/Page.model";
import { PageRepository } from "src/app/model/repository/pageRepository";

@Component({
    templateUrl: "template/pageEditor.template.html"
})

export class PageEditorComponent {
    editing: boolean = false;
    page: Page = new Page();
    courses: Course[];

    constructor(private repo: PageRepository, private repoC: CourseRepository,
        private router: Router,
        activeRoute: ActivatedRoute) {

        this.editing = activeRoute.snapshot.params["mode"] == "edit";
        if (this.editing) {
            this.getPage(activeRoute.snapshot.params["id"]);
        }
    }

    ngOnInit(){
        this.getCourses();
    }
    
    getPage(id: string){
        this.repo.getPage(id).subscribe(
            data => this.page = data
        );
    }

    getCourses(){
        this.repoC.getCourses().subscribe(
            data => this.courses = data
        );
    }

    save(form: NgForm) {
        if (this.editing){
            this.repo.updatePage(Object.assign(this.page, form.value)).subscribe(
                data => this.router.navigateByUrl("/admin/main/pages"),
                error => this.router.navigateByUrl("/admin/main/pages")
            );
        } else {
            this.repo.createPage(Object.assign(this.page, form.value)).subscribe(
                data => this.router.navigateByUrl("/admin/main/pages"),
                error => this.router.navigateByUrl("/admin/main/pages")
            );
        }
    }
}