import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { Observable } from 'rxjs';
import { IsletmeSahibi } from '../_modals/isletme-sahibi';
import { MusteriService } from '../_services/musteri.service';
import { take } from 'rxjs/operators';

@Injectable()
export class JwtInterceptor implements HttpInterceptor {

  constructor(private musteriService: MusteriService) {}

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    let currentUser: IsletmeSahibi;

    this.musteriService.currentUser$.pipe(take(1)).subscribe(user => currentUser = user)
      if (currentUser) {
        request = request.clone({
          setHeaders: {
            Authorization: `Bearer ${currentUser.token}`
          }
        })
      }

    return next.handle(request);

  }
}
