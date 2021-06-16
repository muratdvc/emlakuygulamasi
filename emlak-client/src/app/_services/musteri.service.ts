import { Injectable } from '@angular/core';
import { ReplaySubject } from 'rxjs';
import { IsletmeSahibi } from '../_modals/isletme-sahibi';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class MusteriService {
  baseUrl: string = environment.apiUrl;
  private isletmeSahibiSource = new ReplaySubject<IsletmeSahibi>(1);
  currentUser$ = this.isletmeSahibiSource.asObservable();
  
  constructor(private http: HttpClient) { }

  
  login(model: any) {
    return this.http.post(this.baseUrl + 'isletmesahibi/login', model).pipe(
      map((response: IsletmeSahibi) => {
        const user = response;
        if (user) {
          localStorage.setItem('user', JSON.stringify(user));
          this.isletmeSahibiSource.next(user);
        }
      })
    )
  }

  register(model: any) {
    return this.http.post(this.baseUrl + 'isletmesahibi/register', model).pipe(
      map((user: IsletmeSahibi) => {
        if (user) {
          localStorage.setItem('user', JSON.stringify(user));
          this.isletmeSahibiSource.next(user);
        }
        
      })
    )
  }

  setCurrentUser(user: IsletmeSahibi) {
    this.isletmeSahibiSource.next(user);
  }

  logout() {
    localStorage.removeItem('user');
    this.isletmeSahibiSource.next(null);
  }

  getMusteriler() {
    return this.http.get(this.baseUrl + 'msatici');
  }

}
