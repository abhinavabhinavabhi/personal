import { Component, OnInit, Inject } from '@angular/core';
import { inject } from '@angular/core/testing';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { Student } from 'src/model/studentModel';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-editform',
  templateUrl: './editform.component.html',
  styleUrls: ['./editform.component.css']
})
export class EditformComponent implements OnInit {
  datas: Student;
  form: FormGroup;
  constructor(private fb: FormBuilder, private dialogref: MatDialogRef<EditformComponent>, @Inject(MAT_DIALOG_DATA) data: Student) {
    this.datas = data;
    this.form = fb.group({
      id: [data.id],
      name: [data.name, Validators.required],
      salary: [data.salary, Validators.required],
      location: [data.location, Validators.required],
      city: [data.city, Validators.required]
    });
  }

  ngOnInit(): void {
  }

  close() {
    this.dialogref.close();
  }
  save() {
    this.dialogref.close(this.form.value);
  }

}
