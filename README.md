# ControleFinanceiro
App ControleFinanceiro API Rest

Breve estudo sobre patterns, CRUD, SOLID, DDD, Token Authentication, abstrações e consumo de API's externas.

Estou desenvolvendo uma API simples com o objetivo de consolidar meus conhecimentos.

A ideia deste projeto é desenvolver um app capaz de fazer um CRUD em lançamentos de despesas e receitas.

A estrutura principal desta API está totalmente desacoplada, dando uma liberdade gigante para implementar a parte de persistência de dados, serviços (emails, sms, token) e etc.

O primeiro passo para usar o App é realizar um cadastro informando NOME, TELEFONE e EMAIL.

Para fazer login no app, é necessário informar o EMAIL, e logo em seguida o código que a API envia através de SMS para o TELEFONE cadastrado.

Ao fazer o cadastro ou realizar o login, o usuario recebe um JWT e pode utilizar a API.
