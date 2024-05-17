import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SignupComponent } from './signup.component';
import { AuthService } from '../auth/AuthProvider';


@NgModule({
  declarations: [
    SignupComponent
  ],
  imports: [
    CommonModule
  ],  
  providers: [
    AuthService
  ],
  exports: [
    SignupComponent
  ]
})
export class SignupModule { }
