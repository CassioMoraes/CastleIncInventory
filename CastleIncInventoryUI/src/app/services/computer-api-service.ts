import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { ComputerModel } from '../models/computer-model';

@Injectable({
  providedIn: 'root'
})
export class ComputerApiService {

  private apiUrl = 'https://localhost:7171';

  constructor(private http: HttpClient) { }

  getData(): Observable<any> {
    return this.http.get<any>(`${this.apiUrl}/Computer/GetAll`).pipe(catchError(this.handleError));
  }

  addComputer(computer: ComputerModel): Observable<any> {
    return this.http.post(`${this.apiUrl}/Computer`, computer).pipe(catchError(this.handleError));;
  }

  deleteComputer(computerId: number): Observable<any> {
    return this.http.delete(`${this.apiUrl}/Computer?computerId=${computerId}`).pipe(catchError(this.handleError));;
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
