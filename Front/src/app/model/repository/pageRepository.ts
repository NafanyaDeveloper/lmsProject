import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Repository } from "./repository";
import { Observable } from "rxjs";
import { Response } from "../response/response.model";
import { Page } from "../Page.model";

@Injectable()
export class PageRepository{
    constructor(private http: HttpClient, private repo: Repository) {}

    getPages(): Observable<Page[]>{
        return this.http.get<Page[]>(this.repo.pageAPI);
    }

    getPage(id: string): Observable<Page>{
        return this.http.get<Page>(this.repo.pageAPI + id);
    }

    getPageByCourse(id: string): Observable<Page[]>{
        return this.http.get<Page[]>(this.repo.pageAPI + 'course/' + id);
    }

    createPage(page: Page): Observable<Page>{
        return this.http.post<Page>(this.repo.pageAPI, page);
    }

    updatePage(page: Page): Observable<Page>{
        return this.http.put<Page>(this.repo.pageAPI, page);
    }

    deletePage(id: string): Observable<boolean>{
        return this.http.delete<boolean>(this.repo.pageAPI + id);
    }
}