import { AlertService } from '../shared/services/alert.service';
import { EventTypes } from '../shared/models/event-types';
import { Component } from '@angular/core';

@Component({
  selector: 'app-demo-alert-component',
  templateUrl: './demo-alert.component.html',
  styleUrls:['./demo-alert.component.scss']
})
export class DemoAlertComponent {
  EventTypes = EventTypes;

  constructor(private toastService: AlertService) { }

  showToast(type: EventTypes) {
    switch (type) {
      case EventTypes.Success:
        this.toastService.showSuccessToast('Success toast title', 'This is a success toast message.');
        break;
      case EventTypes.Warning:
        this.toastService.showWarningToast('Warning toast title', 'This is a warning toast message.');
        break;
      case EventTypes.Error:
        this.toastService.showErrorToast('Error toast title', 'This is an error toast message.');
        break;
      default:
        this.toastService.showInfoToast('Info toast title', 'This is an info toast message.');
        break;
    }
  }
}
