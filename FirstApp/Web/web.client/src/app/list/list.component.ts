import { Component, Input, Output } from '@angular/core';
import axios from 'axios';
import { ICard } from '../interfaces/card';
import { IList } from '../interfaces/list';
import { IAvailableList } from '../interfaces/availableList';
import { OutletContext } from '@angular/router';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrl: './list.component.css'
})
export class ListComponent {
  @Input() singleList!: IList;
  @Input() availableListsInput!: IAvailableList[];

  isModalOpen: boolean = false;
  openModal() {
    this.isModalOpen = true;
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
  
  closeModal() {
    this.isModalOpen = false;
  }
}
