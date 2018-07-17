import { Component } from '@angular/core';
import { AppService } from '../app.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})

export class AppComponent {
  title = 'WebApp';
  constructor() { }
}

export class Entity {
  Id: string;
  Ativo: string;
}
export class Produto extends Entity {
  Mercado: String;
  Nome: string;
  Preco: string;
  Peso: string;
  Imagem: string;
}
export class Auth {
  Email: string;
  Senha: string;
}
export class Usuario extends Auth {
  Nome: string;
}
export class Mercado extends Auth {
  Imagem: string;
  Nome: string;
  Endereco: string;
}
