import { OperationType } from "./operationType";

export interface IRecord {    
    "id": number,
    "event":OperationType,
    "property":string,
    "origin": string,
    "destination":string,
    "dateTime": Date,
}