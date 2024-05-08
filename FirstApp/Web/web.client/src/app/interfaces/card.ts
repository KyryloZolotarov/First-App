import { Priority } from "./priority"

export interface ICard{
    id: number,
    name: string,
    description: string
    priority: Priority
    listId: number,
    dueDate: Date
}