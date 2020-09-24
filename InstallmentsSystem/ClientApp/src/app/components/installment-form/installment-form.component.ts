import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { InstallmentService } from '../../services/installment.service';
import { Installment, SaveInstallment, IdDatePair } from '../../models/installment';

@Component({
  selector: 'app-installment-form',
  templateUrl: './installment-form.component.html',
  styleUrls: ['./installment-form.component.css']
})
export class InstallmentFormComponent implements OnInit {
  installmentId: number;
  clientid: number;

  installment: Installment = {
    id: 0,
    deviceName: '',
    remaining: 0,
    nextPayment: new Date(),
    startDate: new Date(),
    deviceActualPrice: 0,
    devicePrice: 0,
    firstInstallment: 0,
    paymentScheme: 0,
    montlyPayment: 0,
    dayofPayment: 0,
    clientId: 0,
    clientName: '',
    payments: [],
  };

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private installmentservice: InstallmentService
  ) {
    route.params.subscribe(p => {

      this.installmentId = +p['id'] || 0;
      if (!this.installmentId) {
        this.clientid = +p['clientid'];
      }
    })
  }

  ngOnInit() {
    if (this.installmentId != 0) {
      this.installmentservice.getinstallment(this.installmentId)
        .subscribe(i => {
          this.installment = i;
        },
          msg => {
            if (msg.status == 404) {
              this.router.navigate(['/client'])
            }
          }
        );
    }
    else {
      this.installment.clientId = this.clientid;
    }
  }
  submit() {
    let installmentSave: SaveInstallment = {
      deviceName: this.installment.deviceName,
      deviceActualPrice: +this.installment.deviceActualPrice,
      devicePrice: +this.installment.devicePrice,
      paymentScheme: +this.installment.paymentScheme,
      firstInstallment: +this.installment.firstInstallment,
      montlyPayment: +this.installment.montlyPayment,
      dayofPayment: +this.installment.dayofPayment,
      clientId: +this.installment.clientId,
    };

    console.log(installmentSave);
    if (this.installment.id) {
      this.installmentservice.update(this.installment.id, installmentSave).subscribe(res => {
        this.router.navigate(['/installment/' + res.id]);
      });
    }
    else {
      this.installmentservice.create(installmentSave).subscribe(res => {
        this.router.navigate(['/installment/' + res.id]);
      });
    }
  }
  delete() {
    if (confirm('Are you sure??')) {
      this.installmentservice.delete(this.installment.id).subscribe(res => {
        this.router.navigate(['/client/' + this.installment.clientId]);
      });
    }
  }
  changeDate() {
    let iddate: IdDatePair = {
      id: this.installment.id,
      Date: this.installment.nextPayment,
    };
    this.installmentservice.updateNextPayment(iddate).subscribe(res => {
      this.router.navigate(['/installment/' + res.id]);
    });
  }
}
