import { Component, Input } from "@angular/core";
import { Router, ActivatedRoute } from "@angular/router";
import { AnswerRepository } from "src/app/model/repository/answerRepository";
import { Answer } from "src/app/model/Answer.model";

@Component({
    templateUrl: "template/answerInfo.template.html"
})

export class AnswerInfoComponent{
    constructor(private repo: AnswerRepository,
        private router: Router,
        activeRoute: ActivatedRoute) {
        this.id = activeRoute.snapshot.params["id"];
        this.getAnswer(this.id);
    }

    answer: Answer = new Answer(); 
    id: string;

    getAnswer(id: string){
        this.repo.getAnswer(id).subscribe(
            data => this.answer = data
        );
    }
}