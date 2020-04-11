import { ChangeDetectionStrategy, Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { map, shareReplay } from 'rxjs/operators';
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
  feeds$: Observable<Feed[]>;
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
    this.feedsService.suscribeToFeed(id, this.user.email).subscribe(valid => {
      if (valid) {
        this.feeds$ = this.feeds$.pipe(
          map(feed => {
            // feed[index].name = 'fe';
            return feed;
          })
        );
      }
    });
  }
  //#endregion

  //#region   Private Methods
  private registerEvents(): void {
    this.feeds$ = this.feedsService.getFeeds().pipe(shareReplay());
    this.user = this.authService.user$.getValue();
  }
  //#endregion
}
