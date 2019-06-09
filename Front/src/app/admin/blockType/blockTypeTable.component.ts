import { Component } from "@angular/core";
import { BlockTypeRepository } from "src/app/model/repository/blockTypeRepository";
import { BlockType } from "src/app/model/BlockType.model";

@Component({
    templateUrl: "./template/blockTypeTable.template.html"
})

export class BlockTypeTableComponent{
    constructor(private repo: BlockTypeRepository) {}

    ngOnInit(){
        this.getBlockTypes();
    }

    blockType: BlockType[];

    getBlockTypes(){
        this.repo.getBlockTypes().subscribe(
            data => this.blockType = data,
            error => this.blockType = null)
    }

    deleteBlockType(id: string){
        this.repo.deleteBlockType(id).subscribe(
            data =>  this.blockType.splice(this.blockType.findIndex(d => d.id == id),1)
        )
    }
}