import { Component, EventEmitter, Output } from '@angular/core';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrl: './header.component.css'
})
export class HeaderComponent {
  @Output() openPanelEvent: EventEmitter<void> = new EventEmitter<void>();
  openPanel(){
    this.openPanelEvent.emit();
  }
}
