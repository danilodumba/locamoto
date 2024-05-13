## O que é o Locamoto?
Locamoto é um projeto para locação de motocicletas com pedidos de delivery para os entregradores com motos alugadas.

## Objetivo
Esse projeto tem por objetivo passar conhecimentos e técnicas de desenvolvimento para desenvolvedores C# .NET

## Tecnologias utilizadas

- C# .NET
- Banco de dados Postgres
- Mensageria com RabbitMQ
- Banco de dados não relacional (NOSQL) com MongoDB
- Armazenamento em nuvem com o minIO.
- Docker
- DDD.
- Arquitetura Limpa
- Migrations
- Testes de Unidade
- Testes de Integração.
  
## Idéia da Solução

Na teoria deveria existir os serviços separados para a API locamoto e API de notificações de pedidos, mas como é um projeto para didática fiz utilizando somente uma API. Acredito que irá conseguir compreender os contextos. 


## Como rodar o projeto?

>**Note:** Será preciso o Docker e o .NET 8 instalado na sua máquina.

Abra o terminal e rode os comandos abaixo.

1 - Na raiz do projeto execute o comando `docker-compose up` para subir a infraestrutura;
2 - Na pasta `Locamoto.Infra.PostgreSql` excute o comando `dotnet ef database update para gerar o banco de dados;
3 - Na raiz do projeto execute o comando `dotnet test` para testar se o projeto esta funcionando sem quebras. 

Basta rodar o projeto e brincar com as APIs.

>**Note:** Lembre - se isso é so um meio de como fazer, não significa que estará certo pra o seu contexto.