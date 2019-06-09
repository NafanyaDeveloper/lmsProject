import {  Injectable  } from "@angular/core";
import { Repository } from "./repository";
import { Observable } from "rxjs";
import { HttpClient } from '@angular/common/http';
import { AdministrationRole } from "../AdministrationRole.model";

@Injectable()
export class AdministrationRoleRepository{
    constructor(private repo: Repository, private http: HttpClient) {}

    getAdministrationRoles(): Observable<AdministrationRole[]> {
        return this.http.get<AdministrationRole[]>(this.repo.administrationRoleAPI);  
    }

    getAdministrationRole(id: string): Observable<AdministrationRole> {
        return this.http.get<AdministrationRole>(this.repo.administrationRoleAPI + id);
    }

    createAdministrationRole(administrationRole: AdministrationRole): Observable<AdministrationRole>{
        return this.http.post<AdministrationRole>(this.repo.administrationRoleAPI, administrationRole);
    }

    updateAdministrationRole(administrationRole: AdministrationRole): Observable<AdministrationRole>{
        return this.http.put<AdministrationRole>(this.repo.administrationRoleAPI, administrationRole);
    }

    deleteAdministrationRole(id: string): Observable<boolean>{
        return this.http.delete<boolean>(this.repo.administrationRoleAPI + id);
    }
}