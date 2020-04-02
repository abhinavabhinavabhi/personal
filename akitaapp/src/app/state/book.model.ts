import { ID } from '@datorama/akita';
export interface Book {
  id: ID;
  name: string;
  location: string;
  city: string;
  salary: number;
}

// export function createBook(params: Partial<Book>) {
//   return {

//   } as Book;
// }
