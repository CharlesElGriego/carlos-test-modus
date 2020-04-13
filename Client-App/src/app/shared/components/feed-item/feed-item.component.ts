import { ChangeDetectionStrategy, Component, Input, OnInit } from '@angular/core';
import { FeedItem } from '../../models';

@Component({
  selector: 'app-feed-item',
  templateUrl: './feed-item.component.html',
  styleUrls: ['./feed-item.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class FeedItemComponent implements OnInit {

  //#region   Public Properties
  @Input() feedItem: FeedItem;
  //#endregion

  //#region   Constructor
  constructor() { }
  //#endregion

  //#region   Lifecycle hooks
  ngOnInit(): void {
  }
  //#endregion

}
