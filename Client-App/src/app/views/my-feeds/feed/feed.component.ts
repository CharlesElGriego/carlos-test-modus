import { ChangeDetectionStrategy, Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { BehaviorSubject } from 'rxjs';
import { FeedItem } from 'src/app/shared/models';
import { FeedsService } from 'src/app/shared/services/feeds.service';

@Component({
  selector: 'app-feed',
  templateUrl: './feed.component.html',
  styleUrls: ['./feed.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class FeedComponent implements OnInit {
  //#region   Public Properties
  items$ = new BehaviorSubject<FeedItem[]>([]);
  //#endregion

  //#region   Private Properties
  private items: FeedItem[];
  //#endregion

  //#region   Constructor
  constructor(
    private feedsService: FeedsService,
    private router: Router,
    private route: ActivatedRoute
  ) { }
  //#endregion

  //#region   Lifecycle Hooks
  ngOnInit(): void {
    this.registerEvents();
  }
  //#endregion

  //#region   Public Methods
  goToBack(): void {
    this.router.navigate(['my-feeds']);
  }

  search(word: string): void {
    this.items$.next(this.items.filter(item =>
      item.content.toLowerCase().includes(word.toLowerCase(), 0)));
  }
  //#endregion

  //#region   Private Methods
  private registerEvents(): void {
    const id = this.route.snapshot.paramMap.get('id');
    this.feedsService.getFeedItems(id).subscribe(
      data => {
        if (data) {
          this.items = [...data];
          this.items$.next([...data]);
        }
      }
    );
  }
  //#endregion

}
