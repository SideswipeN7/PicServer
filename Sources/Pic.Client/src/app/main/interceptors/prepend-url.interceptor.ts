import { environment } from './../../../environments/environment';
import { Injectable } from '@angular/core';
import {
  HttpEvent,
  HttpHandler,
  HttpInterceptor,
  HttpRequest,
} from '@angular/common/http';
import { Observable } from 'rxjs';
import { Environment } from '../models/enviroment.model';

@Injectable()
export class PrependUrlInterceptor implements HttpInterceptor {
  intercept(
    request: HttpRequest<any>,
    next: HttpHandler
  ): Observable<HttpEvent<any>> {
    const env = environment as Environment;
    if (!env.production && request.url.startsWith('api')) {
      request = request.clone({
        url: `${env.serviceUrl}${request.url}`,
      });
    }

    return next.handle(request);
  }
}
