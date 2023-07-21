import { Injectable } from '@angular/core';
import { User } from '../models/user';
import {
  HttpClient,
  HttpHeaders,
} from '@angular/common/http';
import { Router } from '@angular/router';
import { environment } from 'src/environments/environment';
import { JwtHelperService } from '@auth0/angular-jwt';

const baseUrl = `${environment.apiUrl}/User`;

@Injectable({
  providedIn: 'root',
})

export class AuthService {
  headers = new HttpHeaders().set('Content-Type', 'application/json');
  currentUser = {};

  constructor(private http: HttpClient, private jwtHelper: JwtHelperService, public router: Router) {}

  signIn(user: User) {
    return this.http
      .post<any>(`${baseUrl}/Login`, user)
      .subscribe((res: any) => {
        localStorage.setItem('access_token', res.token);
          this.currentUser = res;
          this.router.navigate(['']);
      });
  }

  getToken() {
    return localStorage.getItem('access_token');
  }

  get isLoggedIn(): boolean {
    let authToken = localStorage.getItem('access_token');
    let tokenExpired = this.jwtHelper.isTokenExpired(authToken);
    return authToken !== null && !tokenExpired;
  }
}