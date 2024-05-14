import { ICard } from "./card";

export interface IList{
    id : number,
    title: string,
    boardId:number,
    cards: ICard[]
}