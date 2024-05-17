import { Component, Output, EventEmitter } from '@angular/core';
import { AuthService } from '../auth/AuthProvider';
import { ISignUp } from '../interfaces/signUp';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrl: './signup.component.css'
})
export class SignupComponent {
  @Output() signUpEvent = new EventEmitter<boolean>();
  constructor(private authService: AuthService) {}
  async signUp(firstName: string, lastName: string, email: string, password: string, event: Event): Promise<void> {
    event.preventDefault();
    let signUpData : ISignUp = {FirstName:firstName,LastName:lastName,Email:email,Password:password};
    await this.authService.signUp(signUpData);
    this.setSignedUp(true);
  }  
  setSignedUp(signUp: boolean){
    this.signUpEvent.emit(signUp);
  }

}
