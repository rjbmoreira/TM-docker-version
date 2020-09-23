import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';
import { Customer } from '../models/customer';
import { Project } from '../models/project';
import { TimeInput } from '../models/timeinput';

@Injectable({
  providedIn: 'root'
})
export class DBAccessService {

  urlPrefix:string = "http://localhost:5000/tm.api/";

  constructor(private http: HttpClient) { }

  getCustomers(){
    return this.http.get(this.urlPrefix+"customer").pipe(
      catchError(this.handleError)
    );
  }

  addCustomer(customer: Customer){
    return this.http.post(this.urlPrefix+"customer",customer).pipe(
      catchError(this.handleError)
    );
  }

  getProjects(){
    return this.http.get(this.urlPrefix+"project").pipe(
      catchError(this.handleError)
    );
  }

  getProjectsByCustomer(cId: number){
    return this.http.get(this.urlPrefix+"project/bycustomer/"+cId).pipe(
      catchError(this.handleError)
    );
  }

  addProject(project: Project){
    return this.http.post(this.urlPrefix+"project",project).pipe(
      catchError(this.handleError)
    );
  }

  registerTime(timeInput: TimeInput){
    return this.http.post(this.urlPrefix+"timeinput",timeInput).pipe(
      catchError(this.handleError)
    );
  }

  getTimeInputsGroupedByProject(){
    return this.http.get(this.urlPrefix+"timeinput/groupedbyproject").pipe(
      catchError(this.handleError)
    );
  }

  /*
  From documentation. 
  */
  //TODO improve it.
  handleError(error: HttpErrorResponse) {
    if (error.error instanceof ErrorEvent) {
      console.error('An error occurred:', error.error.message);
    } else {
      console.error(
        `Backend returned code ${error.status}, ` +
        `body was: ${error.error}`);
    }
    // Return an observable with a user-facing error message.
    return throwError(
      'Something bad happened; please try again later.');
  }
}
