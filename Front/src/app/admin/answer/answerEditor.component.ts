import { Component } from "@angular/core";
import { Router, ActivatedRoute } from "@angular/router";
import { NgForm } from "@angular/forms";
import { Answer } from "src/app/model/Answer.model";
import { AnswerRepository } from "src/app/model/repository/answerRepository";
import { Question } from "src/app/model/Question.model";
import { QuestionRepository } from "src/app/model/repository/questionRepository";

@Component({
    templateUrl: "template/answerEditor.template.html"
})

export class AnswerEditorComponent {
    editing: boolean = false;
    answer: Answer = new Answer();
    questions: Question[];

    constructor(private repo: AnswerRepository, private repoQ: QuestionRepository,
        private router: Router,
        activeRoute: ActivatedRoute) {

        this.editing = activeRoute.snapshot.params["mode"] == "edit";
        if (this.editing) {
            this.getAnswer(activeRoute.snapshot.params["id"]);
        }
    }

    ngOnInit(){
        this.getQuestions();
    }
    
    getQuestions(){
        this.repoQ.getQuestions().subscribe(
            data => this.questions = data
        );
    }

    getAnswer(id: string){
        this.repo.getAnswer(id).subscribe(
            data => this.answer = data
        );
    }

    save(form: NgForm) {
        if (this.editing){
            this.repo.updateAnswer(Object.assign(this.answer, form.value)).subscribe(
                data => this.router.navigateByUrl("/admin/main/answers"),
                error => this.router.navigateByUrl("/admin/main/answers")
            );
        } else {
            this.repo.createAnswer(Object.assign(this.answer, form.value)).subscribe(
                data => this.router.navigateByUrl("/admin/main/answers"),
                error => this.router.navigateByUrl("/admin/main/answers")
            );
        }
    }
}