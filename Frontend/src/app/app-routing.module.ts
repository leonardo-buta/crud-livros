import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { HomeComponent } from './home';
import { AuthGuard } from './shared/auth.guard';
import { SigninComponent } from './signin/signin.component';

const livrosModule = () => import('./livros/livros.module').then(x => x.LivrosModule);

const routes: Routes = [
    { path: '', component: HomeComponent, canActivate: [AuthGuard] },
    { path: 'log-in', component: SigninComponent },
    { path: 'livros', loadChildren: livrosModule, canActivate: [AuthGuard] },
    { path: '**', redirectTo: '' }
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutingModule { }