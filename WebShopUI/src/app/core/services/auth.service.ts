import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { loginDto } from '../../core/datacontracts/loginDto';


@Injectable({
    providedIn: 'root',
})
export class AuthService {
    private Url = 'http://localhost:5103/api';
    constructor(private http: HttpClient) {}

    public login(loginDto: loginDto): Observable<string> {
        return this.http.post<string>(`${this.Url}/auth/login`, loginDto);
    }
} 