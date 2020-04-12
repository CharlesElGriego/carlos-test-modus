import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FlexLayoutModule } from '@angular/flex-layout';
import { MaterialModule } from 'src/app/material.module';
import { MyFeedsRoutingModule } from './my-feeds-routing.module';
import { MyFeedsComponent } from './my-feeds/my-feeds.component';



@NgModule({
  declarations: [MyFeedsComponent],
  imports: [
    CommonModule,
    MyFeedsRoutingModule,
    MaterialModule,
    FlexLayoutModule
  ]
})
export class MyFeedsModule { }
