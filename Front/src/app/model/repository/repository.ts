import { Injectable } from "@angular/core";

@Injectable()
export class Repository{
    API: string = "https://lms.redoctopus.studio/";
    userAPI: string = this.API + "api/user/";
    directionAPI: string = this.API + "api/direction/";
    answerAPI: string = this.API + "api/answer/";
    blockAPI: string = this.API + "api/block/";
    courseAPI: string = this.API + "api/course/";
    groupAPI: string = this.API + "api/group/";
    pageAPI: string = this.API + "api/page/";
    participantAPI: string = this.API + "api/participant/";
    questionAPI: string = this.API + "api/question/";
    administrationAPI: string = this.API + "api/administration/";
    blockTypeAPI: string = this.API + "api/blockType/";
    administrationRoleAPI: string = this.API + "api/administrationRole/";
    participantRoleAPI: string = this.API + "api/participantRole/"
}