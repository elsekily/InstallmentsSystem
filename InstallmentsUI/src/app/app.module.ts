import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ClientFormComponent } from './components/client-form/client-form.component';
import { ClientListComponent } from './components/client-list/client-list.component';
import { ErrorComponent } from './components/error/error.component';
import { HomeComponent } from './components/home/home.component';
import { InstallmentFormComponent } from './components/installment-form/installment-form.component';
import { LateinstallmentsComponent } from './components/lateinstallments/lateinstallments.component';
import { NavMenuComponent } from './components/nav-menu/nav-menu.component';
import { PaymentformComponent } from './components/paymentform/paymentform.component';
import { HttpClientModule } from '@angular/common/http';
import { ClientService } from './services/client.service';
import { InstallmentService } from './services/installment.service';
import { PaymentService } from './services/payment.service';
import { AuthService } from './services/auth.service';
import { AuthGuard } from './services/AuthGuard.service';
import { JwtModule } from '@auth0/angular-jwt';
import { FormsModule } from '@angular/forms';
import { environment } from 'src/environments/environment';

@NgModule({
  declarations: [
    AppComponent,
    ClientFormComponent,
    ClientListComponent,
    ErrorComponent,
    HomeComponent,
    InstallmentFormComponent,
    LateinstallmentsComponent,
    NavMenuComponent,
    PaymentformComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    JwtModule.forRoot({
      config: {
        tokenGetter: () => {
          return localStorage.getItem('token');
        },
        allowedDomains:["localhost:5260","localhost:7015"]
      }
    }),
    AppRoutingModule
  ],
  providers: [
    ClientService,
    InstallmentService,
    PaymentService,
    AuthService,
    AuthGuard,
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
