import { ChangeDetectionStrategy, Component, OnDestroy, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class LoginComponent implements OnInit, OnDestroy {

  //#region   Public Properties
  loginForm = this.fb.group({
    username: ['', Validators.compose([Validators.required, Validators.email])],
    password: ['', Validators.required],
  });
  //#endregion

  //#region   Constructor
  constructor(
    private authService: AuthService,
    private fb: FormBuilder,
    private router: Router
  ) { }
  //#region

  /*Lifecycle Hooks  */
  ngOnInit(): void {
    this.authService.isAuthenticated();
  }
  ngOnDestroy(): void {
  }

  //#region   Public Methods

  login(): void {
    this.authService.login(this.loginForm.value).subscribe(token => {
      if (token) {
        this.authService.saveToken(token);
        this.authService.authenticated$.next(true);
        this.authService.setUser();
        this.router.navigate(['my-feeds']);
      }
    });
  }
  get password(): AbstractControl {
    return this.loginForm.get('password');
  }

  get username(): AbstractControl {
    return this.loginForm.get('username');
  }
  //#endregion

}
