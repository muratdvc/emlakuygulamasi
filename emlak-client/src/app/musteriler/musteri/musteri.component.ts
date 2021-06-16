import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-musteri',
  templateUrl: './musteri.component.html',
  styleUrls: ['./musteri.component.css']
})
export class MusteriComponent implements OnInit {
  musteriKayit: boolean = true;

  constructor() { }

  ngOnInit(): void {
  }

  toggleMusteri() {
    this.musteriKayit = true;
  }

  toggleEv() {
    this.musteriKayit = false;
  }

}
