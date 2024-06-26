## O que é o Locamoto?
Locamoto é um projeto de aprendizagem com requisitos para locação de motocicletas com pedidos de delivery para os entregradores com motos alugadas.

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

Na teoria, deveria existir os serviços separados para a API locamoto e API de notificações de pedidos, mas como é um projeto para didática fiz utilizando somente uma API. Acredito que irá conseguir compreender os contextos.

<p>
<img src="https://github.com/danilodumba/locamoto/blob/main/docs/Locamoto.png" />
</p>

>**Note:** Lembre - se isso é so um meio de como fazer, não significa que estará certo para o seu contexto.


## Como rodar o projeto?

>**Note:** Será preciso o Docker e o .NET 8 instalado na sua máquina.

Abra o terminal e se tiver o Bash rode `sh locamoto.sh` caso contrário siga os passos abaixo.

- Na raiz do projeto execute o comando `docker-compose up` para subir a infraestrutura;
- Na pasta `Locamoto.Infra.PostgreSql` excute o comando `dotnet ef database update` para gerar o banco de dados;
- Na raiz do projeto execute o comando `dotnet test` para testar se o projeto esta funcionando sem quebras. 

Basta rodar o projeto e brincar com as APIs.

## Acessos a Infra.

- RabbitMQ => http://localhost:15672
- minIO => http://localhost:9001
  >**Note:** Caso tenha problemas para acesso ao MinIO, crie uma nova chave de acesso no console do MinIO.
- MongoDB => Sugiro o Compass da propria MongoDB ou o seu favorito.
- Postgres => Sugiro o DBEver ou o seu favorito.



>**Note:** Senhas de acesso aos banco de dados, mensageria e minIO encontra - se no appsettings.json ou no docker-compose.

>**Note:** Erros de Ingles ou Qualquer outra sugestão no codigo, baixa ai e faz um PR vai ser legal trocar uma ideia.