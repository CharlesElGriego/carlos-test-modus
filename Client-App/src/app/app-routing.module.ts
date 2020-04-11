import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from './security/auth.guard';


const routes: Routes = [
  {
    path: 'login',
    loadChildren: () => import('./security/login/login.module').then(m => m.LoginModule)
  },
  {
    path: 'feeds',
    loadChildren: () => import('./views/feeds/feeds.module').then(m => m.FeedsModule),
    canActivate: [AuthGuard]
  },
  {
    path: 'my-feeds',
    loadChildren: () => import('./views/my-feeds/my-feeds.module').then(m => m.MyFeedsModule),
    canActivate: [AuthGuard]
  },
  {
    path: 'my-news',
    loadChildren: () => import('./views/my-news/my-news.module').then(m => m.MyNewsModule),
    canActivate: [AuthGuard]
  },
  {
    path: '**',
    redirectTo: '',
  }

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
