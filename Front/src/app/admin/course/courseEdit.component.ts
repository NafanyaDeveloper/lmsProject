import { Component } from "@angular/core";
import { Direction } from "src/app/model/Direction.model";
import { DirectionRepository } from "src/app/model/repository/directionRepository";
import { Router, ActivatedRoute } from "@angular/router";
import { NgForm } from "@angular/forms";
import { Course } from "src/app/model/Course.model";
import { CourseRepository } from "src/app/model/repository/courseRepository";

@Component({
    templateUrl: "template/courseEditor.template.html"
})

export class CourseEditorComponent {
    editing: boolean = false;
    course: Course = new Course();
    directions: Direction[];

    constructor(private repo: CourseRepository, private repoD: DirectionRepository,
        private router: Router,
        activeRoute: ActivatedRoute) {

        this.editing = activeRoute.snapshot.params["mode"] == "edit";
        if (this.editing) {
            this.getCourse(activeRoute.snapshot.params["id"]);
        }
    }

    ngOnInit(){
        this.getDirections();
    }
    
    getDirections(){
        this.repoD.getDirections().subscribe(
            data => this.directions = data
        );
    }

    getCourse(id: string){
        this.repo.getCourse(id).subscribe(
            data => this.course = data
        );
    }

    save(form: NgForm) {
        if (this.editing){
            this.repo.updateCourse(Object.assign(this.course, form.value)).subscribe(
                data => this.router.navigateByUrl("/admin/main/courses"),
                error => this.router.navigateByUrl("/admin/main/courses")
            );
        } else {
            this.repo.createCourse(Object.assign(this.course, form.value)).subscribe(
                data => this.router.navigateByUrl("/admin/main/courses"),
                error => this.router.navigateByUrl("/admin/main/courses")
            );
        }
    }

    imgLoaded(event){
        let reader = new FileReader();
        if(event.target.files && event.target.files.length > 0) {
            let file = event.target.files[0];
            reader.readAsDataURL(file);
            reader.onload = () => {
                    this.course.loadImg = reader.result.toString().split(',')[1];
                };
        };
    }
}