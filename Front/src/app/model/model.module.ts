import { NgModule } from "@angular/core";
import { AnswerRepository } from "./repository/answerRepository";
import { BlockRepository } from "./repository/blockRepository";
import { CourseRepository } from "./repository/courseRepository";
import { DirectionRepository } from "./repository/directionRepository";
import { GroupRepository } from "./repository/groupRepository";
import { PageRepository } from "./repository/pageRepository";
import { ParticipantRepository } from "./repository/participantRepository";
import { QuestionRepository } from "./repository/questionRepository";
import { UserRepository } from "./repository/userRepository";
import { HttpClientModule } from "@angular/common/http";
import { Repository } from "./repository/repository";

@NgModule({
    imports: [ HttpClientModule ],
    providers: [ AnswerRepository, BlockRepository, CourseRepository, QuestionRepository, UserRepository,
        DirectionRepository, GroupRepository, PageRepository, ParticipantRepository, AnswerRepository,
         Repository]
})

export class ModelModule {}