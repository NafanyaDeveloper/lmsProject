import {  Injectable  } from "@angular/core";
import { Repository } from "./repository";
import { Direction } from "../Direction.model";
import { Observable } from "rxjs";
import { HttpClient } from '@angular/common/http';
import { Response } from "../response/response.model";
import { directiveCreate } from "@angular/core/src/render3/instructions";
import { ValueConverter } from "@angular/compiler/src/render3/view/template";

@Injectable()
export class DirectionRepository{
    constructor(private repo: Repository, private http: HttpClient) {}

    getDirections(): Observable<Direction[]> {
        return this.http.get<Direction[]>(this.repo.directionAPI);  
    }

    getDirection(id: string): Observable<Direction> {
        return this.http.get<Direction>(this.repo.directionAPI + id);
    }

    createDirection(direction: Direction): Observable<Direction>{
        return this.http.post<Direction>(this.repo.directionAPI, direction);
    }

    updateDirection(direction: Direction): Observable<Direction>{
        return this.http.put<Direction>(this.repo.directionAPI, direction);
    }

    deleteDirection(id: string): Observable<boolean>{
        return this.http.delete<boolean>(this.repo.directionAPI + id);
    }
}