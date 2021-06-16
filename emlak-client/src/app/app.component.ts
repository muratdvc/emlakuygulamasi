import { Component, OnInit } from '@angular/core';
import { IsletmeSahibi } from './_modals/isletme-sahibi';
import { MusteriService } from './_services/musteri.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent  implements OnInit {
  title = 'The Dating app';
  users: any;

  constructor(private musteriService: MusteriService) {}

  ngOnInit() {
    this.setCurrentUser();
  }

  setCurrentUser() {
    const user: IsletmeSahibi = JSON.parse(localStorage.getItem('user')); 
    if (user) {
      console.log(user)
      this.musteriService.setCurrentUser(user); // bunun sayesinde persistance saglaniyor
    }

  }
}
