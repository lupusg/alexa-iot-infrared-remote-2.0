import { Subscription } from 'rxjs';

export class SubscriptionsContainer {
  private subscriptions: Subscription[] = [];

  add(newSubscription: Subscription) {
    this.subscriptions.push(newSubscription);
  }

  dispose() {
    this.subscriptions.forEach((s) => s.unsubscribe());
  }
}
