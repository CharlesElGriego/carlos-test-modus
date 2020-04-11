import { FeedItem } from './feedItem.model';

export class Feed {

  id: number;
  items: FeedItem[];
  name: string;
  constructor(fields: any = {}) {
    Object.assign(this, fields);
  }
}
