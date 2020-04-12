import { Component, OnInit } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { AuthService } from 'src/app/security/auth.service';
import { User } from 'src/app/security/models';
import { FeedItem } from 'src/app/shared/models';
import { FeedsService } from 'src/app/shared/services/feeds.service';

@Component({
  selector: 'app-my-news',
  templateUrl: './my-news.component.html',
  styleUrls: ['./my-news.component.scss']
})
export class MyNewsComponent implements OnInit {

  //#region   Public Properties
  news$ = new BehaviorSubject<FeedItem[]>([]);
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
  //#endregion

  //#region   Private Methods
  private registerEvents(): void {
    this.user = this.authService.user$.getValue();
    this.feedsService.getFeedItemsFromEmail(this.user.email).subscribe(
      data => {
        this.news$.next(data);
        console.log(data);

      }
    );
  }
  //#endregion

}
