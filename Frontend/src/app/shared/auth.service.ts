import { Injectable } from '@angular/core';
import { User } from '../models/user';
import {
  HttpClient,
  HttpHeaders,
} from '@angular/common/http';
import { Router } from '@angular/router';
import { environment } from 'src/environments/environment';

const baseUrl = `${environment.apiUrl}/User`;

@Injectable({
  providedIn: 'root',
})

export class AuthService {
  headers = new HttpHeaders().set('Content-Type', 'application/json');
  currentUser = {};

  constructor(private http: HttpClient, public router: Router) {}

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
    return authToken !== null;
  }

}