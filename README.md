# Projeto Cine Pipona  <img src="assets/img/favicon.PNG" alt="Pipoca" />
Sistema para gerencinar filmes, salas e sessões de um cinema.

## Patterns/Tecnologias:
* ASP.NET 5
* DDD
* Dapper (Mapeador e manipulação de objetos para acesso a dados)
* Princípios SOLID
* ASP.NET Identity
* Autenticação e autorização (JWT e Cookies)
* Layer API implementation
* Swagger (API Development)
* Sql Server 2014 Community

## Front End
* Bootstrop
* Ajax
* Jquery
* Bibliotecas para layout e valização de dados.

## Telas
Usuário: administrador@cine.com
Senha: 123456
<p align="center">
  <img src="assets/img/login_swagger.PNG" alt="Login/Swagger" />
</p>

<p align="center">
  <img src="assets/img/painel.PNG" alt="Painel" />
</p>

<p align="center">
  <img src="assets/img/filme.PNG" alt="Filme" />
</p>

<p align="center">
  <img src="assets/img/filme_ed.PNG" alt="Filme edição" />
</p>

<p align="center">
  <img src="assets/img/sala.PNG" alt="Sala" />
</p>

<p align="center">
  <img src="assets/img/sessao.PNG" alt="Sessão"/>
</p>

## MERScript do banco de dados

<p align="center">
  <img src="assets/img/diagrama.PNG" alt="Diagrama"/>
</p>

## Script banco de dados
<a href="https://github.com/raphaelpereiravalle/ProjetoCinema/tree/master/BancoDeDados">Arquivo</a>

## Estrutura

<p align="center">
  <img src="assets/img/estrutura.PNG" alt="Estrutura"/>
</p>

* 1 - Presentation
	* Camada de apresentação com CRUD;
	* Plugins CSS e JavaScript
	* MVC
	* Classe de comunicação do API 
* 2 - Services
	* API
* 3 - Core
	* Entidades de domínio, interfaces e segurança;
	* Serviços e intefases.
* 4 - Infrastructure
	* Repository Pattern: Repositórios EF Core e Dapper para a persistência de dados do banco de dados;
	* Entity Framework Context;
* 5 - Test
	* Testes
## Ambiente para tester o projeto

*Efetue o clone do repositório para o Visual Studio ou Visual Code
*Restaure o banco de dados executando o <a href="https://github.com/raphaelpereiravalle/ProjetoCinema/tree/master/BancoDeDados">script</a> foi usado a opção de Windows Authentication para autencicação do banco dados.
*É importante configurar o *Startup Project* (lembrado que pode se customizada) selecione a opção Start na coluna Action

<p align="center">
  <img src="assets/img/solucao.PNG" alt="Solução" />
</p>

<p align="center">
  <img src="assets/img/propriedade.PNG" alt="Propriedade" />
</p>

## Author

The ProjetoCinema was developed by Raphael Pereira Valle.