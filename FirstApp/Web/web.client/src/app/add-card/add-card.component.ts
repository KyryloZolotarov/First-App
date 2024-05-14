import { Component, EventEmitter, Input, Output, input } from '@angular/core';
import { Priority } from '../interfaces/priority';
import { IAvailableList } from '../interfaces/availableList';
import axios from 'axios';
import { IAddCard } from '../interfaces/addCard';
import { ICard } from '../interfaces/card';
import { Store, select } from '@ngrx/store';
import * as ModalActions from '../store/actions/list-actions';
import { selectAvailableListsForCards } from '../store/selectors/list-selectors';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-add-card',
  templateUrl: './add-card.component.html',
  styleUrls: ['./add-card.component.css']
})
export class AddCardComponent {
  @Input() selectedList!: IAvailableList;
  @Output() close: EventEmitter<void> = new EventEmitter<void>();
  @Output() cardAdded = new EventEmitter<ICard>();
  availableLists$: Observable<IAvailableList[]> = new Observable<IAvailableList[]>();
  today: Date;
  Priority = Priority;
  card: ICard = {
    id: 0,
    name: '',
    description: '',
    priority: Priority.Low, // Use Priority enum here
    listId: 0,
    dueDate: new Date()
  };

  constructor(private store: Store) {
    const currentDate = new Date();
    this.today = currentDate;
  }

  onClose() {
    this.close.emit();
  }

  ngOnInit(): void {
    this.availableLists$ = this.store.pipe(select(selectAvailableListsForCards));
  }

  async onSubmit() {
    try {
      console.log("I'm trying to add card");
      console.log(this.card);
      let date:Date = new Date(this.card.dueDate);
      let cardAdd:IAddCard = 
      {
        Name:this.card.name,
        Description:this.card.description,
        Priority:+this.card.priority,
        ListId:+this.card.listId,
        DueDate:date.toISOString()  };
      let result = await axios.post<number>("http://localhost:5007/cards", cardAdd);
      console.log(result.data);
      this.card.id = result.data;
      console.log(this.card);
      this.cardAdded.emit(this.card);
      console.log(this.card);
    } catch (error) {
      console.error(error);
    };
    this.onClose(); // Close the modal after submission
  }
}