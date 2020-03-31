import { Component, OnInit } from '@angular/core';
import { Student } from 'src/model/studentModel';
import { httpobserver } from '../common/ultil';
import { map } from 'rxjs/operators';
import { MatTableDataSource } from '@angular/material/table';
import { Store } from '../common/store.service';

@Component({
  selector: 'app-table',
  templateUrl: './table.component.html',
  styleUrls: ['./table.component.css']
})
export class TableComponent implements OnInit {

  student: Student;
  datasc = new MatTableDataSource([]);
  displayedcols = ["sino", "name", "location", "salary"];
  constructor(private store: Store) { }

  ngOnInit(): void {
    this.datasc = Object(this.store.student$);
    // const stud$ = httpobserver("http://localhost:63314/api/Student");
    // this.datasc = stud$.pipe(map(arg => arg));
    // console.log(this.datasc);

  }
  selected(ame: any) {
    console.log(ame);
  }


}
