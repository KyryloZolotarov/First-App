import { ChangeDetectorRef, Component, Input } from '@angular/core';
import { IList } from '../interfaces/list';
import axios from 'axios';
import { IBoardLists} from '../interfaces/boardLists';
import { IAvailableList } from '../interfaces/availableList';
import { IAddList } from '../interfaces/addList';

@Component({
  selector: 'app-work-dashboard',
  templateUrl: './work-dashboard.component.html',
  styleUrl: './work-dashboard.component.css'
})
export class WorkDashboardComponent {
lists: IList[] = [];
addList: IAddList = { title : "", boardId: 0};
availableListsForCards: IAvailableList[] = [];
addingNewList:boolean = false;
isDropdownOpen: boolean = false;
currentBordId!:number;

public async getLists(boardId:number): Promise<void> {
  try {
    this.currentBordId = boardId
    console.log("I'm trying to get lists");
    console.log(boardId);
    const response = await axios.get<IBoardLists>(`http://localhost:5007/lists/${boardId}`);
      this.lists = response.data.lists;
    console.log(this.lists);

    this.availableListsForCards = this.lists.map(list => {
      return {
        id: list.id,
        title: list.title
      };
    });
    console.log(this.availableListsForCards);
  } catch (error) {
    console.error(error);
  };
}
async onAddList(){
  try {
    console.log("I'm trying to add list");
    console.log(this.addList);
    let listId:number = await axios.post(`http://localhost:5007/lists/`, this.addList);
    let newList: IList = { id:listId, title:this.addList.title, boardId:this.currentBordId, cards:[] };
    console.log("Added list:", this.addList);
    this.addingNewList=false;
    this.refresh();
    console.log("Updated lists:", this.lists);
  } catch (error) {
    console.error(error);
  };

}

toggleDropdown() {
  this.isDropdownOpen = !this.isDropdownOpen;
}
async refresh(){
  console.log("refreshing");
  await this.getLists(this.currentBordId);
}
}
