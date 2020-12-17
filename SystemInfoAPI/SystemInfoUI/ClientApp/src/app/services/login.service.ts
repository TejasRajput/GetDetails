import { Injectable } from "@angular/core";
import { HttpClient, HttpErrorResponse } from "@angular/common/http";
import { Observable, throwError } from "rxjs";
import { environment } from "../../environments/environment";
import { catchError } from "rxjs/operators";
import { ItemDetails } from "../models/ItemDetails";

@Injectable()
/* istanbul ignore next */
export class loginService {
  private readonly baseUrl = environment.baseUrl;

  constructor(private readonly httpClient: HttpClient) {
  }

  private handleError(errorResponse: HttpErrorResponse) {
    return throwError(errorResponse);
  }
  getItemDetails(itemId: number): Observable<ItemDetails[]> {
    return this.httpClient.get<ItemDetails[]>(this.baseUrl + "/SystemInfo/" + itemId)
      .pipe(catchError(this.handleError.bind(this)));
  }
  login(formData) {
    return this.httpClient.post(this.baseUrl + "/Authentication/", formData);
  }

}
