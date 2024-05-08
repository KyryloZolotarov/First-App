import { Priority } from "./priority"

export interface IAddCard{
    "Name": string,
    "Description": string
    "Priority": Priority
    "ListId": number,
    "DueDate": string
}