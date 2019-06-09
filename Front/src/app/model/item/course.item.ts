import { IChildItem } from "src/app/shared/services/navigation.service";

export class CourseItem implements IChildItem{
    constructor(public name: string,
        public id?: string,
        public parentId?: string,
        public state?: string,
        public type?: string) {}
}
