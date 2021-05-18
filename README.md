# Projeto Cine Pipoca
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
* Sql Server 2014 Community ENG

## Front End:
* Bootstrop
* Ajax
* Jquery
* Bibliotecas para layout e validação de dados

## Telas
* Usuário: administrador@cine.com
* Senha: 123456

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
	* Plugins CSS e JavaScript;
	* MVC;
	* Classe de comunicação do API. 
* 2 - Services
	* API;
	* Segurança com o JWT.
* 3 - Core
	* Entidades de domínio, interfaces e segurança;
	* Serviços e intefaces.
* 4 - Infrastructure
	* Repository Pattern: Repositórios EF Core e Dapper para a persistência de dados do banco de dados;
	* Entity Framework Context.
* 5 - Test
	* Testes
	
## Ambiente para testar o projeto

* Efetue o clone clicando no botão Code e selecione uma das opções: 
	* Linha de comando do git
		* git clone https://github.com/raphaelpereiravalle/ProjetoCinema.git
	* Clone o repositório diretamento para o Visual Studio ou Visual Code;
	* Download;
	
<p align="center">
  <img src="assets/img/clone.PNG" alt="Clone github" />
</p>

* Conecte o Sql Server para restaurar o banco de dados, use a opção de Windows Authentication para autenticação do banco dados e inclua o Server Name. Após conectar selecione, o 
<a href="https://github.com/raphaelpereiravalle/ProjetoCinema/tree/master/BancoDeDados">arquivo</a> e execute-o na New query. 

<p align="center">
  <img src="assets/img/conectar.PNG" alt="Conectar" />
</p>

<p align="center">
  <img src="assets/img/new_query.PNG" alt="New_query" />
</p>

* É importante configurar o *Startup Project* do projeto. Para isso, clique com o botão direto em Solution, clique em Properties e selecione a opção Start na coluna Action (Lembrando que essa opção pode ser customizada).
 
<p align="center">
  <img src="assets/img/solucao.PNG" alt="Solução" />
</p>

<p align="center">
  <img src="assets/img/propriedade.PNG" alt="Propriedade" />
</p>

* Acesse o arquivo appsettings na camadas 2 - Services -> WebApi e configure a conexão com o banco de dados.

<p align="center">
  <img src="assets/img/conexao.PNG" alt="Conexão" />
</p>

* Execute o Build Solution. Depois clique em Start para executar o projeto.

<p align="center">
  <img src="assets/img/start.PNG" alt="Start" />
</p>

## Author

The ProjetoCinema was developed by Raphael Pereira Valle.