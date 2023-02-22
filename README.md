# QueueAppStore  


Projeto de loja de APPs com processamento de pagamentos por cartão em fila (RabbitMQ)   

Este repositório se trata de uma API construída em .Net 6.0 seguindo o padrão de arquitetura Clean Archtecture. Tendo como material de referência o artigo da Microsoft 
[Arquiteturas comuns de aplicativo Web], que se trata de um trecho do livro [ASP.NET Core architecture e-book]  
    
O padrão de arquitetura pode ser melhor compreendido através da representação horizontal:    

![217387901-5f802da7-c24c-4b6e-99e8-1cfbfe8bf344](https://user-images.githubusercontent.com/27286681/220660714-7cbb7b09-b530-4149-9629-3a5354281ac4.png)


O worker que lê da fila de pagamentos segue o mesmo padrão de arquitetura porém com menos camadas, devido o contexto menor.

## 1. Intruções para preparo do ambiente de execução:  


### 1.1 Executar o comando no diretório raiz do projeto:

```
docker-compose up
```
Será criado o ambiente para execução da aplicação com o Redis e o RabbitMQ

![image](https://user-images.githubusercontent.com/27286681/220651922-df37b09f-cc50-488f-bca0-122233680896.png)


### 1.2 Alterar config base de dados SQL server:

Afim de simplificar o desenvolvimento e criação da base de dados, foi utilizado um banco de dados SQL Server em arquivo mdf, que é compartilhado entre a API e o Worker, o mesmo pode ser encontrado na pasta /Database do projeto.

Alterar o appSettings da Api e do Worker que para apontar para a base correta onde foi salvo o projeto clonado.

API
```
...\Producer\QueueAppStore\appSettings.json
```

Worker
```
...Consumer\ConsumerAppStore\appSettings.json
```

![image](https://user-images.githubusercontent.com/27286681/220655875-6f622644-66b7-4a24-91c0-0aa58fb1c7a8.png)


## 2. Execução da Aplicação

Com o ambiente preparado, basta executar as duas aplicações (API e Worker):

API: ``` ...\Producer\QueueAppStore\QueueAppStore.sln ```  

Worker: ``` ...\Consumer\ConsumerAppStore\ConsumerAppStore.sln ```





[ASP.NET Core architecture e-book]: https://dotnet.microsoft.com/en-us/download/e-book/aspnet/pdf
[Arquiteturas comuns de aplicativo Web]: https://docs.microsoft.com/pt-br/dotnet/architecture/modern-web-apps-azure/common-web-application-architectures
