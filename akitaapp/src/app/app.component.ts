import { Component, OnInit } from '@angular/core';
import { BookService } from './state/book.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'akitaapp';
  constructor(private booksrvice: BookService) {

  }
  ngOnInit() {
    this.booksrvice.get();
  }
}
