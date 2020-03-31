import { Component, OnInit } from '@angular/core';
import { Observable, fromEvent, concat, of } from 'rxjs';
import { Student } from 'src/model/studentModel';
import { httpobserver } from '../common/ultil';
import { student } from 'src/dbdata';
import { map, tap, concatMap } from 'rxjs/operators';
import { StudentserviceService } from '../studentservices/studentservice.service';
import { Store } from '../common/store.service';

@Component({
  selector: 'app-about',
  templateUrl: './about.component.html',
  styleUrls: ['./about.component.css']
})
export class AboutComponent implements OnInit {
  stud$: Student[];
  lessAmound$: Observable<Student[]>;
  mediumamd$: Observable<Student[]>;
  largeamd$: Observable<Student[]>;


  constructor(private studentservice: StudentserviceService, private store: Store) { }

  ngOnInit(): void {
    this.load();

    // const clicks = fromEvent(document, 'click');
    // const positions = clicks.pipe(
    //   tap(ev => console.log(ev)),
    //   map(ev => ev),
    // );
    // positions.subscribe(x => console.log(x));
    // student$.subscribe(val=>console.log(val.salary) );
  }
  emmitedvalue(stud: Student) {
    const serv1$ = this.studentservice.putstudent(stud);
    const serv2$ = serv1$.pipe(concatMap(val => this.refresh()));
    concat(serv2$, this.load()).subscribe();
  }

  refresh() {
    this.store.init();
    return this.store.student$;
  }

  load() {

    const studen$: Observable<Student[]> = this.store.student$;

    this.lessAmound$ = studen$.pipe(map(stu => stu.filter(stud => stud.salary < 1000)));

    this.mediumamd$ = studen$.pipe(map(med => med.filter(medd => medd.salary > 1000 && medd.salary < 200000)));

    this.largeamd$ = studen$.pipe(map(large => large.filter(larg => larg.salary > 200000)));
    return this.store.student$;
  }

}
