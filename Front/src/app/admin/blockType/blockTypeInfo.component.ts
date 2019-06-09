import { Component } from "@angular/core";
import { BlockTypeRepository } from "src/app/model/repository/blockTypeRepository";
import { Router, ActivatedRoute } from "@angular/router";
import { BlockType } from "src/app/model/BlockType.model";

@Component({
    templateUrl: "template/blockTypeInfo.template.html"
})

export class BlockTypeInfoComponent{
    constructor(private repo: BlockTypeRepository, 
        private router: Router,
        activeRoute: ActivatedRoute) {
        this.id = activeRoute.snapshot.params["id"];
        this.getBlockType(this.id);
    }

    blockType: BlockType = new BlockType; 
    id: string;

    getBlockType(id: string){
        this.repo.getBlockType(id).subscribe(
            data => this.blockType = data
        );
    }
}