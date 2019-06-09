import { Component } from "@angular/core";
import { DirectionRepository } from "src/app/model/repository/directionRepository";
import { Router, ActivatedRoute } from "@angular/router";
import { NgForm } from "@angular/forms";
import { Block } from "src/app/model/Block.model";
import { BlockRepository } from "src/app/model/repository/blockRepository";
import { Page } from "src/app/model/Page.model";
import { BlockType } from "src/app/model/BlockType.model";
import { PageRepository } from "src/app/model/repository/pageRepository";
import { BlockTypeRepository } from "src/app/model/repository/blockTypeRepository";

@Component({
    templateUrl: "template/blockEditor.template.html"
})

export class BlockEditorComponent {
    editing: boolean = false;
    block: Block = new Block();
    pages: Page[];
    types: BlockType[];
    t: string; 

    constructor(private repo: BlockRepository, private repoP: PageRepository,
        private repoT: BlockTypeRepository,
        private router: Router,
        activeRoute: ActivatedRoute) {
        this.getTypes();
        this.getPages();
        this.editing = activeRoute.snapshot.params["mode"] == "edit";
        if (this.editing) {
            this.getBlock(activeRoute.snapshot.params["id"]);
        }
    }
    
    getPages(){
        this.repoP.getPages().subscribe(
            data => this.pages = data
        );
    }

    getTypes(){
        this.repoT.getBlockTypes().subscribe(
            data => this.types = data
        );
    }

    getBlock(id: string){
        this.repo.getBlock(id).subscribe(
            data => {
                this.block = data;
                let n = this.types.findIndex(c => c.id.toString() == this.block.blockTypeId);
                this.t = this.types[n].name;
            }
        );
    }

    save(form: NgForm) {
        if (this.editing){
            this.repo.updateBlock(Object.assign(this.block, form.value)).subscribe(
                data => this.router.navigateByUrl("/admin/main/blocks"),
                error => this.router.navigateByUrl("/admin/main/blocks")
            );
        } else {
            this.repo.createBlock(Object.assign(this.block, form.value)).subscribe(
                data => this.router.navigateByUrl("/admin/main/blocks"),
                error => this.router.navigateByUrl("/admin/main/blocks")
            );
        }
    }

    changeType(event){
        let n = this.types.findIndex(c => c.id.toString() == event.target.value);
        this.t = event.target.options[n].text;
    }

    imgLoaded(event){
        let reader = new FileReader();
        if(event.target.files && event.target.files.length > 0) {
            let file = event.target.files[0];
            reader.readAsDataURL(file);
            reader.onload = () => {
                    this.block.loadImg = reader.result.toString().split(',')[1];
                };
        };
    }
}