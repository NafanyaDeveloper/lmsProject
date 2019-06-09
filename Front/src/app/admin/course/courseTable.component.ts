import { Component, Input } from "@angular/core";
import { CourseRepository } from "src/app/model/repository/courseRepository";
import { Course } from "src/app/model/Course.model";

@Component({
    selector: "course-table",
    templateUrl: "template/courseTable.template.html"
})

export class CourseTableComponent{
    constructor(private repo: CourseRepository) {}

    ngOnInit(){
        if(this.directionId == null)
            this.getCourses();
        else
            this.getCourseByDirection(this.directionId);
    }

    @Input() directionId: string;
    
    courses: Course[];

    getCourses(){
        this.repo.getCourses().subscribe(
            data => this.courses = data,
            error => this.courses = null)
    }

    getCourseByDirection(id: string){
        this.repo.getCourseByDirection(id).subscribe(
            data => this.courses = data,
            error => this.courses = null)
    }

    deleteCourse(id: string){
        this.repo.deleteCourse(id).subscribe(
            data =>  this.courses.splice(this.courses.findIndex(c => c.id.toString() == id),1)
        )
    }
}