import {  Injectable  } from "@angular/core";
import { Repository } from "./repository";
import { Observable } from "rxjs";
import { HttpClient } from '@angular/common/http';
import { ParticipantRole } from "../ParticipantRole.model";

@Injectable()
export class ParticipantRoleRepository{
    constructor(private repo: Repository, private http: HttpClient) {}

    getParticipantRoles(): Observable<ParticipantRole[]> {
        return this.http.get<ParticipantRole[]>(this.repo.participantRoleAPI);  
    }

    getParticipantRole(id: string): Observable<ParticipantRole> {
        return this.http.get<ParticipantRole>(this.repo.participantRoleAPI + id);
    }

    createParticipantRole(participantRole: ParticipantRole): Observable<ParticipantRole>{
        return this.http.post<ParticipantRole>(this.repo.participantRoleAPI, participantRole);
    }

    updateParticipantRole(participantRole: ParticipantRole): Observable<ParticipantRole>{
        return this.http.put<ParticipantRole>(this.repo.participantRoleAPI, participantRole);
    }

    deleteParticipantRole(id: string): Observable<boolean>{
        return this.http.delete<boolean>(this.repo.participantRoleAPI + id);
    }
}