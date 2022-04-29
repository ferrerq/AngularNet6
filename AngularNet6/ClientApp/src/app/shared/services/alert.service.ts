import { Injectable } from '@angular/core';
import { Observable, Subject } from 'rxjs';
import { EventTypes } from '../models/event-types';
import { ToastEvent } from '../models/toast-event';

@Injectable({
  providedIn: 'root',
})
export class AlertService {
  toastEvents: Observable<ToastEvent>;
  private _toastEvents = new Subject<ToastEvent>();

  constructor() {
    this.toastEvents = this._toastEvents.asObservable();
  }

  public addNotification(title: string, message: string, notificationType: EventTypes, params?: any): void {
    switch (notificationType) {
      case EventTypes.Success:
        this.showSuccessToast(title, message);
        break;
      case EventTypes.Error:
        this.showErrorToast(title, message);
        break;
      case EventTypes.Warning:
        this.showWarningToast(title, message);
        break;
      case EventTypes.Info:
      default:
        this.showInfoToast(title, message);
        break;
    }
  }

  /**
   * Show success toast notification.
   * @param title Toast title
   * @param message Toast message
   */
  showSuccessToast(title: string, message: string) {
    this._toastEvents.next({
      message,
      title,
      type: EventTypes.Success,
    });
  }

  /**
   * Show info toast notification.
   * @param title Toast title
   * @param message Toast message
   */
  showInfoToast(title: string, message: string) {
    this._toastEvents.next({
      message,
      title,
      type: EventTypes.Info,
    });
  }

  /**
   * Show warning toast notification.
   * @param title Toast title
   * @param message Toast message
   */
  showWarningToast(title: string, message: string) {
    this._toastEvents.next({
      message,
      title,
      type: EventTypes.Warning,
    });
  }

  /**
   * Show error toast notification.
   * @param title Toast title
   * @param message Toast message
   */
  showErrorToast(title: string, message: string) {
    this._toastEvents.next({
      message,
      title,
      type: EventTypes.Error,
    });
  }
}