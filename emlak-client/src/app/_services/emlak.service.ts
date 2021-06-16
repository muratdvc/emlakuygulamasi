import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Emlak } from '../_modals/emlak';

@Injectable({
  providedIn: 'root'
})
export class EmlakService {
  baseUrl: string = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getEmlakIlanlari() {
    return this.http.get<Emlak[]>(this.baseUrl + 'emlak');

  }

  aliciMusteriyiKaydet(model) {
    return this.http.post(this.baseUrl + 'malici', model);
  }

  saticiMusteriyiKaydet(model) {
    return this.http.post(this.baseUrl + 'msatici', model);
  }

}
