import { Component, EventEmitter, Input, Output } from '@angular/core';
import axios from 'axios';
import { ICard } from '../interfaces/card';
import { IList } from '../interfaces/list';
import { IAvailableList } from '../interfaces/availableList';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrl: './list.component.css'
})
export class ListComponent {
  @Input() singleList!: IList;
  @Input() availableListsInput!: IAvailableList[];
  @Output() refreshLists = new EventEmitter<void>();

  isModalOpen: boolean = false;
  isDropdownOpen: boolean = false;
  originListTitle:string = "";
  editingList:boolean=false;
  currentList!:IAvailableList;
  
  openModal() {
    this.currentList={id:this.singleList.id, title:this.singleList.title};
    this.isModalOpen = true;
  }


  toggleDropdown() {
      this.isDropdownOpen = !this.isDropdownOpen;
  }

  onCardDeleted(deletedCard: ICard) {
    console.log("Deleting card:", deletedCard.id);
    this.singleList.cards = this.singleList.cards.filter(card => card.id !== deletedCard.id);
    console.log("Updated cards:", this.singleList.cards);
  }
  onCardAdded(addedCard: ICard) {
    console.log("Added card:", addedCard.id);
    this.singleList.cards.push(addedCard);
    console.log("Updated cards:", this.singleList.cards);
  }

  async deleteList() {
    try {
      console.log("I'm deleting the list");
      await axios.delete(`http://localhost:5007/lists/${this.singleList.id}`, {data: {
        id:this.singleList.id,
        title:this.singleList.title
         }});
      console.log(`I deleted list ${this.singleList.title}`);
      this.refreshLists.emit();
    } catch (error) {
      console.error(error);
    };

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
