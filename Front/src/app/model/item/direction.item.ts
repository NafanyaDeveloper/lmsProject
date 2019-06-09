import { IMenuItem, IChildItem } from "src/app/shared/services/navigation.service";

export class DirectionItem implements IMenuItem{
    constructor(public type:string,
        public id?:string,
        public title?: string,
        public name?: string,
        public state?: string,
        public sub?: IChildItem[]) {}
}