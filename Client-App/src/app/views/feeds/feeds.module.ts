import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FlexLayoutModule } from '@angular/flex-layout';
import { MaterialModule } from 'src/app/material.module';
import { FeedsRoutingModule } from './feeds-routing.module';
import { FeedsComponent } from './feeds/feeds.component';

@NgModule({
  declarations: [FeedsComponent],
  imports: [
    CommonModule,
    FeedsRoutingModule,
    MaterialModule,
    FlexLayoutModule
  ]
})
export class FeedsModule { }
