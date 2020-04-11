import { HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ErrorHandlerService {

  //#region   Observables
  serverError$: Subject<string> = new Subject<string>();
  //#endregion

  //#region   Constructor
  constructor() {
  }
  //#endregion

  //#region   Public Methods
  addServerError(data: HttpErrorResponse): void {
    this.serverError$.next(data.error.message);
  }

  removeServerError(): void {
    this.serverError$.next(null);
  }
  //#endregion
}
