import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { Router, RouterModule } from '@angular/router';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { MatSnackBar, MatSnackBarModule } from '@angular/material/snack-bar';
import { CommonModule } from '@angular/common';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';

@Component({
  selector: 'app-forgot-password',
  standalone: true,
  imports: [
    CommonModule,
    ReactiveFormsModule,
    RouterModule,
    HttpClientModule,
    MatSnackBarModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule
  ],
  templateUrl: './forgot-password.component.html',
  styleUrls: ['./forgot-password.component.scss']
})
export class ForgotPasswordComponent implements OnInit {
  forgotForm: FormGroup;

  constructor(
    private fb: FormBuilder,
    private http: HttpClient,
    private snackBar: MatSnackBar,
    private router: Router
  ) {
    this.forgotForm = this.fb.group({
      email: ['', [Validators.required, Validators.email]]
    });
  }

  ngOnInit(): void {}

  sendReset() {
    if (this.forgotForm.valid) {
      const email = this.forgotForm.value.email;
      // Veronderstel dat de backend op poort 5000 draait; pas dit aan indien nodig.
      this.http.post('http://localhost:5103/api/auth/forgot-password', email, {
        responseType: 'json'
      }).subscribe({
        next: () => {
          this.snackBar.open('Resetlink verzonden!', 'Sluiten', { duration: 3000 });
          this.router.navigate(['/login']);
        },
        error: (err) => {
          this.snackBar.open(`Fout: ${err.error.message}`, 'Sluiten', { duration: 4000 });
        }
      });
    }
  }
}
