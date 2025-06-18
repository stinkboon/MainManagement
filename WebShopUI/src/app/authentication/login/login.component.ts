import { Component } from '@angular/core';
import { FormGroup, FormBuilder, Validators, ReactiveFormsModule, FormsModule } from '@angular/forms';
import { Router, RouterModule } from '@angular/router';
import { loginDto } from '../../core/datacontracts/loginDto';
import { AuthService } from '../../core/services/auth.service';
import { CommonModule } from '@angular/common';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';


@Component({
  selector: 'app-login',
  imports: [
    CommonModule,
    ReactiveFormsModule,
    FormsModule,
    RouterModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
  ],
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss'
})
export class LoginComponent {
  loginForm: FormGroup;

  constructor(
    private formBuilder: FormBuilder,
    private authService: AuthService, // Assuming you have a LoginService to handle authentication
    private router: Router // Assuming you have a Router to navigate after login
  ) {
    this.loginForm = this.formBuilder.group({
      userName: [' ', [Validators.required, Validators.minLength(4)]],
      password: [' ', [Validators.required]]
    });
  }
  login() {
    if (this.loginForm.valid) {
      const loginDto: loginDto = this.loginForm.value;
      console.log(loginDto);

      this.authService.login(loginDto).subscribe({
        next: (token: string) => {
          localStorage.setItem('token', token);
          this.router.navigate(['/platform/products'])
        },
        error: (err: string) => {
          console.log('Login failed', err);
        }
      });
    }
  }
}
