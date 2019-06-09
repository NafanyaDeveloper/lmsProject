import { Component, Input } from "@angular/core";
import { AnswerRepository } from "src/app/model/repository/answerRepository";
import { Answer } from "src/app/model/Answer.model";

@Component({
    selector: "answer-table",
    templateUrl: "template/answerTable.template.html"
})

export class AnswerTableComponent{
    constructor(private repo: AnswerRepository) {}

    ngOnInit(){
        if(this.questionId == null)
            this.getAnswers();
        else
            this.getAnswerByQuestion(this.questionId);
    }

    @Input() questionId: string;
    
    answers: Answer[];

    getAnswers(){
        this.repo.getAnswers().subscribe(
            data => this.answers = data,
            error => this.answers = null)
    }

    getAnswerByQuestion(id: string){
        this.repo.getAnswerByQuestion(id).subscribe(
            data => this.answers = data,
            error => this.answers = null)
    }

    deleteAnswer(id: string){
        this.repo.deleteAnswer(id).subscribe(
            data =>  this.answers.splice(this.answers.findIndex(c => c.id.toString() == id),1)
        )
    }
}