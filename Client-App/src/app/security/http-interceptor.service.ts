import { HttpErrorResponse, HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { Injectable, Injector } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';
import { ErrorHandlerService } from './error-handler.service';


@Injectable({
  providedIn: 'root'
})
export class HttpInterceptorService implements HttpInterceptor {
  private baseUrl = 'http://localhost:60932/api/'; // interceptor

  constructor(private injector: Injector) {
  }

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    const token = localStorage.getItem('token');
    const request = req.clone({
      setHeaders: {
        Authorization: `Bearer ${token}`,
        'Content-Type': 'application/json; charset=utf-8',
        'Access-Control-Allow-Origin': '*',
      },
      url: this.baseUrl + req.url
    });

    const globalErrorService = this.injector.get(ErrorHandlerService);
    globalErrorService.removeServerError();

    return next.handle(request).pipe(
      retry(3), // If http call fails, retry again (3 times)
      catchError(
        (errors: HttpErrorResponse) => {
          globalErrorService.addServerError(errors);
          return throwError(errors);
        }
      )
    );

  }
}
