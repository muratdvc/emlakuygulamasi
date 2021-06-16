import { Component, OnInit } from '@angular/core';
import { MusteriService } from '../_services/musteri.service';

@Component({
  selector: 'app-musteri-list',
  templateUrl: './musteri-list.component.html',
  styleUrls: ['./musteri-list.component.css']
})
export class MusteriListComponent implements OnInit {
  musteriler:any = [];
  constructor(private musteriService: MusteriService) { }

  ngOnInit(): void {
    this.getMusteriler();
    console.log(this.musteriler)
  }

  getMusteriler() {
    this.musteriService.getMusteriler().subscribe(res => {
      this.musteriler = res
      console.log(res)
    })
  }

}
