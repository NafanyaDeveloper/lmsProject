import { Component, Input } from "@angular/core";
import { QuestionRepository } from "src/app/model/repository/questionRepository";
import { Question } from "src/app/model/Question.model";

@Component({
    selector: "question-table",
    templateUrl: "template/questionTable.template.html"
})

export class QuestionTableComponent{
    constructor(private repo: QuestionRepository) {}

    ngOnInit(){
        if(this.blockId == null)
            this.getQuestions();
        else
            this.getQuestionByBlock(this.blockId);
    }

    @Input() blockId: string;
    
    questions: Question[];

    getQuestions(){
        this.repo.getQuestions().subscribe(
            data => this.questions = data,
            error => this.questions = null)
    }

    getQuestionByBlock(id: string){
        this.repo.getQuestionByBlock(id).subscribe(
            data => this.questions = data,
            error => this.questions = null)
    }

    deleteQuestion(id: string){
        this.repo.deleteQuestion(id).subscribe(
            data =>  this.questions.splice(this.questions.findIndex(c => c.id.toString() == id),1)
        )
    }
}