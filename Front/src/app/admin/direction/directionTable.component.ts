import { Component } from "@angular/core";
import { DirectionRepository } from "src/app/model/repository/directionRepository";
import { Direction } from "src/app/model/Direction.model";

@Component({
    templateUrl: "./template/directionTable.template.html"
})

export class DirectionTableComponent{
    constructor(private repo: DirectionRepository) {}

    ngOnInit(){
        this.getDirections();
    }

    directions: Direction[];

    loading: boolean = true;

    getDirections(){
        this.repo.getDirections().subscribe(
            data => {
                this.directions = data;
                this.loading = false;
            },
            error => this.directions = null)
    }

    deleteDirection(id: string){
        this.repo.deleteDirection(id).subscribe(
            data =>  this.directions.splice(this.directions.findIndex(d => d.id.toString() == id),1)
        )
    }
}