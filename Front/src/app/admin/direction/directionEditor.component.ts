import { Component } from "@angular/core";
import { Direction } from "src/app/model/Direction.model";
import { DirectionRepository } from "src/app/model/repository/directionRepository";
import { Router, ActivatedRoute } from "@angular/router";
import { NgForm } from "@angular/forms";

@Component({
    templateUrl: "template/directionEditor.template.html"
})

export class DirectionEditorComponent {
    editing: boolean = false;
    direction: Direction = new Direction();

    constructor(private repo: DirectionRepository,
        private router: Router,
        activeRoute: ActivatedRoute) {

        this.editing = activeRoute.snapshot.params["mode"] == "edit";
        if (this.editing) {
            this.getDirection(activeRoute.snapshot.params["id"]);
        }
    }

    getDirection(id: string){
        this.repo.getDirection(id).subscribe(
            data => this.direction = data
        );
    }

    save(form: NgForm) {
        if (this.editing){
            this.repo.updateDirection(Object.assign(this.direction, form.value)).subscribe(
                data => this.router.navigateByUrl("/admin/main/directions"),
                error => this.router.navigateByUrl("/admin/main/directions")
            );
        } else {
            this.repo.createDirection(Object.assign(this.direction, form.value)).subscribe(
                data => this.router.navigateByUrl("/admin/main/directions"),
                error => this.router.navigateByUrl("/admin/main/directions")
            );
        }
    }

    imgLoaded(event){
        let reader = new FileReader();
        if(event.target.files && event.target.files.length > 0) {
            let file = event.target.files[0];
            reader.readAsDataURL(file);
            reader.onload = () => {
                    this.direction.loadImg = reader.result.toString().split(',')[1];
                };
        };
    }
}
