import { ChangeDetectorRef, Component, Input } from '@angular/core';
import { IList } from '../interfaces/list';
import axios from 'axios';
import { IUserLists } from '../interfaces/userLists';
import { IAvailableList } from '../interfaces/availableList';
import { IAddList } from '../interfaces/addList';

@Component({
  selector: 'app-work-dashboard',
  templateUrl: './work-dashboard.component.html',
  styleUrl: './work-dashboard.component.css'
})
export class WorkDashboardComponent {
@Input() boardId!:number;
lists: IList[] = [];
addList: IAddList = { Title : ""};
availableListsForCards: IAvailableList[] = [];
addingNewList:boolean = false;
isDropdownOpen: boolean = false;

public async getLists(): Promise<void> {
  try {
    console.log("I'm trying to get lists");
    const response = await axios.get<IUserLists>(`http://localhost:5007/lists${this.boardId}`);
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
    let newList: IList = { id:listId, title:this.addList.Title, cards:[] };
    console.log("Added list:", this.addList);
    this.addingNewList=false;
    this.lists.push(newList);
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
  await this.getLists();
}
}
