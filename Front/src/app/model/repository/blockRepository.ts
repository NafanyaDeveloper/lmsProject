import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Repository } from "./repository";
import { Observable } from "rxjs";
import { Response } from "../response/response.model";
import { Block } from "../Block.model";

@Injectable()
export class BlockRepository{
    constructor(private http: HttpClient, private repo: Repository) {}

    getBlocks(): Observable<Block[]>{
        return this.http.get<Block[]>(this.repo.blockAPI);
    }

    getBlock(id: string): Observable<Block>{
        return this.http.get<Block>(this.repo.blockAPI + id);
    }

    getBlockByPage(id: string): Observable<Block[]>{
        return this.http.get<Block[]>(this.repo.blockAPI + 'page/' + id);
    }

    getBlockByBlockType(id: string): Observable<Block[]>{
        return this.http.get<Block[]>(this.repo.blockAPI + 'type/' + id);
    }

    createBlock(block: Block): Observable<Block>{
        return this.http.post<Block>(this.repo.blockAPI, block);
    }

    updateBlock(block: Block): Observable<Block>{
        return this.http.put<Block>(this.repo.blockAPI, block);
    }

    deleteBlock(id: string): Observable<boolean>{
        return this.http.delete<boolean>(this.repo.blockAPI + id);
    }
}