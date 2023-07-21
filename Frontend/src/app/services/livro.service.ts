import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { environment } from '../../environments/environment';
import { Livro } from '../models';

const baseUrl = `${environment.apiUrl}/Livro`;

@Injectable({ providedIn: 'root' })
export class LivroService {
    constructor(private http: HttpClient) { }

    getAll() {
        return this.http.get<Livro[]>(`${baseUrl}/GetAll`);
    }

    getById(id: string) {
        return this.http.get<Livro>(`${baseUrl}/${id}`);
    }

    create(params: any) {
        return this.http.post(baseUrl, params);
    }

    update(id: string, params: any) {
        return this.http.put(`${baseUrl}/${id}`, params);
    }

    delete(id: string) {
        return this.http.delete(`${baseUrl}/${id}`);
    }
}