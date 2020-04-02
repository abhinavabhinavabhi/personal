import { Injectable } from '@angular/core';
import { Book } from './book.model';
import { EntityState, EntityStore, StoreConfig } from '@datorama/akita';

export interface BookState extends EntityState<Book> { }

@Injectable({ providedIn: 'root' })
@StoreConfig({ name: 'book' })
export class BookStore extends EntityStore<BookState, Book> {

  constructor() {
    super();
  }

}

