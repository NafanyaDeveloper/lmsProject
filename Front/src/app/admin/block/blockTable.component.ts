import { Component, Input } from "@angular/core";
import { BlockRepository } from "src/app/model/repository/blockRepository";
import { Block } from "src/app/model/Block.model";

@Component({
    selector: "block-table",
    templateUrl: "template/blockTable.template.html"
})

export class BlockTableComponent{
    constructor(private repo: BlockRepository) {}

    ngOnInit(){
        if(this.pageId != null)
            this.getBlockByPage(this.pageId);
        else if(this.typeId != null)
            this.getBlockByType(this.typeId);    
        else
            this.getBlocks();
    }

    @Input() pageId: string;
    @Input() typeId: string;
    
    blocks: Block[];

    getBlocks(){
        this.repo.getBlocks().subscribe(
            data => this.blocks = data,
            error => this.blocks = null)
    }

    getBlockByPage(id: string){
        this.repo.getBlockByPage(id).subscribe(
            data => this.blocks = data,
            error => this.blocks = null)
    }

    getBlockByType(id: string){
        this.repo.getBlockByBlockType(id).subscribe(
            data => this.blocks = data,
            error => this.blocks = null)
    }

    deleteBlock(id: string){
        this.repo.deleteBlock(id).subscribe(
            data =>  this.blocks.splice(this.blocks.findIndex(c => c.id.toString() == id),1)
        )
    }
}