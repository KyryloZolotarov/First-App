import { ChangeDetectorRef, Component, Input, OnChanges, OnInit, SimpleChanges } from '@angular/core';
import { IList } from '../interfaces/list';
import axios from 'axios';
import { IBoardLists} from '../interfaces/boardLists';
import { IAvailableList } from '../interfaces/availableList';
import { IAddList } from '../interfaces/addList';
import { Store, select } from '@ngrx/store';
import * as ListActions from '../store/actions/list-actions';
import { Observable } from 'rxjs';
import { selectLists } from '../store/selectors/list-selectors';
import { RootState } from '../store/interfaces/root-state';

@Component({
  selector: 'app-work-dashboard',
  templateUrl: './work-dashboard.component.html',
  styleUrl: './work-dashboard.component.css'
})
export class WorkDashboardComponent implements OnInit, OnChanges {

@Input() boardSelected!:number;
lists$: Observable<IList[]> = new Observable<IList[]>();
addList: IAddList = { title : "", boardId: 0};
availableListsForCards: IAvailableList[] = [];
addingNewList:boolean = false;
isDropdownOpen: boolean = false;
currentBordId!:number;

constructor(private store: Store<RootState>) 
{
  this.lists$ = this.store.select(selectLists);
}

async ngOnInit() {
  await this.getLists();
}

async ngOnChanges(changes: SimpleChanges) {
  this.addingNewList = false;
  await this.getLists();
}

public async getLists(): Promise<void> {
  this.store.dispatch(ListActions.getLists({ boardId: this.boardSelected }));
}

async onAddList(){
  this.addList.boardId = this.boardSelected;
  this.store.dispatch(ListActions.addList({ title:this.addList.title, boardId:this.addList.boardId}));
  this.addingNewList = false;
  this.addList = { title : "", boardId: 0};
}

toggleDropdown() {
  this.isDropdownOpen = !this.isDropdownOpen;
}
async refresh(){
  await this.getLists();
}
}
