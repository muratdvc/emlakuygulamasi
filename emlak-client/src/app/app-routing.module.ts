import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { MusteriListComponent } from './musteri-list/musteri-list.component';
import { MusteriComponent } from './musteriler/musteri/musteri.component';
import { SearchComponent } from './search/search.component';
import { AuthGuard } from './_guards/auth.guard';

const routes: Routes = [
  {path: '', component: HomeComponent},
  {path: 'home', component: HomeComponent},
  {
    path: '',
    runGuardsAndResolvers: 'always',
    canActivate: [AuthGuard],
    children: [
      {path: 'members', component: HomeComponent},
      {path: 'search', component: SearchComponent},
      {path: 'search/:tur', component: SearchComponent},
      {path: 'musteriler', component: MusteriListComponent},
    ]
  },
  {path: 'musteri', component: MusteriComponent},
  {path: '**', component: HomeComponent},
]

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
