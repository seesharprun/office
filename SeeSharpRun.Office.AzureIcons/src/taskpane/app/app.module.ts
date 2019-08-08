import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppComponent } from './app.component';
import { SanitizePipe } from './pipes.sanitizer';

@NgModule({
  declarations: [ AppComponent, SanitizePipe ],
  imports: [ BrowserModule ],
  bootstrap: [ AppComponent ]
})
export default class AppModule { }