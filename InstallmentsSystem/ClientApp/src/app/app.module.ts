import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { NavMenuComponent } from './components/nav-menu/nav-menu.component';
import { HomeComponent } from './components/home/home.component';
import { ClientFormComponent } from './components/client-form/client-form.component';
import { ClientService } from './services/client.service';
import { ClientListComponent } from './components/client-list/client-list.component';
import { InstallmentFormComponent } from './components/installment-form/installment-form.component';
import { InstallmentService } from './services/installment.service';
import { ErrorComponent } from './components/error/error.component';
import { PaymentformComponent } from './components/paymentform/paymentform.component';
import { PaymentService } from './services/payment.service';
import { AuthService } from './services/auth.service';
import { LateinstallmentsComponent } from './components/lateinstallments/lateinstallments.component';
import { AuthGuard } from './services/AuthGuard.service';
import { JwtModule } from '@auth0/angular-jwt';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    ClientFormComponent,
    ClientListComponent,
    InstallmentFormComponent,
    ErrorComponent,
    PaymentformComponent,
    LateinstallmentsComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    JwtModule.forRoot({
      config: {
        tokenGetter: () => { return localStorage.getItem('token') },
      }
    }),
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'error', component: ErrorComponent },
      { path: 'client', component: ClientListComponent, canActivate: [AuthGuard] },
      { path: 'client/new', component: ClientFormComponent, canActivate: [AuthGuard] },
      { path: 'client/:id', component: ClientFormComponent, canActivate: [AuthGuard] },
      { path: 'installment/new/:clientid', component: InstallmentFormComponent, canActivate: [AuthGuard] },
      { path: 'installment/:id', component: InstallmentFormComponent, canActivate: [AuthGuard] },
      { path: 'payment/:installmentid', component: PaymentformComponent, canActivate: [AuthGuard] },
      { path: 'lateinstallments', component: LateinstallmentsComponent, canActivate: [AuthGuard] },
    ])
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
