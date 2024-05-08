import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { CookieService } from 'ngx-cookie-service';
import { HttpClient } from '@angular/common/http';
import { ILogin } from '../interfaces/login';
import { ISignUp } from '../interfaces/signUp';
import axios from 'axios';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private isAuthenticatedSubject = new BehaviorSubject<boolean>(false);
  public isAuthenticated$ = this.isAuthenticatedSubject.asObservable();

  constructor(private cookieService: CookieService) {
    this.checkAuth();
  }

  public checkAuth(): void {
    const authToken = this.cookieService.get('YourAuthCookieName');
    this.isAuthenticatedSubject.next(!!authToken);
  }

  public async signUp(signUpData: ISignUp): Promise<void> {
    try {
      console.log("I'm signing up");
      await axios.post("http://localhost:5007/auth/signup", signUpData);
    } catch (error) {
      console.error(error);
    };
  }

  public async login(loginData: ILogin): Promise<void> {
    try {
      await axios.post("http://localhost:5007/auth/login", loginData);
      this.isAuthenticatedSubject.next(true);
    } catch (error) {
      console.error(error);
      throw error;
    }
  }

  public async logout(): Promise<void> {
    try {
      await axios.delete("http://localhost:5007/auth/logout");
      this.cookieService.delete('YourAuthCookieName');
      this.isAuthenticatedSubject.next(false);
    } catch (error) {
      console.error(error);
      throw error;
    }   
  }
}