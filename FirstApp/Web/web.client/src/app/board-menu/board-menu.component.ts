import { Component, EventEmitter, Output } from '@angular/core';
import { IBoard } from '../interfaces/board';

@Component({
  selector: 'app-board-menu',
  templateUrl: './board-menu.component.html',
  styleUrl: './board-menu.component.css'
})
export class BoardMenuComponent {
@Output() cardAdded = new EventEmitter<number>();
boards:IBoard[]=[];
isDropdownOpen: boolean = false;

async ngOnInit(): Promise<void> {
  await this.getBoards();
}

async getBoards(){

}

selectBoard(id:number){
this.cardAdded.emit(id);
}
}
