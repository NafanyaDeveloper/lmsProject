import { Component } from "@angular/core";
import { UserRepository } from "src/app/model/repository/userRepository";
import { Router, ActivatedRoute } from "@angular/router";
import { User } from "src/app/model/User.model";


@Component({
    templateUrl: "template/userInfo.template.html"
})

export class UserInfoComponent{
    constructor(private repo: UserRepository, 
        private router: Router,
        activeRoute: ActivatedRoute) {
        this.id = activeRoute.snapshot.params["id"];
        this.getUser(this.id);
    }

    user: User = new User; 
    id: string;

    getUser(id: string){
        this.repo.getUser(id).subscribe(
            data => this.user = data
        );
    }
}