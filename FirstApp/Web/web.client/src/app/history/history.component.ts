import { ChangeDetectorRef, Component, Input } from '@angular/core';
import { IHistoryRecords } from '../interfaces/historyRecords';
import axios from 'axios';
import { IPaginatedRecordsRequest } from '../interfaces/paginatedRecordsRequest';
import { IRecord } from '../interfaces/record';
import { OperationType } from '../interfaces/operationType';

@Component({
  selector: 'app-history',
  templateUrl: './history.component.html',
  styleUrl: './history.component.css'
})
export class HistoryComponent {
  @Input() cardId!:number;
  pageSize:number = 7;
  pageIndex:number = 0;
  isLoading:boolean = true;
  totalRecordsCount:number=0;
  isShowMoreVisible:boolean = true;
  OperationType=OperationType;
  displayRecords: IRecord[] = []
  records: IHistoryRecords = {pageIndex:this.pageIndex, pageSize:this.pageSize, totalCount:0,  records:[]};
  constructor(private cdr: ChangeDetectorRef) { }
  async ngOnInit() {
    await this.getRecords();
  };

  async loadMoreRecords() {
    this.pageIndex ++;
    this.requestRecords();

  }
  getRecords(){
    this.requestRecords();
  }
  
  async requestRecords(){
    if(this.cardId === undefined)
    {
      let request:IPaginatedRecordsRequest = { pageSize:this.pageSize, pageIndex:this.pageIndex };
      let result = await axios.post<IHistoryRecords>(`http://localhost:5007/history/userRecords`, request);
      this.isLoading = false;
      result.data.records.forEach(elem=>{
      this.displayRecords.push(elem);
      });
      this.totalRecordsCount = result.data.totalCount;
      this.cdr.detectChanges();
    }
    if(this.cardId !== undefined)
    {
      let request = { pageSize:this.pageSize, pageIndex:this.pageIndex , id:this.cardId };
      let result = await axios.post<IHistoryRecords>(`http://localhost:5007/history/cardRecords`, request);
      this.isLoading = false;
      this.totalRecordsCount = result.data.totalCount;
      result.data.records.forEach(elem=>{
      this.displayRecords.push(elem);
      });
      this.cdr.detectChanges();
    }
    if( this.displayRecords.length >= this.totalRecordsCount)
      {
        this.isShowMoreVisible=false;
      }
  }
}
