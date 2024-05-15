import { Component, EventEmitter, Input, OnInit, Output, input } from '@angular/core';
import { Priority } from '../interfaces/priority';
import { IAvailableList } from '../interfaces/availableList';
import axios from 'axios';
import { IAddCard } from '../interfaces/addCard';
import { ICard } from '../interfaces/card';
import { Store, select } from '@ngrx/store';
import * as ModalActions from '../store/actions/list-actions';
import { selectAvailableListsForCards } from '../store/selectors/list-selectors';
import { Observable, Subscription } from 'rxjs';
import { RootState } from '../store/interfaces/root-state';

@Component({
  selector: 'app-add-card',
  templateUrl: './add-card.component.html',
  styleUrls: ['./add-card.component.css']
})
export class AddCardComponent implements OnInit {
  @Input() selectedList!: IAvailableList;
  @Output() close: EventEmitter<void> = new EventEmitter<void>();
  @Output() cardAdded = new EventEmitter<ICard>();
  singleList:IAvailableList | undefined;
  otherLists:IAvailableList[] | undefined;
  private subscriptionForSingleList: Subscription;
  private subscriptionForOtherLists: Subscription;
  isDropdownOpen: boolean = false;
  today: Date;
  Priority = Priority;
  tempListId!:number;
  card: ICard = {
    id: 0,
    name: '',
    description: '',
    priority: Priority.Low, // Use Priority enum here
    listId: 0,
    dueDate: new Date()
  };

  constructor(private store: Store<RootState>) {
    this.subscriptionForSingleList = new Subscription();
    this.subscriptionForOtherLists = new Subscription();
    const currentDate = new Date();
    this.today = currentDate;
  }

  onClose() {
    this.close.emit();
  }

  ngOnInit(): void {    
    this.tempListId = this.selectedList.id;
    this.listsSettings();  
  }

  listsSettings(){
    this.subscriptionForSingleList = this.store.select(selectAvailableListsForCards)
      .subscribe(lists => {
        if (this.selectedList) {
          this.singleList = lists.find(list => list.id===this.tempListId);
        }
      });
      this.subscriptionForOtherLists = this.store.select(selectAvailableListsForCards)
      .subscribe(lists => {
        if (this.selectedList) {
          this.otherLists = lists.filter(list => list !== this.singleList);
        }
      });
    if(this.singleList !== undefined)
    {
      this.card.listId = this.singleList.id;
    }
      
  }
  toggleDropdownForList() {
    this.isDropdownOpen = !this.isDropdownOpen;
  }

  selectOtherList(id:number){
    this.card.listId=id;
    this.tempListId = id;
    this.listsSettings();
    this.toggleDropdownForList();    
  }

  async onSubmit() {
    try {
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
      this.cardAdded.emit(this.card);
    } catch (error) {
      console.error(error);
    };
    this.onClose(); // Close the modal after submission
  }
}