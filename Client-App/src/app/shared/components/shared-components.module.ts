import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FlexLayoutModule } from '@angular/flex-layout';
import { MaterialModule } from 'src/app/material.module';
import { FeedItemComponent } from './feed-item/feed-item.component';



@NgModule({
  declarations: [FeedItemComponent],
  imports: [
    CommonModule,
    MaterialModule,
    FlexLayoutModule
  ],
  exports: [FeedItemComponent]
})
export class SharedComponentsModule { }
