import { Component, OnInit } from '@angular/core';
import { ClientSummary } from '../../models/client';
import { ClientService } from '../../services/client.service';

@Component({
  selector: 'app-client-list',
  templateUrl: './client-list.component.html',
  styleUrls: ['./client-list.component.css']
})
export class ClientListComponent implements OnInit {
  clients!: ClientSummary[];
  allclients!: ClientSummary[];
  filterValue!: string;

  constructor(private clientService: ClientService) { }

  ngOnInit() {
    this.clientService.getClients().subscribe(c => {
      this.allclients = c;
      this.clients = this.allclients;
    });
  }
  applyFilter() {
    console.log(this.filterValue);
    let filterValueLower = this.filterValue.toLowerCase();
    if (this.filterValue === '') {
      this.clients = this.allclients;
    }
    else {
      this.clients = this.allclients.filter((c) => c.name.includes(filterValueLower));
    }
  }
}
/*
 
  
 */
