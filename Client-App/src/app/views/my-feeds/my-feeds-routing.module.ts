import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MyFeedsComponent } from './my-feeds/my-feeds.component';

const routes: Routes = [
  {
    path: '', component: MyFeedsComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})

export class MyFeedsRoutingModule {

}
