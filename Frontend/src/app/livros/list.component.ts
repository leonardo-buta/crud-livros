import { Component, OnInit } from '@angular/core';
import { first } from 'rxjs/operators';
import { AlertService, LivroService } from '../services';

@Component({ templateUrl: 'list.component.html' })
export class ListComponent implements OnInit {
    livros?: any[];
    livrosFiltrados?: any[];

    constructor(private livroService: LivroService, private alertService: AlertService) {}

    ngOnInit() {
        this.livroService.getAll()
            .pipe(first())
            .subscribe(livros => 
                {
                    this.livros = livros;
                    this.livrosFiltrados = livros;
                });
    }

    deleteLivro(id: string) {
        this.livroService.delete(id)
            .pipe(first())
            .subscribe(() => this.livrosFiltrados = this.livrosFiltrados!.filter(x => x.id !== id));

            this.alertService.clear();
            this.alertService.error('Livro excluído com sucesso', { keepAfterRouteChange: true });
    }

    applyFilter(event: Event): void {
        const filterValue = (event.target as HTMLInputElement).value.toLowerCase();
        
        if (!filterValue) {
            this.livrosFiltrados = this.livros;
            return;
          }
        
          this.livrosFiltrados = this.livros?.filter(livro => {
            return livro.nome.toLowerCase().includes(filterValue)
                || livro.autor.toLowerCase().includes(filterValue)
                || livro.categoria.toLowerCase().includes(filterValue)
          });
      }
}