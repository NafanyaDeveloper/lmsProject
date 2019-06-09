import { Injectable } from "@angular/core";
import { IMenuItem, IChildItem } from "src/app/shared/services/navigation.service";
import { Direction } from "../Direction.model";
import { DirectionItem } from "../item/direction.item";
import { CourseItem } from "../item/course.item";


@Injectable()
export class DirectionToItemConverter{
    Convert(item: Direction): IMenuItem{
        let result: IChildItem[] = new Array();
        item.courses.forEach(function(elem){
            result.push({
                name: elem.name,
                state: '/course/pay/' + elem.id,
                type: 'link'
            });
        });
        return {
            name: item.name,
            description: item.name,
            type: 'dropDown',
            icon: 'i-Library',
            sub: result
        };
    }

    ConvertArray(items: Direction[]): IMenuItem[]{
        let result: IMenuItem[] = new Array();
        items.forEach(function(elem){
            let rc: IChildItem[] = new Array();
            elem.courses.forEach(function(e){
                rc.push({
                    name: e.name,
                    state: '/course/pay/' + e.id,
                    type: 'link'
                });
            });
            result.push({
                name: elem.name,
                description: elem.name,
                type: 'dropDown',
                icon: 'i-Library',
                sub: rc
            });
        });
        return result
    }
}