import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { Student } from 'src/model/studentModel';
import { httpobserver } from './ultil';
import { map, tap } from 'rxjs/operators';


@Injectable({
  providedIn: 'root'
})
export class Store {
  private studentsub = new BehaviorSubject<Student[]>([]);

  student$: Observable<Student[]> = this.studentsub.asObservable();

  init() {
    const http$ = httpobserver("http://localhost:63314/api/Student");
    http$.pipe(
      tap(() => console.log("request executed")),
      map(val => val)).subscribe(stu => this.studentsub.next(stu));
  }
}
