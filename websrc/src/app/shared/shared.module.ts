import { NgModule, ModuleWithProviders } from '@angular/core';
import { HttpModule } from '@angular/http';
import { CommonModule } from "@angular/common";

@NgModule({
  imports: [CommonModule],
  declarations: [],
  exports: [CommonModule, HttpModule],
  providers: [] // these would be multi-instance
})
export class SharedModule { }