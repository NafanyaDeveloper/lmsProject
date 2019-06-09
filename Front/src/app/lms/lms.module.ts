import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { FormsModule } from "@angular/forms";
import { RouterModule } from "@angular/router";
import { MainPageComponent } from "./main/mainPage.component";
import { BuyCourseComponent } from "./buyCourse/buyCourse.component";
import { CalendarComponent } from "../views/calendar/calendar/calendar.component";
import { NgbModule } from "@ng-bootstrap/ng-bootstrap";



let routing = RouterModule.forChild([
    {path: "main", component: MainPageComponent,
        children: [
            {path: "course/pay/:id", component: BuyCourseComponent},
            {
                path: 'calendar',
                loadChildren: '../views/calendar/calendar.module#CalendarAppModule'
            },
            {path: "**", redirectTo: "calendar"}
        ]}
]);

@NgModule({
    imports: [ CommonModule, FormsModule, routing, NgbModule],
    declarations: [ MainPageComponent, BuyCourseComponent],
    providers: []
})

export class LmsModule {}