import { Component, Input, Output } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Component({
  selector: 'app-history-panel',
  templateUrl: './history-panel.component.html',
  styleUrl: './history-panel.component.css'
})
export class HistoryPanelComponent {
  @Input() closePanel!: () => void;

  close(): void {
    console.log("I'm trying to close panel from component");
    this.closePanel();
  }
}
