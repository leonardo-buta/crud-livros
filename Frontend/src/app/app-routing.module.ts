import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { HomeComponent } from './home';

const livrosModule = () => import('./livros/livros.module').then(x => x.LivrosModule);

const routes: Routes = [
    { path: '', component: HomeComponent },
    { path: 'livros', loadChildren: livrosModule },
    { path: '**', redirectTo: '' }
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutingModule { }