# Trabalho de Conclusão de Disciplina - Tecnologias Microsoft
   Supondo que você esteja sendo contratado para desenvolver um sistema C2C para uma empresa que deseja realizar a venda de produtos únicos como é feito, por exemplo, na OLX. Para tanto, lhe foi forneceido o Script do Banco de dados abaixo.
```sql 
CREATE DATABASE BDVendaDireta
GO
 
USE BDVendaDireta
GO
 
CREATE TABLE Usuario
(
  UsuarioId     int           primary key     identity,
  Nome          varchar(60)   not null,
  Email         varchar(100)  not null        unique,
  Senha         varchar(20)   not null,
  Receita       decimal(9,2)  not null
)
 
CREATE TABLE Produto
(
  ProdutoId     int           primary key     identity,
  UsuarioId     int           not null,
  Nome          varchar(200)  not null,
  Preco         decimal(9,2)  not null,
  Vendido       bit           not null,
  foreign key (UsuarioId) references Usuario (UsuarioId)
)
```
O sistema deverá contar com as seguintes funcionalidades, contemplando a ordem abaixo:
 
1. Tela de cadastro de usuário.
2. Uma vez realizado o cadastro, o usuário deverá, a partir de outra tela, efetuar o login no sistema.
3. Ao efetuar o login, o usuário será redirecionado para uma tela com a listagem de todos os produtos à venda (Vendido = false).
4. Nesta mesma tela deve haver um botão chamada "Adicionar" que ao clicá-lo, o sistema deverá redirecionar para uma tela de cadastro de produto onde será fornecido o nome e preço do produto a ser vendido. Ao efetuar o cadastro o sistema deverá redirecionar para a tela de listagem novamente (Item 3)
5. Na tela de listagem (Item 3), cada produto deverá conter um botão para efetuar sua compra. Ao ser clicado, o sistema deverá redirecionar para uma tela com os detalhes do produto.
6. Na tela de detalhes, deverá haver um botão para confirmar a compra. Ao confirmar, a propriedade "Vendido" do produto deverá ser alterado para true. O valor do produto deverá ser acrescido à receita do usuário vendedor. Em seguida, o sistema volta para a listagem de produto (Item 3).
7. Em todas as telas deverão ser exibidos o nome e receita do usuário autenticado no sistema, assim como um botão de logout que, quando clicado, retorna para a tela de login.
 
Para o desenvolvimento, a empresa indicou que:
 
1. O sistema poderá ser desenvolvido utilizando ASP.NET MVC 5 (.NET Framework) ou ASP.NET MVC Core ou Ionic ou Xamarin, sendo que no caso destes dois últimos o BackEnd deverá ser desenvolvido utilizando também ASP.NET MVC 5 ou ASP.NET Core Web API.
 
2. A manipulação da base de dados pode ser feita utilizando o Entity Framework ou a programação direta de SQL utilizando ADO.NET.
 
Ao concluir o desenvolvimento do sistema, este deverá ser enviado à um repositório do GitHub ou BitBucket.
 
Atenciosamente,
Empresa que está te contratando.
