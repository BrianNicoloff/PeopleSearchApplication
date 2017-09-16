import { NgModule, Optional, SkipSelf } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpService } from "./http/http.service";
import { EnsureModuleLoadedOnceGuard } from "../shared/ensure-module-loaded-once.guard";

@NgModule({
  imports: [CommonModule],
  exports: [CommonModule],
  providers: [HttpService]
})
export class CoreModule extends EnsureModuleLoadedOnceGuard { 
  //Looks for the module in the parent injector to see if it's already been loaded (only want it loaded once)
    constructor( @Optional() @SkipSelf() parentModule: CoreModule) {
        super(parentModule);
    }

}
