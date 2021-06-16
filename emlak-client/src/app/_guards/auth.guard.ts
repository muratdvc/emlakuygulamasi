import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { MusteriService } from '../_services/musteri.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  constructor(private musteriService: MusteriService) { }

  canActivate(): Observable<boolean> {
    return this.musteriService.currentUser$.pipe(
      map(user => {
        if (user) {
          return true;
        }
      })
    )
  }

}
