import { ChangeDetectionStrategy, Component, OnDestroy, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../auth.service';

@Component({
  selector: 'app-sign-up',
  templateUrl: './sign-up.component.html',
  styleUrls: ['./sign-up.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class SignUpComponent implements OnInit, OnDestroy {

  //#region   Public Properties
  signUpForm = this.fb.group({
    fullName: ['', Validators.compose([Validators.required, Validators.pattern('^[A-Z]?[- a-zA-Z]+$')])],
    email: ['', Validators.compose([Validators.required, Validators.email])],
    userPassword: ['', Validators.required],
    type: ['2']
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
  signUp(): void {
    this.authService.signUp(this.signUpForm.value).subscribe(token => {
      if (token) {
        this.authService.saveToken(token);
        this.authService.authenticated$.next(true);
        this.authService.setUser();
        this.router.navigate(['my-feeds']);
      }
    });
  }

  get fullName(): AbstractControl {
    return this.signUpForm.get('fullName');
  }
  get userPassword(): AbstractControl {
    return this.signUpForm.get('userPassword');
  }

  get email(): AbstractControl {
    return this.signUpForm.get('email');
  }
  //#endregion

}
