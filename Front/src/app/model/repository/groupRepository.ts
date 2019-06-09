import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Repository } from './repository';
import { Group } from '../Group.model';
import { Response } from '../response/response.model';

@Injectable()
export class GroupRepository{
    constructor(private http: HttpClient, private repo: Repository) {}

    getGroups(): Observable<Group[]>{
        return this.http.get<Group[]>(this.repo.groupAPI);
    }

    getGroup(id: string): Observable<Group>{
        return this.http.get<Group>(this.repo.groupAPI + id);
    }

    getGroupByCourse(id: string): Observable<Group[]>{
        return this.http.get<Group[]>(this.repo.groupAPI + 'course/' + id);
    }

    createGroup(group: Group): Observable<Group>{
        return this.http.post<Group>(this.repo.groupAPI, group);
    }

    updateGroup(group: Group): Observable<Group>{
        return this.http.put<Group>(this.repo.groupAPI, group);
    }

    deleteGroup(id: string): Observable<boolean>{
        return this.http.delete<boolean>(this.repo.groupAPI + id);
    }
}