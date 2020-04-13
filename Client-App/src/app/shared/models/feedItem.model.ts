export class FeedItem {
  id: number;
  content: string;
  date: Date;
  parentImage: string;
  parentName: string;
  title: string;

  constructor(fields: any = {}) {
    Object.assign(this, fields);
  }
}
