import { Administration } from "./Administration.model";

export class AdministrationRole{
    constructor(public id?: string,
        name?: string,
        public administration: Administration[] = new Array()) {}
}