import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Student } from 'src/model/studentModel';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class StudentserviceService {

  constructor( private http:HttpClient) { 

  }
 getallStudent(): Observable<Student[]>{
   
    return this.http.get<Student[]>('http://localhost:63314/api/Student');
  }

  putstudent(stud:Student)
  {
 return this.http.put(`http://localhost:63314/api/Student/${stud.id}`,stud);
  }
}
