import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import axios from 'axios';
import { ICard } from '../interfaces/card';
import { IList } from '../interfaces/list';
import { IAvailableList } from '../interfaces/availableList';
import { Store, select } from '@ngrx/store';
import { selectAvailableListsForCards } from '../store/selectors/list-selectors';
import { Observable } from 'rxjs';
import { RootState } from '../store/interfaces/root-state';
import * as ListActions from '../store/actions/list-actions';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrl: './list.component.css'
})
export class ListComponent implements OnInit {
  @Input() singleList!: IList;
  @Output() refreshLists = new EventEmitter<void>();
  availableLists$: Observable<IAvailableList[]> = new Observable<IAvailableList[]>();
  isModalOpen: boolean = false;
  isDropdownOpen: boolean = false;
  originListTitle:string = "";
  editingList:boolean=false;
  currentList!:IAvailableList;

  constructor(private store: Store<RootState>) {}
  
  ngOnInit(): void {
    console.log(this.singleList);
    this.availableLists$ = this.store.pipe(select(selectAvailableListsForCards));    
    this.currentList={id:this.singleList.id, title:this.singleList.title};
    console.log(this.currentList);
    
  }
  
  openModal() {
    this.isModalOpen = true;
  }


  toggleDropdown() {
      this.isDropdownOpen = !this.isDropdownOpen;
  }

  onCardDeleted(deletedCard: ICard) {
    this.refreshLists.emit();
  }
  onCardAdded(addedCard: ICard) {
    this.refreshLists.emit();
  }

  async deleteList() {
    this.store.dispatch(ListActions.deleteList({ id:this.singleList.id, title:this.singleList.title, boardId:this.singleList.boardId }));
  }
  
  onCardMoved(){
    this.refreshLists.emit();
  }
  
  closeModal() {
    this.isModalOpen = false;
  }

  onEditListSelected(){
    this.originListTitle = this.singleList.title;
    this.editingList = true;
  }

  onEditClosing(){
    this.editingList = false;
    this.isDropdownOpen = false;
  }

  async onEditList(){
    try {
      console.log("I'm patching the list");
      axios.patch(`http://localhost:5007/lists/${this.singleList.id}`, [{ "op": "replace", "path": "/Title", "value": `${this.singleList.title}`, "from": `${this.originListTitle}` }], {
        headers: {
          'Content-Type': 'application/json-patch+json'
        } });
        console.log("I putched list");
        this.onEditClosing();
    } catch (error) {
      console.error(error);
    };

  }
}
