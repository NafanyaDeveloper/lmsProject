import { Component } from "@angular/core";
import { UserRepository } from "src/app/model/repository/userRepository";
import { User } from "src/app/model/User.model";

@Component({
    templateUrl: "./template/userTable.template.html"
})

export class UserTableComponent{
    constructor(private repo: UserRepository) {}

    ngOnInit(){
        this.getUsers();
    }

    users: User[];

    getUsers(){
        this.repo.getUsers().subscribe(
            data => this.users = data,
            error => this.users = null)
    }

    deleteUser(id: string){
        this.repo.deleteUser(id).subscribe(
            data =>  this.users.splice(this.users.findIndex(u => u.id == id),1)
        )
    }
}