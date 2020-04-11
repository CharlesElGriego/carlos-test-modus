import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from './security/auth.guard';


const routes: Routes = [
  {
    path: 'login',
    loadChildren: './security/login/login.module#LoginModule',
  },
  {
    path: 'feeds',
    loadChildren: './security/login/login.module#LoginModule',
    canActivate: [AuthGuard]
  },
  {
    path: 'my-feeds',
    loadChildren: './security/login/login.module#LoginModule',
    canActivate: [AuthGuard]
  },
  {
    path: 'my-news',
    loadChildren: './security/login/login.module#LoginModule',
    canActivate: [AuthGuard]
  },
  {
    path: '**',
    redirectTo: 'home',
  }

];

@NgModule({
  imports: [RouterModule.forRoot(routes, {
    initialNavigation: 'enabled'
  })],
  exports: [RouterModule]
})
export class AppRoutingModule { }
