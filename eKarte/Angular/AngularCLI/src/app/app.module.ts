import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

// import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { KarteIndexComponent } from './karte/karte-index/karte-index.component';
import { HttpClientModule } from '@angular/common/http'
import { APP_BASE_HREF } from '@angular/common';

@NgModule({
  declarations: [
    AppComponent,
    KarteIndexComponent
  ],
  imports: [
    BrowserModule,
    // AppRoutingModule,
    HttpClientModule

  ],
  providers: [{provide: APP_BASE_HREF, useValue : '/' }],
  bootstrap: [AppComponent]
})
export class AppModule { }
