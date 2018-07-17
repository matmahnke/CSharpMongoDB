import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '../node_modules/@angular/common/http';
import { Observable, of } from '../node_modules/rxjs';
import { Produto } from './app/app.component';
import { tap, catchError } from '../node_modules/rxjs/operators';
import { ResponseOptions } from '@angular/http';

@Injectable()
export class AppService {
  
  private produtosUrl = 'http://localhost:1234/Produto';
  private httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };
  private http: HttpClient;
  constructor() { }

  getprodutos(): Observable<Produto[]> {
    alert('a');
    return this.http.get<Produto[]>(this.produtosUrl).pipe(tap(heroes => this.log(''), catchError(this.handleError('', []))));
  }

  getproduto(id: number): Observable<Produto> {
    const url = `${this.produtosUrl}/${id}`;
    return this.http.get<Produto>(url).pipe(
      tap(_ => this.log(`fetched produto id=${id}`)),
      catchError(this.handleError<Produto>(`getproduto id=${id}`))
    );
  }

  addproduto(produto: Produto): Observable<Produto> {
    return this.http.post<Produto>(this.produtosUrl, produto, this.httpOptions).pipe(
      tap((produto: Produto) => this.log(`added produto w/ id=${produto.Id}`)),
      catchError(this.handleError<Produto>('addproduto'))
    );
  }
  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {

      console.error(error);

      this.log(`${operation} failed: ${error.message}`);

      return of(result as T);
    };
  }

  private log(message: string) {
    //alert(message);
  }
}
