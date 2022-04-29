import { ChangeDetectionStrategy, ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { ToastEvent } from 'src/app/shared/models/toast-event';
import { AlertService } from 'src/app/shared/services/alert.service';

@Component({
  selector: 'app-toaster',
  templateUrl: './toaster.component.html',
  styleUrls: ['./toaster.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class ToasterComponent implements OnInit {
  currentToasts: ToastEvent[] = [];

  constructor(private alertService: AlertService, private cdr: ChangeDetectorRef) {}

  ngOnInit() {
    this.subscribeToToasts();
  }

  subscribeToToasts() {
    this.alertService.toastEvents.subscribe((toasts: any) => {
      const currentToast: ToastEvent = {
        type: toasts.type,
        title: toasts.title,
        message: toasts.message,
      };
      this.currentToasts.push(currentToast);
      this.cdr.detectChanges();
    });
  }

  dispose(index: number) {
    this.currentToasts.splice(index, 1);
    this.cdr.detectChanges();
  }
}