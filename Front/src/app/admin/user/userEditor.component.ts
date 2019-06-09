import { Component } from "@angular/core";
import { User } from "src/app/model/User.model";
import { UserRepository } from "src/app/model/repository/userRepository";
import { Router, ActivatedRoute } from "@angular/router";
import { NgForm } from "@angular/forms";

@Component({
    templateUrl: "template/userEditor.template.html"
})

export class UserEditorComponent {
    editing: boolean = false;
    user: User = new User();

    constructor(private repo: UserRepository,
        private router: Router,
        activeRoute: ActivatedRoute) {

        this.editing = activeRoute.snapshot.params["mode"] == "edit";
        if (this.editing) {
            this.getUser(activeRoute.snapshot.params["id"]);
        }
    }

    getUser(id: string){
        this.repo.getUser(id).subscribe(
            data => this.user = data
        );
    }

    save(form: NgForm) {
        if (this.editing){
            this.repo.updateUser(Object.assign(this.user, form.value)).subscribe(
                data => this.router.navigateByUrl("/admin/main/users"),
                error => this.router.navigateByUrl("/admin/main/users")
            );
        } else {
            this.repo.createUser(Object.assign(this.user, form.value)).subscribe(
                data => this.router.navigateByUrl("/admin/main/users"),
                error => this.router.navigateByUrl("/admin/main/users")
            );
        }
    }

    imgLoaded(event){
        let reader = new FileReader();
        if(event.target.files && event.target.files.length > 0) {
            let file = event.target.files[0];
            reader.readAsDataURL(file);
            reader.onload = () => {
                    this.user.loadImg = reader.result.toString().split(',')[1];
                };
        };
    }
}
