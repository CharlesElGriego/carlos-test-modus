import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { FeedComponent } from './feed/feed.component';
import { MyFeedsComponent } from './my-feeds/my-feeds.component';
const routes: Routes = [
  {
    path: '', component: MyFeedsComponent,
  },
  {
    path: ':id', component: FeedComponent,
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})

export class MyFeedsRoutingModule {

}
