import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { MusteriService } from '../_services/musteri.service';
import {ToastrService} from 'ngx-toastr';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  model: any = {};
  @Output() cancelRegister: EventEmitter<boolean> =  new EventEmitter();

  constructor(private musteriService: MusteriService, private toastr: ToastrService) { }

  ngOnInit(): void {
    
  }

  register() {
    this.musteriService.register(this.model).subscribe(response => {
      console.log(response);
      this.cancel();
    }, error => {
      console.log(error)
      this.toastr.error(error.error);
    });
  }

  cancel() {
    this.cancelRegister.emit(false);
  }

}
