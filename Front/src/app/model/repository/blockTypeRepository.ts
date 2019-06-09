import {  Injectable  } from "@angular/core";
import { Repository } from "./repository";
import { Observable } from "rxjs";
import { HttpClient } from '@angular/common/http';
import { BlockType } from "../BlockType.model";

@Injectable()
export class BlockTypeRepository{
    constructor(private repo: Repository, private http: HttpClient) {}

    getBlockTypes(): Observable<BlockType[]> {
        return this.http.get<BlockType[]>(this.repo.blockTypeAPI);  
    }

    getBlockType(id: string): Observable<BlockType> {
        return this.http.get<BlockType>(this.repo.blockTypeAPI + id);
    }

    createBlockType(blockType: BlockType): Observable<BlockType>{
        return this.http.post<BlockType>(this.repo.blockTypeAPI, blockType);
    }

    updateBlockType(blockType: BlockType): Observable<BlockType>{
        return this.http.put<BlockType>(this.repo.blockTypeAPI, blockType);
    }

    deleteBlockType(id: string): Observable<boolean>{
        return this.http.delete<boolean>(this.repo.blockTypeAPI + id);
    }
}