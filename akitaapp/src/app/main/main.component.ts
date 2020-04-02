import { Component, OnInit } from '@angular/core';
import { BookStore } from '../state/book.store';
import { BookService } from '../state/book.service';
import { BookQuery } from '../state/book.query';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { map } from 'rxjs/operators';
import { Observable } from 'rxjs';
import { Book } from '../state/book.model';

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.css']
})
export class MainComponent implements OnInit {

  books$: Observable<Book[]>;
  boo$: Book[];
  selectLoading$: Observable<boolean>;

  constructor(private bookstore: BookStore, private booksrvice: BookService, private bookquery: BookQuery) { }
  public postform = new FormGroup({
    name: new FormControl("", Validators.required),
  });





  ngOnInit(): void {

    this.books$ = this.bookquery.selectAll();
    this.selectLoading$ = this.bookquery.selectLoading();
    this.getBooks();

    // this.books$ = this.bookquery.selectFirst();
    // console.log(this.books$);
    console.log(this.bookstore["storeValue"]["entities"]);
    // // this.bookquery.selectAll().pipe(map(val => this.boo$ = val));
    // console.log(this.boo$);
  }

  getBooks() {

    this.booksrvice.get().subscribe();

  }

}
