import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { Items } from '../models/Items';
import { environment } from "../../environments/environment";
import { catchError } from 'rxjs/operators';

@Injectable()
/* istanbul ignore next */
export class HomeServices {
  private readonly baseUrl = environment.baseUrl;

  constructor(private readonly httpClient: HttpClient){
  }

  private handleError(errorResponse: HttpErrorResponse) {
    return throwError(errorResponse);
  }

  getItems(): Observable<Items[]> {
    return this.httpClient.get<Items[]>(this.baseUrl + '/SystemInfo')
      .pipe(catchError(this.handleError.bind(this)));
  }
}


