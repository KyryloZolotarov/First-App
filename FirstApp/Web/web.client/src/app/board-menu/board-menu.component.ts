import { Component, EventEmitter, OnChanges, OnInit, Output, SimpleChanges } from '@angular/core';
import { IBoard } from '../interfaces/board';
import axios from 'axios';

@Component({
  selector: 'app-board-menu',
  templateUrl: './board-menu.component.html',
  styleUrl: './board-menu.component.css'
})
export class BoardMenuComponent implements OnInit, OnChanges {
@Output() cardAdded = new EventEmitter<number>();
@Output() boardsAvailable = new EventEmitter<{id:number,flag:boolean}>();
boards:IBoard[]=[];
isDropdownOpen: boolean = false;
areBoardsAvailable: boolean = false;
isNewBoardInputVisible: boolean = false;
boardTitleVisible:boolean = false;
newBoard:IBoard = { id:0, title:""};
selectedBoard!:IBoard;

async ngOnInit(): Promise<void> {
  await this.getBoards();
  if(this.boards.length > 0){
    this.areBoardsAvailable = true;    
  }
}

async ngOnChanges(changes: SimpleChanges){
  await this.getBoards();
  if(this.boards.length > 0){
    this.areBoardsAvailable = true;    
  }
}

async getBoards(){
  this.boards=[];
  const response = await axios.get<IBoard[]>(`http://localhost:5007/boards/`);
  this.boards = response.data;
}

showBoardNewInput(){
 this.isNewBoardInputVisible = true;
}

async creatBoard(){
  try {
    console.log("I'm trying to add board");
    let result = await axios.post("http://localhost:5007/boards", this.newBoard);
     await this.getBoards();
     this.areBoardsAvailable = true; 
     this.isNewBoardInputVisible = false;
  } catch (error) {
    console.error(error);
  };
}

showBoardInput(){
  this.isNewBoardInputVisible = true;
  this.toggleDropdownForBoard();
}

canselCreation() {
  this.isNewBoardInputVisible = false;
}

toggleDropdownForBoard(){
  this.isDropdownOpen = !this.isDropdownOpen;
}

selectBoard(id:number){
this.boardsAvailable.emit({id, flag:true});
const selected = this.boards.find(s => s.id === id);
  if (!selected) {
    console.error('Board not found');
    return;
  }
  this.selectedBoard = selected;
  this.boardTitleVisible = true;
  this.toggleDropdownForBoard();
}
}
