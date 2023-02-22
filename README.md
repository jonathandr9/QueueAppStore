# QueueAppStore  


Projeto de loja de APPs com processamento de pagamentos por cartão em fila (RabbitMQ)   

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


