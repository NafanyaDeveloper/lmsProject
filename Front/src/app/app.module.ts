import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { AdminModule } from './admin/admin.module';
import { DirectionRepository } from './model/repository/directionRepository';
import { Repository } from './model/repository/repository';
import { ModelModule } from './model/model.module';
import { AnswerRepository } from './model/repository/answerRepository';
import { BlockRepository } from './model/repository/blockRepository';
import { CourseRepository } from './model/repository/courseRepository';
import { QuestionRepository } from './model/repository/questionRepository';
import { UserRepository } from './model/repository/userRepository';
import { GroupRepository } from './model/repository/groupRepository';
import { PageRepository } from './model/repository/pageRepository';
import { ParticipantRepository } from './model/repository/participantRepository';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { AdministrationRepository } from './model/repository/administrationRepository';
import { AdministrationRoleRepository } from './model/repository/administrationRoleRepository';
import { ParticipantRoleRepository } from './model/repository/participantRoleRepository';
import { BlockTypeRepository } from './model/repository/blockTypeRepository';
import { SharedModule } from './shared/shared.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AdminLayoutSidebarLargeComponent } from './shared/components/layouts/admin-layout-sidebar-large/admin-layout-sidebar-large.component';
import { DirectionToItemConverter } from './model/converter/DirectionToItem.converter';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { AuthLayoutComponent } from './shared/components/layouts/auth-layout/auth-layout.component';
import { AuthGaurd, SignGaurd } from './shared/services/auth.gaurd';
import { AuthInterceptorService } from './shared/services/authinterceptor.service';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    NgbModule,
    BrowserModule,
    SharedModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    ModelModule,
    FontAwesomeModule,
    RouterModule.forRoot([
      {path: "admin",
        loadChildren: "./admin/admin.module#AdminModule" 
      },
      {
        path: '',
        component: AuthLayoutComponent,
        canActivate: [SignGaurd],
        children: [
          {
            path: 'sessions',
            loadChildren: './views/sessions/sessions.module#SessionsModule'
          }
        ]
      },
      {
        path: '',
        component: AdminLayoutSidebarLargeComponent,
        canActivate: [AuthGaurd],
        children: [
          {
            path: '',
            loadChildren: './lms/lms.module#LmsModule'
          }]
      },
    ])
  ],
  providers: [ AdministrationRepository, AdministrationRoleRepository, ParticipantRoleRepository, BlockTypeRepository,
    AnswerRepository, BlockRepository, CourseRepository, QuestionRepository, UserRepository,
    DirectionRepository, GroupRepository, PageRepository, ParticipantRepository, DirectionToItemConverter,
     Repository,
     {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthInterceptorService,
      multi: true
    },
      AuthGaurd, SignGaurd],
  bootstrap: [AppComponent]
})
export class AppModule { }
