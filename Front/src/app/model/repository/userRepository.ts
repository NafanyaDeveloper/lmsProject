import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Repository } from "./repository";
import { Observable } from "rxjs";
import { Response } from "../response/response.model";
import { User } from "../User.model";

@Injectable()
export class UserRepository{
    constructor(private http: HttpClient, private repo: Repository) {}

    getUsers(): Observable<User[]>{
        return this.http.get<User[]>(this.repo.userAPI);
    }

    getUser(id: string): Observable<User>{
        return this.http.get<User>(this.repo.userAPI + id);
    }

    createUser(user: User): Observable<User>{
        return this.http.post<User>(this.repo.userAPI, user);
    }

    updateUser(user: User): Observable<User>{
        return this.http.put<User>(this.repo.userAPI, user);
    }

    deleteUser(id: string): Observable<boolean>{
        return this.http.delete<boolean>(this.repo.userAPI + id);
    }
}