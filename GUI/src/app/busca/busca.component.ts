import { Component, OnInit } from '@angular/core';
import { Produto } from '../app.component';
import { Http, Headers } from '@angular/http';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { AppService } from '../../app.service';
import { Observable, of } from '../../../node_modules/rxjs';
import { tap, catchError, map } from '../../../node_modules/rxjs/operators';
import { ResponseOptions } from '@angular/http';
import { promise } from '../../../node_modules/protractor';
import { Promise } from '../../../node_modules/@types/q';

@Component({
  selector: 'app-busca',
  templateUrl: './busca.component.html',
  styleUrls: ['./busca.component.css']
})

export class BuscaComponent implements OnInit {
  produtos: Produto[];
  private produtosUrl = 'http://localhost:1234/Produto';
  private httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };
  constructor(
    private http: HttpClient) { }

    ngOnInit(){
      this.getHeroes();
    }

  getHeroes(): Observable<Produto[]> {
    alert('a');
    return this.http.get<Produto[]>(this.produtosUrl);
  }
}