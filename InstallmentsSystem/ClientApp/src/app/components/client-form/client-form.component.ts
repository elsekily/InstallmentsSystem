import { Component, OnInit } from '@angular/core';
import { ClientService } from '../../services/client.service';
import { ClientSummary, ClientWithInstallments } from '../../models/client';
import { ActivatedRoute, Router } from '@angular/router';
import { InstallmentSummary } from '../../models/installment';

@Component({
  selector: 'app-client-form',
  templateUrl: './client-form.component.html',
  styleUrls: ['./client-form.component.css']
})
export class ClientFormComponent implements OnInit {
  clientId: number;
  filterValue: string;
  client: ClientWithInstallments = {
    id: 0,
    name: '',
    nationalId: '',
    mobileNumber: '',
    installments: []
  };
  allinstallments: InstallmentSummary[];
  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private clientservice: ClientService
  ) {
    route.params.subscribe(p => {

      this.clientId = +p['id'] || 0;
    })
  }

  ngOnInit() {
    if (this.clientId != 0) {
      this.clientservice.getClient(this.clientId)
        .subscribe(c => {
          this.client = c;
          this.allinstallments = c.installments;
        },
          msg => {
            if (msg.status == 404) {
              this.router.navigate(['/error'])
            }
          }
      );
    }
  }

  submit() {
    if (this.client.id) {
      this.clientservice.update(this.client).subscribe(res => {
        this.router.navigate(['/client']);
      });
    }
    else {
      this.clientservice.create(this.client).subscribe(res => {
        this.router.navigate(['/client/' + res.id]);
      });
    }
  }

  delete() {
    if (confirm('هل أنت متأكد من حذف هذا العميل؟')) {
      this.clientservice.delete(this.client.id).subscribe(res => {
          this.router.navigate(['/client']);
      },
        msg => {
          if (msg.status == 401) {
            alert('من فضلك سجل الدخول كمشرف!');
        }
      }
      );
    } 
  }

  applyFilter() {
    console.log(this.filterValue);
    let filterValueLower = this.filterValue.toLowerCase();
    if (this.filterValue === '') {
      this.client.installments = this.allinstallments;
    }
    else {
      this.client.installments = this.allinstallments.filter((c) => c.deviceName.includes(filterValueLower));
    }
  }
}
