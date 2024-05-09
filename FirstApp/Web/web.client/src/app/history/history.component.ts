import { ChangeDetectorRef, Component } from '@angular/core';
import { IHistoryRecords } from '../interfaces/historyRecords';
import axios from 'axios';
import { IPaginatedRecordsRequest } from '../interfaces/paginatedRecordsRequest';
import { IRecord } from '../interfaces/record';

@Component({
  selector: 'app-history',
  templateUrl: './history.component.html',
  styleUrl: './history.component.css'
})
export class HistoryComponent {
  pageSize:number = 7;
  pageIndex:number = 0;
  isLoading:boolean = false;
  displayRecords: IRecord[] = []
  records: IHistoryRecords = {pageIndex:this.pageIndex, pageSize:this.pageSize, Records:[]};
  constructor(private cdr: ChangeDetectorRef) { }
  async ngOnInit() {
    await this.getRecords();
  };
  async getRecords(){    
    try {
      console.log("I'm trying to get history");
      let request:IPaginatedRecordsRequest = { pageSize:this.pageSize, pageIndex:this.pageIndex };
      let result = await axios.post<IHistoryRecords>(`http://localhost:5007/history/userRecords`, request);
      console.log(result.data);
      this.isLoading = true;
      this.records = result.data;
      this.displayRecords = this.records.Records;
      console.log(this.records);
      this.cdr.detectChanges();
    } catch (error) {
      console.error(error);
    };
  } 
}
