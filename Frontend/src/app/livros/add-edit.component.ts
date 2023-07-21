import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { first } from 'rxjs/operators';

import { LivroService, AlertService } from '../services';

@Component({ templateUrl: 'add-edit.component.html' })
export class AddEditComponent implements OnInit {
    form!: FormGroup;
    id?: string;
    title!: string;
    loading = false;
    submitting = false;
    submitted = false;

    constructor(
        private formBuilder: FormBuilder,
        private route: ActivatedRoute,
        private router: Router,
        private livroService: LivroService,
        private alertService: AlertService
    ) {}

    ngOnInit() {
        this.id = this.route.snapshot.params['id'];
        
        this.form = this.formBuilder.group({
            nome: ['', Validators.required],
            autor: ['', Validators.required],
            categoria: ['', Validators.required]
        });

        this.title = 'Adicionar Livro';
        if (this.id) {
            this.title = 'Editar Livro';
            this.loading = true;
            this.livroService.getById(this.id)
                .pipe(first())
                .subscribe(x => {
                    this.form.patchValue(x);
                    this.loading = false;
                });
        }
    }

    get f() { return this.form.controls; }

    onSubmit() {
        this.submitted = true;
        this.alertService.clear();
        if (this.form.invalid) {
            return;
        }

        this.submitting = true;
        this.saveLivro()
            .pipe(first())
            .subscribe({
                next: () => {
                    this.alertService.success('Livro cadastrado com sucesso', { keepAfterRouteChange: true });
                    this.router.navigateByUrl('/livros');
                },
                error: error => {
                    this.alertService.error(error);
                    this.submitting = false;
                }
            })
    }

    private saveLivro() {
        return this.id
            ? this.livroService.update(this.id!, this.form.value)
            : this.livroService.create(this.form.value);
    }
}