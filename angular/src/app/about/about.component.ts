import { Component, OnInit } from '@angular/core';
import { Observable, fromEvent, concat, of } from 'rxjs';
import { Student } from 'src/model/studentModel';
import { httpobserver } from '../common/ultil';
import { student } from 'src/dbdata';
import { map, tap, concatMap } from 'rxjs/operators';
import { StudentserviceService } from '../studentservices/studentservice.service';

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


  constructor(private studentservice: StudentserviceService) { }

  ngOnInit(): void {
    this.load();

    // const clicks = fromEvent(document, 'click');
    // const positions = clicks.pipe(
    //   tap(ev => console.log(ev)),
    //   map(ev => ev),
    // );
    // positions.subscribe(x => console.log(x));
    //student$.subscribe(val=>console.log(val.salary) );
  }
  emmitedvalue(stud: Student) {
    const serv1$ = this.studentservice.putstudent(stud);
    const serv2$=serv1$.pipe(concatMap(val=>this.load())).subscribe();
    
  }

  load() {

    const students$ = httpobserver("http://localhost:63314/api/Student");
    const studen$: Observable<Student[]> = students$.pipe(map(val => val));

    this.lessAmound$ = studen$.pipe(map(stu => stu.filter(stud => stud.salary < 1000)));

    this.mediumamd$ = studen$.pipe(map(med => med.filter(medd => medd.salary > 1000 && medd.salary < 200000)));

    this.largeamd$ = studen$.pipe(map(large => large.filter(larg => larg.salary > 200000)));
    return students$.pipe(map(val => val));
  }

}
