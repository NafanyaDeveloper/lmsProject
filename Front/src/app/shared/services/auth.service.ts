import { Injectable } from "@angular/core";
import { LocalStoreService } from "./local-store.service";
import { Router } from "@angular/router";
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { User } from "src/app/model/User.model";
import { NgForm } from "@angular/forms";
import * as jwt_decode from "jwt-decode";


@Injectable({
  providedIn: "root"
})
export class AuthService {
    API_URL = 'https://lms.redoctopus.studio/api/';
    TOKEN_KEY = '.AspNetCore.Identity.Application';

    constructor(private http: HttpClient, private router: Router) { }

    get token() {
        return localStorage.getItem(this.TOKEN_KEY);
    }

    get decodedToken() {
        return jwt_decode(localStorage.getItem(this.TOKEN_KEY));
    }

    get authenticated(): boolean {
        return !!localStorage.getItem(this.TOKEN_KEY);
    }

    signout() {
        localStorage.removeItem(".AspNetCore.Identity.Application");
        this.router.navigateByUrl('/sessions/signin');
    }


    signin(form: NgForm) {
        const headers = {
            headers: new HttpHeaders({ 'Content-Type': 'application/json', 'Cache-Control': 'no-cache',
          'Response-Tye': 'text', 'Access-Control-Allow-Origin': 'http://localhost:4200' })
        };

        const data = {
            email: form.value.email,
            password: form.value.password
        };
        return this.http.post(this.API_URL + 'Login', data, {responseType: 'text'});
      }
    


    signup(form: NgForm)
    {
      const data = {
        email: form.value.email,
        name: form.value.name,
        surname: form.value.surname,
        password: form.value.password
      }
      
      return this.http.post(this.API_URL + 'Register', data, {responseType: 'text'});
    }
}
