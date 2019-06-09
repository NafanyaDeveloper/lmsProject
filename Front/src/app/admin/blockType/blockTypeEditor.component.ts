import { Component } from "@angular/core";
import { BlockType } from "src/app/model/BlockType.model";
import { BlockTypeRepository } from "src/app/model/repository/blockTypeRepository";
import { Router, ActivatedRoute } from "@angular/router";
import { NgForm } from "@angular/forms";

@Component({
    templateUrl: "template/blockTypeEditor.template.html"
})

export class BlockTypeEditorComponent {
    editing: boolean = false;
    blockType: BlockType = new BlockType();

    constructor(private repo: BlockTypeRepository, 
        private router: Router,
        activeRoute: ActivatedRoute) {
        this.editing = activeRoute.snapshot.params["mode"] == "edit";
        if (this.editing) {
            this.getBlockType(activeRoute.snapshot.params["id"]);
        }
    }

    ngOnInit(){
    }

    getBlockType(id: string){
        this.repo.getBlockType(id).subscribe(
            data => this.blockType = data
        );
    }

    save(form: NgForm) {
        if (this.editing){
            this.repo.updateBlockType(Object.assign(this.blockType, form.value)).subscribe(
                data => this.router.navigateByUrl("/admin/main/blockTypes"),
                error => this.router.navigateByUrl("/admin/main/blockTypes")
            );
        } else {
            this.repo.createBlockType(Object.assign(this.blockType, form.value)).subscribe(
                data => this.router.navigateByUrl("/admin/main/blockTypes"),
                error => this.router.navigateByUrl("/admin/main/blockTypes")
            );
        }
    }
}
