import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FlexLayoutModule } from '@angular/flex-layout';
import { MaterialModule } from 'src/app/material.module';
import { SharedComponentsModule } from 'src/app/shared/components/shared-components.module';
import { MyNewsRoutingModule } from './my-news-routing.module';
import { MyNewsComponent } from './my-news/my-news.component';



@NgModule({
  declarations: [MyNewsComponent],
  imports: [
    CommonModule,
    SharedComponentsModule,
    MyNewsRoutingModule,
    MaterialModule,
    FlexLayoutModule
  ]
})
export class MyNewsModule { }
