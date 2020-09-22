import { Component, OnInit } from '@angular/core';
import { ClientService } from '../../services/client.service';
import { SaveClient } from '../../models/client';
import { ActivatedRoute, Router } from '@angular/router';
import { error } from 'console';

@Component({
  selector: 'app-client-form',
  templateUrl: './client-form.component.html',
  styleUrls: ['./client-form.component.css']
})
export class ClientFormComponent implements OnInit {
  clientId: number;
  client: SaveClient = {
    id: 0,
    name: '',
    nationalId: '',
    mobileNumber: ''
  };

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private clientservice: ClientService
  ) {
    route.params.subscribe(p => {

      this.clientId = +p['id'] || 0;
    })
    console.log(this.clientId);
  }

  ngOnInit() {
    if (this.clientId != 0) {
      this.clientservice.getClient(this.clientId)
        .subscribe(c => {
          this.client = c;
        },
          msg => {
            if (msg.status == 404) {
              this.router.navigate(['/'])
            }
          }
        );
    }    
  }

  submit() {
    if (this.client.id) {
      this.clientservice.update(this.client).subscribe();
    }
    else {
      this.clientservice.create(this.client).subscribe(res => {
        this.router.navigate(['/client/' + res.id]);
      });
    }
  }

  delete() {
    if (confirm('Are you sure??')) {
      this.clientservice.delete(this.client.id).subscribe(res => {
          this.router.navigate(['/']);
      });
    }
    
  }
}
