import { Component } from '@angular/core';
import { IHistoryRecords } from '../interfaces/historyRecords';
import axios from 'axios';
import { IPaginatedRecordsRequest } from '../interfaces/paginatedRecordsRequest';

@Component({
  selector: 'app-history',
  templateUrl: './history.component.html',
  styleUrl: './history.component.css'
})
export class HistoryComponent {
  pageSize:number = 7;
  pageIndex:number = 0;
  records!: IHistoryRecords;
  async ngOnInit() {
    try {
      console.log("I'm deleting the card");
      let request:IPaginatedRecordsRequest = { pageSize:this.pageSize, pageIndex:this.pageIndex };
      let result = await axios.post<IHistoryRecords>(`http://localhost:5007/history/userRecords`, request);
      this.records.Records = result.data.Records;
      console.log(this.records);
    } catch (error) {
      console.error(error);
    };

  }
}
