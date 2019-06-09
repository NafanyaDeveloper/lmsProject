import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { FormsModule } from "@angular/forms";
import { RouterModule } from "@angular/router";
import { AuthComponent } from "./auth/auth.component";
import { AdminComponent } from "./admin/admin.component";
import { DirectionEditorComponent } from "./direction/directionEditor.component";
import { DirectionTableComponent } from "./direction/directionTable.component";
import { ModelModule } from "../model/model.module";
import { DirectionInfoComponent } from "./direction/directionInfo.component";
import { CourseTableComponent } from "./course/courseTable.component";
import { CourseEditorComponent } from "./course/courseEdit.component";
import { CourseInfoComponent } from "./course/courseInfo.component";
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { GroupTableComponent } from "./group/groupTable.component";
import { GroupEditorComponent } from "./group/groupEdit.component";
import { GroupInfoComponent } from "./group/groupInfo.component";
import { PageTableComponent } from "./page/pageTable.component";
import { PageInfoComponent } from "./page/pageInfo.component";
import { PageEditorComponent } from "./page/pageEditor.component";
import { UserTableComponent } from "./user/userTable.component";
import { UserInfoComponent } from "./user/userInfo.component";
import { UserEditorComponent } from "./user/userEditor.component";
import { AdministrationRoleEditorComponent } from "./administrationRole/administrationRoleEditor.component";
import { AdministrationRoleInfoComponent } from "./administrationRole/administrationRoleInfo.component";
import { AdministrationRoleTableComponent } from "./administrationRole/administrationRoleTable.component";
import { AdministrationEditorComponent } from "./administration/administrationEditor.component";
import { AdministrationInfoComponent } from "./administration/administrationInfo.component";
import { AdministrationTableComponent } from "./administration/administrationTable.component";
import { ParticipantTableComponent } from "./participant/participantTable.component";
import { ParticipantInfoComponent } from "./participant/participantInfo.component";
import { ParticipantEditorComponent } from "./participant/participantEditor.component";
import { ParticipantRoleTableComponent } from "./participantRole/participantRoleTable.component";
import { ParticipantRoleInfoComponent } from "./participantRole/participantRoleInfo.component";
import { ParticipantRoleEditorComponent } from "./participantRole/participantRoleEditor.component";
import { BlockTypeEditorComponent } from "./blockType/blockTypeEditor.component";
import { BlockTypeInfoComponent } from "./blockType/blockTypeInfo.component";
import { BlockTypeTableComponent } from "./blockType/blockTypeTable.component";
import { BlockTableComponent } from "./block/blockTable.component";
import { BlockEditorComponent } from "./block/blockEditor.component";
import { BlockInfoComponent } from "./block/blockInfo.component";
import { QuestionEditorComponent } from "./question/questionEditor.component";
import { QuestionInfoComponent } from "./question/questionInfo.component";
import { QuestionTableComponent } from "./question/questionTable.component";
import { AnswerEditorComponent } from "./answer/answerEditor.component";
import { AnswerInfoComponent } from "./answer/answerInfo.component";
import { AnswerTableComponent } from "./answer/answerTable.component";


let routing = RouterModule.forChild([
    {path: "auth", component: AuthComponent},
    {path: "main", component: AdminComponent,
        children: [
            {path: "directions/info/:id", component: DirectionInfoComponent},
            {path: "directions/:mode/:id", component: DirectionEditorComponent},
            {path: "directions/:mode", component: DirectionEditorComponent},
            {path: "directions", component: DirectionTableComponent},
            {path: "courses", component: CourseTableComponent},
            {path: "courses/info/:id", component: CourseInfoComponent},
            {path: "courses/:mode/:id", component: CourseEditorComponent},
            {path: "courses/:mode", component: CourseEditorComponent},
            {path: "groups", component: GroupTableComponent},
            {path: "groups/info/:id", component: GroupInfoComponent},
            {path: "groups/:mode/:id", component: GroupEditorComponent},
            {path: "groups/:mode", component: GroupEditorComponent},
            {path: "pages", component: PageTableComponent},
            {path: "pages/info/:id", component: PageInfoComponent},
            {path: "pages/:mode/:id", component: PageEditorComponent},
            {path: "pages/:mode", component: PageEditorComponent},
            {path: "users", component: UserTableComponent},
            {path: "users/info/:id", component: UserInfoComponent},
            {path: "users/:mode/:id", component: UserEditorComponent},
            {path: "users/:mode", component: UserEditorComponent},
            {path: "administrationRoles", component: AdministrationRoleTableComponent},
            {path: "administrationRoles/info/:id", component: AdministrationRoleInfoComponent},
            {path: "administrationRoles/:mode/:id", component: AdministrationRoleEditorComponent},
            {path: "administrationRoles/:mode", component: AdministrationRoleEditorComponent},
            {path: "administrations", component: AdministrationTableComponent},
            {path: "administrations/info/:userId/:directionId", component: AdministrationInfoComponent},
            {path: "administrations/:mode/:userId/:directionId", component: AdministrationEditorComponent},
            {path: "administrations/:mode", component: AdministrationEditorComponent},
            {path: "participants", component: ParticipantTableComponent},
            {path: "participants/info/:userId/:groupId", component: ParticipantInfoComponent},
            {path: "participants/:mode/:userId/:groupId", component: ParticipantEditorComponent},
            {path: "participants/:mode", component: ParticipantEditorComponent},
            {path: "participantRoles", component: ParticipantRoleTableComponent},
            {path: "participantRoles/info/:id", component: ParticipantRoleInfoComponent},
            {path: "participantRoles/:mode/:id", component: ParticipantRoleEditorComponent},
            {path: "participantRoles/:mode", component: ParticipantRoleEditorComponent},
            {path: "blockTypes", component: BlockTypeTableComponent},
            {path: "blockTypes/info/:id", component: BlockTypeInfoComponent},
            {path: "blockTypes/:mode/:id", component: BlockTypeEditorComponent},
            {path: "blockTypes/:mode", component: BlockTypeEditorComponent},
            {path: "blocks", component: BlockTableComponent},
            {path: "blocks/info/:id", component: BlockInfoComponent},
            {path: "blocks/:mode/:id", component: BlockEditorComponent},
            {path: "blocks/:mode", component: BlockEditorComponent},
            {path: "questions", component: QuestionTableComponent},
            {path: "questions/info/:id", component: QuestionInfoComponent},
            {path: "questions/:mode/:id", component: QuestionEditorComponent},
            {path: "questions/:mode", component: QuestionEditorComponent},
            {path: "answers", component: AnswerTableComponent},
            {path: "answers/info/:id", component: AnswerInfoComponent},
            {path: "answers/:mode/:id", component: AnswerEditorComponent},
            {path: "answers/:mode", component: AnswerEditorComponent},
            {path: "**", redirectTo: "directions"}
        ]},
    {path: "**", redirectTo: "auth"}
]);

@NgModule({
    imports: [ CommonModule, FormsModule, routing, ModelModule, FontAwesomeModule],
    declarations: [AuthComponent, AdminComponent, DirectionEditorComponent, DirectionTableComponent, 
        DirectionInfoComponent, CourseTableComponent, CourseEditorComponent, CourseInfoComponent,
          GroupTableComponent, GroupEditorComponent, GroupInfoComponent, PageTableComponent, PageInfoComponent, 
        PageEditorComponent, UserTableComponent, UserInfoComponent, UserEditorComponent, 
        AdministrationRoleEditorComponent, AdministrationRoleInfoComponent, AdministrationRoleTableComponent,
    AdministrationEditorComponent, AdministrationInfoComponent, AdministrationTableComponent, ParticipantEditorComponent,
    ParticipantInfoComponent, ParticipantTableComponent, ParticipantRoleEditorComponent, ParticipantRoleInfoComponent,
    ParticipantRoleTableComponent, BlockTypeTableComponent, BlockTypeInfoComponent, BlockTypeEditorComponent,
    BlockEditorComponent, BlockTableComponent, BlockInfoComponent, QuestionEditorComponent, QuestionInfoComponent,
    QuestionTableComponent, AnswerEditorComponent, AnswerInfoComponent, AnswerTableComponent],
    providers: []
})

export class AdminModule {}