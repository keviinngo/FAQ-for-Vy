//import './polyfills';

import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HttpClientJsonpModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';
//import { MatTreeModule, MatIconModule, MatButtonModule } from '@angular/material';
//import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';
//import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
//import { DemoMaterialModule } from './material-module';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { FAQComponent } from './FAQ/FAQ.component';
import { BrukerComponent } from './bruker/bruker.component';

//import { TreeDynamicExample } from './test/tree-dynamic-example';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
        FetchDataComponent,
        FAQComponent,
        BrukerComponent
        //TreeDynamicExample,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
      HttpClientJsonpModule,
      ReactiveFormsModule,
      //MatTreeModule,    
      //BrowserAnimationsModule,
      //MatIconModule,
      //MatButtonModule,
      NgbModule,
        //DemoMaterialModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
        { path: 'FAQ', component: FAQComponent },
        { path: 'bruker', component: BrukerComponent },
        //{ path: 'test', component: TreeDynamicExample },
    ])
    ],
    providers: [],
    bootstrap: [AppComponent],
    //entryComponents: [TreeDynamicExample],
    
})
export class AppModule { }

//platformBrowserDynamic().bootstrapModule(AppModule);
