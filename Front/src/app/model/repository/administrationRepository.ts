import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Repository } from "./repository";
import { Observable } from "rxjs";
import { Administration } from "../Administration.model";

@Injectable()
export class AdministrationRepository{
    constructor(private http: HttpClient, private repo: Repository) {}

    getAdministrations(): Observable<Administration[]>{
        return this.http.get<Administration[]>(this.repo.administrationAPI);
    }

    getAdministration(userId: string, directionId: string): Observable<Administration>{
        return this.http.get<Administration>(this.repo.administrationAPI + userId + '/' + directionId);
    }

    getAdministrationByDirection(id: string): Observable<Administration[]>{
        return this.http.get<Administration[]>(this.repo.administrationAPI + 'direction/' + id);
    }

    getAdministrationByUser(id: string): Observable<Administration[]>{
        return this.http.get<Administration[]>(this.repo.administrationAPI + 'user/' + id);
    }

    getAdministrationByRole(id: string): Observable<Administration[]>{
        return this.http.get<Administration[]>(this.repo.administrationAPI + 'role/' + id);
    }

    createAdministration(administration: Administration): Observable<Administration>{
        return this.http.post<Administration>(this.repo.administrationAPI, administration);
    }

    updateAdministration(administration: Administration): Observable<Administration>{
        return this.http.put<Administration>(this.repo.administrationAPI, administration);
    }

    deleteAdministration(userId: string, directionId: string): Observable<boolean>{
        return this.http.delete<boolean>(this.repo.administrationAPI + userId + '/' + directionId);
    }
}