import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CourseComponent } from './course/course.component';
import { HomeComponent } from './home/home.component';
import {AboutComponent} from './about/about.component';

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