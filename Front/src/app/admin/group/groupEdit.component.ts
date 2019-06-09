import { Component } from "@angular/core";
import { Router, ActivatedRoute } from "@angular/router";
import { NgForm } from "@angular/forms";
import { Course } from "src/app/model/Course.model";
import { CourseRepository } from "src/app/model/repository/courseRepository";
import { Group } from "src/app/model/Group.model";
import { GroupRepository } from "src/app/model/repository/groupRepository";

@Component({
    templateUrl: "template/groupEditor.template.html"
})

export class GroupEditorComponent {
    editing: boolean = false;
    group: Group = new Group();
    courses: Course[];

    constructor(private repo: GroupRepository, private repoC: CourseRepository,
        private router: Router,
        activeRoute: ActivatedRoute) {

        this.editing = activeRoute.snapshot.params["mode"] == "edit";
        if (this.editing) {
            this.getGroup(activeRoute.snapshot.params["id"]);
        }
    }

    ngOnInit(){
        this.getCourses();
    }
    
    getGroup(id: string){
        this.repo.getGroup(id).subscribe(
            data => this.group = data
        );
    }

    getCourses(){
        this.repoC.getCourses().subscribe(
            data => this.courses = data
        );
    }

    save(form: NgForm) {
        if (this.editing){
            this.repo.updateGroup(Object.assign(this.group, form.value)).subscribe(
                data => this.router.navigateByUrl("/admin/main/groups"),
                error => this.router.navigateByUrl("/admin/main/groups")
            );
        } else {
            this.repo.createGroup(Object.assign(this.group, form.value)).subscribe(
                data => this.router.navigateByUrl("/admin/main/groups"),
                error => this.router.navigateByUrl("/admin/main/groups")
            );
        }
    }
}