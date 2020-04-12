import { ChangeDetectionStrategy, Component, OnInit } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { AuthService } from 'src/app/security/auth.service';
import { User } from 'src/app/security/models';
import { Feed } from 'src/app/shared/models';
import { FeedsService } from 'src/app/shared/services/feeds.service';

@Component({
  selector: 'app-feeds',
  templateUrl: './feeds.component.html',
  styleUrls: ['./feeds.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})

export class FeedsComponent implements OnInit {

  //#region   Public Properties
  feeds: Feed[] = [];
  feeds$ = new BehaviorSubject<Feed[]>([]);
  //#endregion

  //#region   Private Properties
  private user: User;
  //#endregion

  //#region   Constructor
  constructor(
    private authService: AuthService,
    private feedsService: FeedsService
  ) { }
  //#endregion

  //#region   Lifecycle Hooks
  ngOnInit(): void {
    this.registerEvents();
  }
  //#endregion

  //#region   Public Methods
  suscribe(id: number, index: number): void {
    this.feedsService.suscribeToFeed(id, this.user.email).subscribe(
      valid => {
        if (valid) {
          const feeds = this.feeds$.getValue();
          feeds[index] = { ...feeds[index], isSubscribed: true };
          this.feeds$.next(feeds);
        }
      }
    );

  }
  //#endregion

  //#region   Private Methods
  private registerEvents(): void {
    this.user = this.authService.user$.getValue();
    this.feedsService.getFeeds(this.user.email).subscribe(
      data => {
        this.feeds$.next(data);
      }
    );
  }
  //#endregion
}
