import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Repository } from "./repository";
import { Observable } from "rxjs";
import { Response } from "../response/response.model";
import { Question } from "../Question.model";

@Injectable()
export class QuestionRepository{
    constructor(private http: HttpClient, private repo: Repository) {}

    getQuestions(): Observable<Question[]>{
        return this.http.get<Question[]>(this.repo.questionAPI);
    }

    getQuestion(id: string): Observable<Question>{
        return this.http.get<Question>(this.repo.questionAPI + id);
    }

    getQuestionByBlock(id: string): Observable<Question[]>{
        return this.http.get<Question[]>(this.repo.questionAPI + 'block/' + id);
    }

    createQuestion(question: Question): Observable<Question>{
        return this.http.post<Question>(this.repo.questionAPI, question);
    }

    updateQuestion(question: Question): Observable<Question>{
        return this.http.put<Question>(this.repo.questionAPI, question);
    }

    deleteQuestion(id: string): Observable<boolean>{
        return this.http.delete<boolean>(this.repo.questionAPI + id);
    }
}