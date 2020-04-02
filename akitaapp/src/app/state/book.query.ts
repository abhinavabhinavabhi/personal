import { Injectable } from '@angular/core';
import { QueryEntity } from '@datorama/akita';
import { BookStore, BookState } from './book.store';
import { Book } from './book.model';

@Injectable({ providedIn: 'root' })
export class BookQuery extends QueryEntity<BookState, Book> {

  constructor(protected store: BookStore) {
    super(store);
  }

}
