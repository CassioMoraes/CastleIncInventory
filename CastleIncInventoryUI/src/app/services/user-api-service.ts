import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class UserApiService {

  private apiUrl = 'https://localhost:7171';

  constructor(private http: HttpClient) { }

  getData(): Observable<any> {
    return this.http.get<any>(`${this.apiUrl}/User/GetAll`).pipe(catchError(this.handleError));
  }

  assignComputer(computerId: number, userId: number) {
    return this.http.post(`${this.apiUrl}/User/AssignComputer`, { computerId: computerId, userId: userId })
      .pipe(catchError(this.handleError));
  }

  private handleError(error: HttpErrorResponse) {
    if (error.error instanceof ErrorEvent) {
      console.error('An error occurred:', error.error.message);
    } else {
      console.error(`Backend returned code ${error.status}, ` + `body was: ${error.error}`);
    }

    return throwError(() => 'Something bad happened; please try again later.');
  }
}
