import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Repository } from "./repository";
import { Observable } from "rxjs";
import { Response } from "../response/response.model";
import { Answer } from "../Answer.model";

@Injectable()
export class AnswerRepository{
    constructor(private http: HttpClient, private repo: Repository) {}

    getAnswers(): Observable<Answer[]>{
        return this.http.get<Answer[]>(this.repo.answerAPI);
    }

    getAnswer(id: string): Observable<Answer>{
        return this.http.get<Answer>(this.repo.answerAPI + id);
    }

    getAnswerByQuestion(id: string): Observable<Answer[]>{
        return this.http.get<Answer[]>(this.repo.answerAPI + 'question/' + id);
    }

    createAnswer(answer: Answer): Observable<Answer>{
        return this.http.post<Answer>(this.repo.answerAPI, answer);
    }

    updateAnswer(answer: Answer): Observable<Answer>{
        return this.http.put<Answer>(this.repo.answerAPI, answer);
    }

    deleteAnswer(id: string): Observable<boolean>{
        return this.http.delete<boolean>(this.repo.answerAPI + id);
    }
}