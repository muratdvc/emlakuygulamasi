import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { filter, map } from 'rxjs/operators';
import { Emlak } from '../_modals/emlak';
import { EmlakService } from '../_services/emlak.service';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css']
})
export class SearchComponent implements OnInit {
  emlakIlanlari: Emlak[] = [];
  emlakTuru: string = ''

  constructor(private emlakService: EmlakService, private route: ActivatedRoute, private router: Router) { }

  ngOnInit(): void {
    this.emlakTuru = this.route.snapshot.paramMap.get("tur");
    this.emlakService.getEmlakIlanlari().pipe(
      map(ilanlar =>
        ilanlar.filter(emlak => emlak.emlakTuru == this.emlakTuru)
      ))
        .subscribe(res => {
        this.emlakIlanlari = res;
    });
  }

}
