import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FlexLayoutModule } from '@angular/flex-layout';
import { MaterialModule } from 'src/app/material.module';
import { SharedComponentsModule } from 'src/app/shared/components/shared-components.module';
import { FeedComponent } from './feed/feed.component';
import { MyFeedsRoutingModule } from './my-feeds-routing.module';
import { MyFeedsComponent } from './my-feeds/my-feeds.component';



@NgModule({
  declarations: [MyFeedsComponent, FeedComponent],
  imports: [
    CommonModule,
    MyFeedsRoutingModule,
    SharedComponentsModule,
    MaterialModule,
    FlexLayoutModule
  ]
})
export class MyFeedsModule { }
