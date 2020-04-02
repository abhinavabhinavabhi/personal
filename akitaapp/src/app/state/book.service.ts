import { Injectable } from '@angular/core';
import { ID } from '@datorama/akita';
import { HttpClient } from '@angular/common/http';
import { BookStore } from './book.store';
import { BookQuery } from './book.query';
import { Book } from './book.model';
import { tap, mapTo, map } from 'rxjs/operators';
import { books } from '../booksdata';
import { timer } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class BookService {

  constructor(private bookStore: BookStore,
    private booksquery: BookQuery,
    private http: HttpClient) {
  }

  get() {
    return this.http.get<Book[]>('http://localhost:63314/api/Student').pipe(tap(entities => {
      this.bookStore.set(entities);
    }));

    // this.bookStore.set(books);
    // console.log(this.bookStore["storeValue"]["entities"]);

  }

  getbook(id: ID) {
    if (this.booksquery.hasEntity(id)) {
      return this.booksquery.selectEntity(id);
    }

  }

  add(book: Book) {
    this.bookStore.add(book);
  }

  update(id, book: Partial<Book>) {
    this.bookStore.update(id, book);
  }

  remove(id: ID) {
    this.bookStore.remove(id);
  }
}
