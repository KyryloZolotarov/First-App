import { Component, EventEmitter, Input, Output, input } from '@angular/core';
import axios from 'axios';
import { IAvailableList } from '../interfaces/availableList';
import { Priority } from '../interfaces/priority';
import { ICard } from '../interfaces/card';

@Component({
  selector: 'app-edit-card',
  templateUrl: './edit-card.component.html',
  styleUrl: './edit-card.component.css'
})
export class EditCardComponent {
  @Input() lists!: IAvailableList[];
  @Input() cardEditing!: ICard;
  @Output() close: EventEmitter<void> = new EventEmitter<void>();
  @Output() cardEdited = new EventEmitter<void>();
  today: Date;
  tempDate!:Date;
  stringDate:string="";
  Priority = Priority;
  card: ICard = {
    id: 0,
    name: '',
    description: '',
    priority: Priority.Low, // Use Priority enum here
    listId: 0,
    dueDate: new Date()
  };

  constructor() {
    const currentDate = new Date();
    this.today = currentDate;
  }

  ngOnInit(){
    console.log(this.cardEditing);
    if (this.cardEditing && typeof this.cardEditing.dueDate === 'string') {
    this.card.id = this.cardEditing.id;
    this.card.name = this.cardEditing.name;
    this.card.description = this.cardEditing.description;
    this.card.priority = this.cardEditing.priority;
    this.card.listId = this.cardEditing.listId;
    

    this.tempDate = new Date(this.cardEditing.dueDate);
    this.card.dueDate = new Date(this.cardEditing.dueDate);
    console.log(this.stringDate)
    const year = this.tempDate.getFullYear();
    const month = String(this.tempDate.getMonth() + 1).padStart(2, '0');
    const day = String(this.tempDate.getDate()).padStart(2, '0');
    this.stringDate = `${year}-${month}-${day}`;
    console.log(this.stringDate);
} else {
    // В случае, если дата уже является объектом Date, просто присвоим ее свойству card.dueDate
    this.tempDate = this.cardEditing.dueDate;
    this.stringDate = this.tempDate.toISOString();
    console.log(this.stringDate)
}
  }

  onClose() {
    this.close.emit();
  }

  async onSubmit() {
    try {
      console.log(this.stringDate);
      this.card.dueDate = new Date(this.stringDate);
      let date:Date = new Date(this.stringDate);
      let dateFordChek:Date = new Date(this.cardEditing.dueDate);
      dateFordChek.toISOString();
      
      this.card.id = this.cardEditing.id;
      let request=[];
      if(this.card.description !== this.cardEditing.description){
        request.push({ "op": "replace", "path": "/Description", "value": this.card.description, "from": this.cardEditing.description });
      }
      if(date.toISOString() !== dateFordChek.toISOString()){
        request.push({ "op": "replace", "path": "/DueDate", "value": date, "from": dateFordChek });
      }
      if(this.card.listId !== this.cardEditing.listId){
        request.push({ "op": "replace", "path": "/ListId", "value": +this.card.listId, "from": +this.cardEditing.listId })
      }
      if(this.card.name !== this.cardEditing.name){
        request.push({ "op": "replace", "path": "/Name", "value": this.card.name, "from": this.cardEditing.name })
      }
      if(this.card.priority !== this.cardEditing.priority){
        request.push({ "op": "replace", "path": "/Priority", "value": +this.card.priority, "from": +this.cardEditing.priority })
      }
      console.log(request);
      if (request.length !== 0){
        
      console.log("I'm trying to patch card");
      axios.patch(`http://localhost:5007/cards/${this.card.id}`, request, {
        headers: {
          'Content-Type': 'application/json-patch+json'
        } });
      console.log("card putched");
      this.cardEdited.emit();
      console.log(this.card);
      }
    } catch (error) {
      console.error(error);
    };
    this.onClose();
  }
}
