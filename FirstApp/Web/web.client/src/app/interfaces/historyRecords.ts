import { IRecord } from "./record";

export interface IHistoryRecords {
    "pageSize":number,
    "pageIndex":number,
    "totalCount":number,
    "records": IRecord[]

}