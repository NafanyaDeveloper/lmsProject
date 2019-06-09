import { Component, OnInit } from '@angular/core';
import { SharedAnimations } from 'src/app/shared/animations/shared-animations';
import { FormGroup, FormBuilder, Validators, NgForm } from '@angular/forms';
import { AuthService } from '../../../shared/services/auth.service';
import { Router, RouteConfigLoadStart, ResolveStart, RouteConfigLoadEnd, ResolveEnd } from '@angular/router';

@Component({
    selector: 'app-signup',
    templateUrl: './signup.component.html',
    styleUrls: ['./signup.component.scss'],
    animations: [SharedAnimations]
})
export class SignupComponent implements OnInit {
    loading: boolean;
    loadingText: string;
    signupForm: FormGroup;
    constructor(
        private fb: FormBuilder,
        private auth: AuthService,
        private router: Router
    ) { }

    ngOnInit() {
        this.router.events.subscribe(event => {
            if (event instanceof RouteConfigLoadStart || event instanceof ResolveStart) {
                this.loadingText = 'Загрузка главной страницы...';

                this.loading = true;
            }
            if (event instanceof RouteConfigLoadEnd || event instanceof ResolveEnd) {
                this.loading = false;
            }
        });

        this.signupForm = this.fb.group({
            name: ['', Validators.required],
            surname: ['', Validators.required],
            email: ['', Validators.required],
            password: ['', Validators.required],
            repassword: ['', Validators.required]
        });
    }

    signup(form: NgForm) {
        this.loading = true;
        this.loadingText = 'Регистрация...';
        this.auth.signup(form)
            .subscribe(res => {
                localStorage.setItem(this.auth.TOKEN_KEY, res.toString());
                this.router.navigateByUrl('/main');
                this.loading = false;
            });
    }

}

