import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';

import { BookRoutingModule } from './book-routing.module';
import { CommonModule } from '@angular/common';
import { BooksComponent } from './books.component';

@NgModule({
  declarations: [

    BooksComponent
  ],
  imports: [
    CommonModule,
    BookRoutingModule,
    ReactiveFormsModule,

  ],
})
export class BookModule { }
