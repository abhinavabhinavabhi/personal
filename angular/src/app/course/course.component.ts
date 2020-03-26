import { Component, OnInit, Input, EventEmitter, Output,AfterViewInit, ElementRef ,ViewChild} from '@angular/core';
import { Student } from 'src/model/studentModel';
import { timer, fromEvent, Observable, noop, from ,of, concat} from 'rxjs';
import { map ,concatMap,exhaustMap} from 'rxjs/operators';
import { httpobserver } from '../common/ultil';




@Component({
  selector: 'app-course',
  templateUrl: './course.component.html',
  styleUrls: ['./course.component.css']
})
export class CourseComponent implements OnInit {


  @Input()
  stud: Student;

  @Input()
  ind: number;

  @Input()
  salary:number;
  // @Output()
  // courseemitter=new EventEmitter(); 
  @Output()
  studentemitter = new EventEmitter<Student>();

  @ViewChild('selevtedbutt')
  selected:ElementRef;

  @ViewChild('salaryedit',{static:true})
  selectedtext:ElementRef;

  constructor() {

  }


  ngAfterViewInit()
  {
    fromEvent(this.selected.nativeElement,'click').pipe(exhaustMap(()=>this.select())).subscribe()//concat map one done then another exhust map if on is processing then other is not taken
  } 

  ngOnInit(): void {

    // const http$ = httpobserver("http://localhost:63314/api/Student");


    // // const student$ = http$.pipe(map(res => Object.values(res["student"]))
    // // );

    // // student$.subscribe(val => console.log(val), noop, () => console.log("completed"));
    // http$.subscribe(student => console.log("kjbdfsjks", student),
    //   noop,
    //   () => console.log("completed")
    // );
    const source1$=of(1,2,3);
    const source2$=of(4,5,6);
    const source3$=of(7,8,9);

    const result$=concat(source1$,source2$,source3$);

    result$.subscribe(console.log);




    const interval$ = timer(3000, 1000);
    const sub = interval$.subscribe(val => console.log(val)
    );
    setTimeout(() => sub.unsubscribe(), 5000);
    const click$ = fromEvent(document.getElementById("clicked"), 'click');

    click$.subscribe(val => console.log(val),
      err => console.log(err),
      () => console.log("completed")
    );

  }

  less() {
    if (this.stud.salary < 1000) {
      return 'less';
    }
    else if (this.stud.salary > 200000) {
      return 'dist';
    }


  }

  lessThanSix() {
    if (this.stud.salary < 100000) {
      return true
    }
  }

  select() {
    console.log("selected", this.selectedtext.nativeElement.value );
    this.stud.salary = this.selectedtext.nativeElement.value;
    this.studentemitter.emit(this.stud);
    return fetch(`http://localhost:63314/api/Student/${this.stud.id}`,{
       method:'PUT',
       body:JSON.stringify(this.stud),
        headers:{
         'content-type':'application/json'
       }

     });
     
  }



}

