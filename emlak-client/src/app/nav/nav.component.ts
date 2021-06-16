import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { MusteriService } from '../_services/musteri.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styles: [
  ]
})
export class NavComponent implements OnInit {
  model: any = {};

  constructor(public musteriService: MusteriService, private router: Router) { }

  ngOnInit(): void {
  }

    login() {
    this.musteriService.login(this.model).subscribe(response => {
      this.router.navigateByUrl('/musteri');
    })
  }

  logout() {
    this.musteriService.logout();
    this.router.navigateByUrl('/');
  }

}
