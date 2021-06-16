import { Component, OnInit } from '@angular/core';
import { FormArray, FormControl, FormGroup } from '@angular/forms';
import { EmlakService } from 'src/app/_services/emlak.service';

@Component({
  selector: 'app-satici-musteri',
  templateUrl: './satici-musteri.component.html',
  styleUrls: ['./satici-musteri.component.css']
})
export class SaticiMusteriComponent implements OnInit {
  form: FormGroup;

  constructor(private emlakService: EmlakService) { }

  ngOnInit(): void {
    this.form = new FormGroup({
      isim: new FormControl(),
      ceptelefonno: new FormControl(),
      email: new FormControl(),
      evturu: new FormControl(),
      emlakIlanlari: new FormArray([
        new FormGroup({
          evturu: new FormControl(),
          alan: new FormControl(),
          odasayisi: new FormControl(),
          kat: new FormControl(),
          binakati: new FormControl(),
        })
      ])
    })
  }


  onSubmit() {
    console.log(this.form.value)
    this.emlakService.saticiMusteriyiKaydet(this.form.value).subscribe(res => {
      // this.form.get('emlaklar').value[0].evturu = this.form.value.evturu;
      this.form.reset();
    },error => {
      console.log(error);
    })
  }

  kaydet() {
    console.log(this.form)
  }

}
