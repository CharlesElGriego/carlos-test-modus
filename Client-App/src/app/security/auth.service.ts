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

  isAuthenticated(): boolean {
    const token = this.getToken();
    if (token) {
      // decode hacer user$
      this.authenticated$.next(true);
      return true;
    } else {
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
}
