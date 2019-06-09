import { Component, Input } from "@angular/core";
import { Router, ActivatedRoute } from "@angular/router";
import { QuestionRepository } from "src/app/model/repository/questionRepository";
import { Question } from "src/app/model/Question.model";
import { GroupRepository } from "src/app/model/repository/groupRepository";
import { PageRepository } from "src/app/model/repository/pageRepository";

@Component({
    templateUrl: "template/questionInfo.template.html"
})

export class QuestionInfoComponent{
    constructor(private repo: QuestionRepository,
        private router: Router,
        activeRoute: ActivatedRoute) {
        this.id = activeRoute.snapshot.params["id"];
        this.getQuestion(this.id);
    }

    question: Question = new Question(); 
    id: string;

    getQuestion(id: string){
        this.repo.getQuestion(id).subscribe(
            data => this.question = data
        );
    }
}