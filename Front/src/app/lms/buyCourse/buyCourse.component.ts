import { Component } from "@angular/core";
import { Course } from "src/app/model/Course.model";
import { CourseRepository } from "src/app/model/repository/courseRepository";
import { Router, ActivatedRoute, NavigationEnd } from "@angular/router";
import { filter } from "rxjs/operators";

@Component({
    templateUrl: "buyCourse.template.html",
    styleUrls: ['./buyCourse.style.css']
})

export class BuyCourseComponent {

    loading: boolean = true;

    course: Course = new Course;

    constructor(private repo: CourseRepository,
        private router: Router,
        private activeRoute: ActivatedRoute) {
            router.events.pipe(filter(event => event instanceof NavigationEnd)).subscribe(
                val => {
                    this.loading = true;
                    this.getCourse(this.activeRoute.snapshot.params["id"]);
                }
            );
        }

    ngOnInit(){
    }

    getCourse(id: string){
        this.loading = true;
        this.repo.getCourse(id).subscribe(
            data => {
                this.course = data;
                this.loading = false;
            }
        );
    }
}