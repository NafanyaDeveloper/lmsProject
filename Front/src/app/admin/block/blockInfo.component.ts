import { Component, Input } from "@angular/core";
import { Router, ActivatedRoute } from "@angular/router";
import { BlockRepository } from "src/app/model/repository/blockRepository";
import { Block } from "src/app/model/Block.model";

@Component({
    templateUrl: "template/blockInfo.template.html"
})

export class BlockInfoComponent{
    constructor(private repo: BlockRepository,
        private router: Router,
        activeRoute: ActivatedRoute) {
        this.id = activeRoute.snapshot.params["id"];
        this.getBlock(this.id);
    }

    block: Block = new Block(); 
    id: string;


    getBlock(id: string){
        this.repo.getBlock(id).subscribe(
            data => this.block = data
        );
    }
}