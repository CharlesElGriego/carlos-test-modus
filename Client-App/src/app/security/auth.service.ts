import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { BehaviorSubject, Observable } from 'rxjs';
import { DecodeToken, LoginUser, User } from './models';
@Injectable({
  providedIn: 'root'
})
export class AuthService {

  //#region   Public Properties
  authenticated$ = new BehaviorSubject(false);
  user$ = new BehaviorSubject(null);
  //#endregion

  //#region   Constructor
  constructor(private http: HttpClient) { }
  //#endregion

  //#region   Public Methods
  decodeToken(): DecodeToken {
    const token = this.getToken();
    const helper = new JwtHelperService();
    return helper.decodeToken(token);
  }

  getToken(): string {
    return localStorage.getItem('token');
  }

  isAlreadyAuthenticated(): boolean {
    if (this.isAuthenticated()) {
      this.authenticated$.next(true);
      this.setUser();
      return true;
    } else {
      return false;
    }
  }

  isAuthenticated(): boolean {
    const token = this.getToken(); // check if valid
    if (token) {
      return true;
    } else {
      this.authenticated$.next(false);
      return false;
    }
  }

  login(user: LoginUser): Observable<string> {
    return this.http.post<string>('login/autenticate',
      { username: user.username, password: user.password });
  }

  logOut(): void {
    localStorage.removeItem('token');
    this.authenticated$.next(false);
  }

  saveToken(token: string) {
    localStorage.setItem('token', token);
  }
  setUser(): void {
    const decode = this.decodeToken();
    this.user$.next(new User({
      name: decode.unique_name,
      email: decode.email,
      role: decode.role
    }));
  }

  signUp(user: User): Observable<string> {
    return this.http.post<string>('login/register', user);
  }
}
