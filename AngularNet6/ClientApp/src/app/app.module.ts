import { ToasterComponent } from './shared/components/toaster/toaster.component';
import { ToastComponent } from './shared/components/toast/toast.component';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { DemoAlertComponent } from './demo-alert/demo-alert.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { AlertService } from './shared/services/alert.service';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    DemoAlertComponent,
    FetchDataComponent,
    ToastComponent,
    ToasterComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'demo-alert', component: DemoAlertComponent },
      { path: 'fetch-data', component: FetchDataComponent },
    ])
  ],
  providers: [AlertService],
  bootstrap: [AppComponent]
})
export class AppModule { }
