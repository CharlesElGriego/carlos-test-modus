import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Feed, FeedItem } from '../models';

@Injectable({
  providedIn: 'root'
})
export class FeedsService {

  constructor(private http: HttpClient) { }
  // Task<bool> SuscribeToFeed(int feedId, string email);

  getFeeds(email: string): Observable<Feed[]> {
    return this.http.get<Feed[]>(`feeds?email=${email}`);
  }

  getFeedItems(feedId: number): Observable<FeedItem[]> {
    return this.http.get<FeedItem[]>(`feeds/GetFeedItems?feedId=${feedId}`);
  }

  getFeedItemsFromEmail(email: string): Observable<FeedItem[]> {
    return this.http.get<FeedItem[]>(`feeds/GetFeedItems?email=${email}`);
  }
  suscribeToFeed(feedId: number, userEmail: string): Observable<boolean> {
    return this.http.post<boolean>('feeds/suscribetofeed', { feedId, userEmail });
  }
}