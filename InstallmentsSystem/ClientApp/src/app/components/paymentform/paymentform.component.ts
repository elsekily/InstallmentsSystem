import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { InstallmentService } from '../../services/installment.service';
import { PaymentService } from '../../services/payment.service';
import { savePayment } from '../../models/payment';

@Component({
  selector: 'app-paymentform',
  templateUrl: './paymentform.component.html',
  styleUrls: ['./paymentform.component.css']
})
export class PaymentformComponent implements OnInit {

  installmentid: number;
  clientName: string;
  savepayment: savePayment = {
    installmentId:0,
    amount: 0,
    detials: ''
}

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private installmentservice: InstallmentService,
    private paymentservice: PaymentService
  ) {
    route.params.subscribe(p => {

      this.installmentid = +p['installmentid'] || 0;
    })
  }

  ngOnInit() {
    if (this.installmentid != 0) {
      this.installmentservice.getinstallment(this.installmentid)
        .subscribe(i => {
          this.installmentid = i.id;
          this.savepayment.installmentId = i.id;
          this.clientName = i.clientName;
        },
          msg => {
            if (msg.status == 404) {
              this.router.navigate(['/error']);
            }
          }
        );
    }
    else {
      this.router.navigate(['/error']);
    }
  }
  submit() {
    this.savepayment.amount = +this.savepayment.amount;
    this.paymentservice.create(this.savepayment).subscribe(i => {
      this.router.navigate(['/installment/' + i.id]);
    });
  }

}
