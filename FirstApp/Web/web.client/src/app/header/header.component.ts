import { Component, EventEmitter, Output } from '@angular/core';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrl: './header.component.css'
})
export class HeaderComponent {
  @Output() openPanelEvent: EventEmitter<void> = new EventEmitter<void>();
  openPanel(){
    console.log("I'm trying to open panel")
    this.openPanelEvent.emit();
  }
}
