import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Repository } from "./repository";
import { Observable } from "rxjs";
import { Response } from "../response/response.model";
import { Participant } from "../Participant.model";

@Injectable()
export class ParticipantRepository{
    constructor(private http: HttpClient, private repo: Repository) {}

    getParticipants(): Observable<Participant[]>{
        return this.http.get<Participant[]>(this.repo.participantAPI);
    }

    getParticipant(userId: string, groupId: string): Observable<Participant>{
        return this.http.get<Participant>(this.repo.participantAPI + userId + '/' + groupId);
    }

    getParticipantByGroup(id: string): Observable<Participant[]>{
        return this.http.get<Participant[]>(this.repo.participantAPI + 'group/' + id);
    }

    getParticipantByUser(id: string): Observable<Participant[]>{
        return this.http.get<Participant[]>(this.repo.participantAPI + 'user/' + id);
    }

    getParticipantByRole(id: string): Observable<Participant[]>{
        return this.http.get<Participant[]>(this.repo.participantAPI + 'role/' + id);
    }

    createParticipant(participant: Participant): Observable<Participant>{
        return this.http.post<Participant>(this.repo.participantAPI, participant);
    }

    updateParticipant(participant: Participant): Observable<Participant>{
        return this.http.put<Participant>(this.repo.participantAPI, participant);
    }

    deleteParticipant(userId: string, groupId: string): Observable<boolean>{
        return this.http.delete<boolean>(this.repo.participantAPI + userId + '/' + groupId);
    }
}