import { Component } from "@angular/core";
import { Router } from "@angular/router";
import { NgForm } from "@angular/forms";
import { routerNgProbeToken } from "@angular/router/src/router_module";

@Component({
    templateUrl: "auth.template.html"
})
export class AuthComponent{
    constructor(private router: Router) {}

    username: string;
    password: string;
    errorMessage: string;

    authenticate(form: NgForm){
        if (!form.invalid){
            this.router.navigateByUrl("/admin/main");
        } else {
            this.errorMessage = "FAIL";
        }
    }
}