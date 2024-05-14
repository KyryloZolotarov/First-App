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
  debugger;
}

async ngOnInit() {
  await this.getLists();
  this.store.pipe(select(selectLists)).subscribe(value=>console.log(value));
  this.lists$ = this.store.pipe(select(selectLists));
  console.log(this.lists$);
}

async ngOnChanges(changes: SimpleChanges) {
  this.addingNewList = false;
  
  console.log(this.lists$);
}

public async getLists(): Promise<void> {
  this.store.dispatch(ListActions.getLists({ boardId: this.boardSelected }));
}

async onAddList(){
  try {
    console.log("I'm trying to add list");
    this.addList.boardId = this.boardSelected;
    console.log(this.addList);
    let listId:number = await axios.post(`http://localhost:5007/lists/`, this.addList);
    let newList: IList = { id:listId, title:this.addList.title, boardId:this.currentBordId, cards:[] };
    console.log("Added list:", this.addList);
    this.addingNewList=false;
    this.refresh();
    console.log("Updated lists:", this.lists$);
  } catch (error) {
    console.error(error);
  };

}

toggleDropdown() {
  this.isDropdownOpen = !this.isDropdownOpen;
}
async refresh(){
  console.log("refreshing");
  await this.getLists();
}
}
