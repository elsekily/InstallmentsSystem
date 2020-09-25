import { Component, OnInit } from '@angular/core';
import { InstallmentSummary } from '../../models/installment';
import { InstallmentService } from '../../services/installment.service';

@Component({
  selector: 'app-lateinstallments',
  templateUrl: './lateinstallments.component.html',
  styleUrls: ['./lateinstallments.component.css']
})
export class LateinstallmentsComponent implements OnInit {

  allinstallments: InstallmentSummary[];
  installments: InstallmentSummary[];

  constructor(private installmentservice: InstallmentService) { }

  ngOnInit() {
    this.installmentservice.getLateInstallments().subscribe(res => {
      this.installments = res;
      this.allinstallments = res;
    });
  }

}
