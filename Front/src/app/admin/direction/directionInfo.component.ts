import { Component } from "@angular/core";
import { DirectionRepository } from "src/app/model/repository/directionRepository";
import { Router, ActivatedRoute } from "@angular/router";
import { Direction } from "src/app/model/Direction.model";
import { CourseRepository } from "src/app/model/repository/courseRepository";

@Component({
    templateUrl: "template/directionInfo.template.html"
})

export class DirectionInfoComponent{
    constructor(private repo: DirectionRepository, private repoC: CourseRepository,
        private router: Router,
        activeRoute: ActivatedRoute) {
        this.id = activeRoute.snapshot.params["id"];
        this.getDirection(this.id);
    }

    direction: Direction = new Direction; 
    id: string;

    getDirection(id: string){
        this.repo.getDirection(id).subscribe(
            data => this.direction = data
        );
    }

    deleteCourse(id: string){
        this.repoC.deleteCourse(id).subscribe(
            data =>  this.direction.courses.splice(this.direction.courses.findIndex(c => c.id.toString() == id),1)
        );
    }
}