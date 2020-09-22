import { Component, OnInit } from '@angular/core';
import { ClientService } from '../../services/client.service';
import { SaveClient } from '../../models/client';

@Component({
  selector: 'app-client-form',
  templateUrl: './client-form.component.html',
  styleUrls: ['./client-form.component.css']
})
export class ClientFormComponent implements OnInit {
  client: SaveClient = {
    id: 0,
    name: 'mm',
    nationalId: '25923a',
    mobileNumber: '1245789ds'
  };

  constructor(private clientservice: ClientService) { }

  ngOnInit() {
    
  }

  submit() {
    this.clientservice.create(this.client).subscribe(res => {
      console.log(res);
    });
  }
}
