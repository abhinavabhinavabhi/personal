import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CourseComponent } from './course/course.component';
import { HomeComponent } from './home/home.component';
import {AboutComponent} from './about/about.component';
import {TableComponent} from './table/table.component';
import { EditComponent } from './edit/edit.component';
const routes: Routes = [
    {
        path: "",
        component: HomeComponent,

    },
    {
        path: "home",
        component: HomeComponent,

    },
    {
        path: "about",
        component: AboutComponent,

    },
    {
        path: "table",
        component: TableComponent,

    },
    {
      path: "edit",
      component: EditComponent,

  },
];

@NgModule({
    imports: [
        RouterModule.forRoot(routes)
    ],
    exports: [
        RouterModule
    ],
    declarations: []
})
export class AppRoutingModule { }
