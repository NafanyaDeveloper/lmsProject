import { Component, Input } from "@angular/core";
import { Router, ActivatedRoute } from "@angular/router";
import { CourseRepository } from "src/app/model/repository/courseRepository";
import { Course } from "src/app/model/Course.model";

@Component({
    templateUrl: "template/courseInfo.template.html"
})

export class CourseInfoComponent{
    constructor(private repo: CourseRepository,
        private router: Router,
        activeRoute: ActivatedRoute) {
        this.id = activeRoute.snapshot.params["id"];
        this.getCourse(this.id);
    }

    course: Course = new Course(); 
    id: string;

    getCourse(id: string){
        this.repo.getCourse(id).subscribe(
            data => this.course = data
        );
    }
}