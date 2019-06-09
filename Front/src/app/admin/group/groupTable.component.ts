import { Component, Input } from "@angular/core";
import { GroupRepository } from "src/app/model/repository/groupRepository";
import { Group } from "src/app/model/Group.model";

@Component({
    selector: "group-table",
    templateUrl: "template/groupTable.template.html"
})

export class GroupTableComponent{
    constructor(private repo: GroupRepository) {}

    ngOnInit(){
        if (this.courseId == null)
            this.getGroups();
        else
            this.getGroupByCourse(this.courseId);
    }

    @Input() courseId: string;

    groups: Group[];

    getGroups(){
        this.repo.getGroups().subscribe(
            data => this.groups = data,
            error => this.groups = null);
    }

    getGroupByCourse(id:string){
        this.repo.getGroupByCourse(id).subscribe(
            data => this.groups = data,
            error => this.groups = null);
    }

    deleteGroup(id: string){
        this.repo.deleteGroup(id).subscribe(
            data =>  this.groups.splice(this.groups.findIndex(c => c.id == id),1)
        );
    }
}