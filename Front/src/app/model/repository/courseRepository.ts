import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Repository } from './repository';
import { Response } from '../response/response.model';
import { Course } from '../Course.model';

@Injectable()
export class CourseRepository{
    constructor(private http: HttpClient, private repo: Repository) {}

    getCourses(): Observable<Course[]>{
        return this.http.get<Course[]>(this.repo.courseAPI);
    }

    getCourse(id: string): Observable<Course>{
        return this.http.get<Course>(this.repo.courseAPI + id);
    }

    getCourseByDirection(id: string): Observable<Course[]>{
        return this.http.get<Course[]>(this.repo.courseAPI + 'direction/' + id);
    } 

    createCourse(course: Course): Observable<Course>{
        return this.http.post<Course>(this.repo.courseAPI, course);
    }

    updateCourse(course: Course): Observable<Course>{
        return this.http.put<Course>(this.repo.courseAPI, course);
    }

    deleteCourse(id: string): Observable<boolean>{
        return this.http.delete<boolean>(this.repo.courseAPI + id);
    }
}