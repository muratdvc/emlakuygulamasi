import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { EmlakService } from 'src/app/_services/emlak.service';

@Component({
  selector: 'app-alici-musteri',
  templateUrl: './alici-musteri.component.html',
  styleUrls: ['./alici-musteri.component.css']
})
export class AliciMusteriComponent implements OnInit {
  model:any = {};

  constructor(private router: Router, private emlakService: EmlakService) { }

  ngOnInit(): void {
  }

  kaydet() {
    this.emlakService.aliciMusteriyiKaydet(this.model).subscribe(res => {
      this.model = {}
    },error => {
      console.log(error)
    }
    );
  }

  submit() {
    this.emlakService.aliciMusteriyiKaydet(this.model).subscribe(res => {
      this.router.navigateByUrl('search/' + this.model.EvTuru);
    },error => {
      console.log(error);
    });
  }

}
