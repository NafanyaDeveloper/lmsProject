import { Component } from "@angular/core";
import { Router, ActivatedRoute } from "@angular/router";
import { NgForm } from "@angular/forms";
import { Question } from "src/app/model/Question.model";
import { QuestionRepository } from "src/app/model/repository/questionRepository";
import { BlockRepository } from "src/app/model/repository/blockRepository";
import { Block } from "src/app/model/Block.model";

@Component({
    templateUrl: "template/questionEditor.template.html"
})

export class QuestionEditorComponent {
    editing: boolean = false;
    question: Question = new Question();
    blocks: Block[];

    constructor(private repo: QuestionRepository, private repoB: BlockRepository,
        private router: Router,
        activeRoute: ActivatedRoute) {

        this.editing = activeRoute.snapshot.params["mode"] == "edit";
        if (this.editing) {
            this.getQuestion(activeRoute.snapshot.params["id"]);
        }
    }

    ngOnInit(){
        this.getPages();
    }
    
    getPages(){
        this.repoB.getBlocks().subscribe(
            data => this.blocks = data.filter(x => x.blockTypeId == "7fe699d4-5152-4e5c-1c2b-08d6b9170738")
        );
    }

    getQuestion(id: string){
        this.repo.getQuestion(id).subscribe(
            data => this.question = data
        );
    }

    save(form: NgForm) {
        if (this.editing){
            this.repo.updateQuestion(Object.assign(this.question, form.value)).subscribe(
                data => this.router.navigateByUrl("/admin/main/questions"),
                error => this.router.navigateByUrl("/admin/main/questions")
            );
        } else {
            this.repo.createQuestion(Object.assign(this.question, form.value)).subscribe(
                data => this.router.navigateByUrl("/admin/main/questions"),
                error => this.router.navigateByUrl("/admin/main/questions")
            );
        }
    }
}