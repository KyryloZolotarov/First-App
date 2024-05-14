import { Component, EventEmitter, Input, Output } from '@angular/core';
import axios from 'axios';
import { ICard } from '../interfaces/card';
import { Priority } from '../interfaces/priority';
import { IAvailableList } from '../interfaces/availableList';
import {
  Dropdown,
  Ripple,
  initTWE,
} from "tw-elements";
import { Store, select } from '@ngrx/store';
import { selectAvailableListsForCards } from '../store/selectors/list-selectors';
import { Observable } from 'rxjs';
import { RootState } from '../store/interfaces/root-state';
@Component({
  selector: 'app-card',
  templateUrl: './card.component.html',
  styleUrl: './card.component.css'
})
export class CardComponent {
  @Input() card!: ICard;
  @Input() currentListName!: string;
  @Output() cardDeleted = new EventEmitter<ICard>();
  @Output() cardMoved = new EventEmitter<void>();
  availableLists$: Observable<IAvailableList[]> = new Observable<IAvailableList[]>();
  Priority = Priority;
  isDropdownOpen: boolean = false;
  isDropdownTwoOpen: boolean = false;
  isModalOpen: boolean = false;
  cardForEdit!:ICard;

  constructor(private store: Store<RootState>) {}

    
  ngOnInit(): void {
    this.availableLists$ = this.store.pipe(select(selectAvailableListsForCards));
    this.cardForEdit = { ...this.card };
  }

  toggleDropdown() {
    this.isDropdownOpen = !this.isDropdownOpen;
}

  toggle(){
  this.isDropdownTwoOpen = !this.isDropdownTwoOpen;
}

  toggleDropdownForList() {
    this.isDropdownTwoOpen = !this.isDropdownTwoOpen;
  }
  openModal() {
    this.isModalOpen = true;
  }
  async moveCardToOteherList(id:number){
    try {
      console.log("I'm patching the card");
      await axios.patch(`http://localhost:5007/cards/${this.card.id}`, [{ "op": "replace", "path": "/ListId", "from": this.card.listId, "value": id }], {
        headers: {
          'Content-Type': 'application/json-patch+json'
        } });
        this.cardMoved.emit();
    } catch (error) {
      console.error(error);
    };
  }
  async deleteCard() {
    try {
      console.log("I'm deleting the card");
      let date:Date = new Date(this.card.dueDate);
      await axios.delete<ICard>(`http://localhost:5007/cards/${this.card.id}`, {data: {
        id:this.card.id,
        name:this.card.name,
        description:this.card.description,
        priority:+this.card.priority,
        listId:+this.card.listId,
        dueDate:date.toISOString()  }});
      console.log(this.card);
      this.cardDeleted.emit(this.card);
    } catch (error) {
      console.error(error);
    };
  }
  onCardEdited() {
    console.log("cards refresh");
    this.cardMoved.emit();
  }
  closeModal() {
    this.isModalOpen = false;
  }
  }
