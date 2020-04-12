import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MyNewsComponent } from './my-news/my-news.component';

const routes: Routes = [
  {
    path: '', component: MyNewsComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})

export class MyNewsRoutingModule {

}
