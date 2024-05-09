import { IRecord } from "./record";

export interface IHistoryRecords {
    "pageSize":number,
    "pageIndex":number,
    "Records": IRecord[]

}