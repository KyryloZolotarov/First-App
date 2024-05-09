import { Component, EventEmitter, Input, Output } from '@angular/core';
import axios from 'axios';
import { ICard } from '../interfaces/card';
import { Priority } from '../interfaces/priority';

@Component({
  selector: 'app-card',
  templateUrl: './card.component.html',
  styleUrl: './card.component.css'
})
export class CardComponent {
  @Input() card!: ICard;
  @Output() cardDeleted = new EventEmitter<ICard>();
  Priority = Priority;
  isDropdownOpen: boolean = false;

    toggleDropdown() {
        this.isDropdownOpen = !this.isDropdownOpen;
    }
  ngOnInit(): void {
    console.log(this.card);
  }

  editCard(){

  }
  async deleteCard() {
    try {
      console.log("I'm deleting the card");
      let date:Date = new Date(this.card.dueDate);
      await axios.delete<ICard>(`http://localhost:5007/cards/${this.card.id}`, {data: {
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
  }
