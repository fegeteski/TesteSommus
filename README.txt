# API COVID-19 (TESTE SOMMUS)

Está é uma aplicação desenvolvida em .Net 6 utilizando a linguagem c#, o teste faz parte do processo de avaliação técnica da Sommus Sistemas.

## TÉCNOLOGIAS UTILIZADAS:
.Net 6 (Back-end), MySQL (Banco de Dados), Técnologias Web (JS,HTML,SCSS) e Framework Web (ANGULAR). 

## COMO FUNCIONA?

A aplicação busca dados do COVID-19 no BRASIL no end point fornecido pelo Postman e persiste os dados no banco de dados MySQL. Ápos isto a aplicação com base em uma data fornecida pelo usuario na página web (Front-end) cálcula a média móvel de casos e mortes de COVID-19 e retorna os dados para o usuario.

## COMO UTILIZAR?

Primeiramente deve-se criar o banco de dados local no MySQL, ápos isso deve-se criar a tabela que séra utilizada pela aplicação utilizando a seguinte querie:

CREATE TABLE Country(
ID char(36) not null,
Country text ,
CountryCode text ,
Province text,
City text,
CityCode text,
Lat float,
Lon float,
Confirmed int,
Deaths int,
Recovered int,
ActiveCases int,
Date datetime
);                    

Ápos isso deve-se executar o arquivo "CovidWebApi.sln" utilizando VisualStudio 2022, o arquivo se encontra dentro da pasta /covidAPI. Com o arquivo aberto deve-se substituir as informações do seu servidor local, navegue pelo Solution Explorer, acessando a aba CovidWebApi e abrindo o caminho appsettings.json.

Com isso a API estára funcionando , já podemos executar nosso arquivo do back-end. Utilizando o VisualStudio Code selecione a opção "Open Folder" e abra o caminho de arquivos "\TESTE SOMMUS\covidFront\Covid". Feito isso o arquvo pode ser compilado.

Com tudo funcionando deve-se selecionar a data na aplicação e o número de semanas que o usuario deseja que seja exibido. 

## CONSIDERAÇÔES FINAIS
Agradeço muito a oportunidade de poder participar deste processo seletivo, a experiencia que ganhei executando este teste foi muito enriquecedora e desafiadora.