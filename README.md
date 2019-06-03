# Desafio para vaga de arquiteto

## Solução Encontrada
A solução foi divídada em 3 apiicações para atender as demandas dos requisitos solicitado .

* Aplicações:
    * Worker
        Essa aplicação tem a funcionalidade de consumir e processar as mensagens enviadas para fila.
    * Api
        Aplicação  para receber os eventos dos sensores e envio-los para fila  e  disponibilizar os endpoints dos relatórios.
    * App (Usada com Nginx)
        Camada para consumir a api e exibir os relatórios para os clientes.

* Camadas de apoios
    *  Domain 
        Camada negócio responsável por centralizar toda regra dos requisitos citados.
  *  Domain.Tests
        Camada de teste do dóminio responsável para garantir que o domínio está funcionando de acordo com os requisitos.
    * Infra
        Camada de acesso a dados responsável por atender as necessidades da camada de domínio.
    * Crosscutting
        Atualmente a camada está sendo utilizada para definição da injeção de dependência, mas o intuito e que ela seja a camada responsável pelo Log entre outros.
## Tecnologias utilizadas
* Tecnologias
    * RabbitMq - Aplicação de mensageria responsável por receber as mensagens da api e entrega-las aos consumidores.
    * MongoDb - Banco de dados NoSql responsável por guardar as informações dos eventos dos sensores, a escolha por esse banco foi devido a alta demanda de escrita e o desempenho alcançado com ele.
    * Nginx -Proxy reverso utilizado para garantir uma camada de segurança e não expor diretamente as aplicações.
    * Docker.
* Bibliotecas de apoio
    *  Masstransit - Framework open souce que facilita no consumo da mensageria, o ponto forte desse framework é que ele abstraia a mensageria utilizada e deixa de forma transparente o seu uso, alem disso ele possui funcionalidades nativas de reenvio caso a mensageria esteja fora do ar ou ocupada.

    *  Swagger - Biblioteca open source de criação de documentação da api, todos endpoint estão comentados

## Como executar.
Clonar o repositorio e executar o comando abaixo na pasta raiz onde está localizado o arquivo  docker-compose.yaml e acessar a http://localhost e http://localhost/api/swagger. 
```code
docker-compose up
```

Obs.: Necessário o docker instalado no terminal

## O que eu implementaria se tivesse mais tempo
Deixei alguns TODOs pelo código para refatoramento  para melhorar ainda mais e também implementaria o NLog para log para auxiliar na possível correção de algum falha ou até mesmo pra auditoria.

## Considerações Gerais

* Sua solução deverá ser desenvolvida em dotnet core 2.1+.

* Devemos ser capazes de executar sua solução em uma VM limpa, com scripts de automatização de tarefas como Make, Shell Script ou similares. Esses scripts devem ser suficientes para rodarmos sua solução.

* Considere que já temos o seguinte ambiente:
    * Windows 10 Professional
    * Ubuntu 18.0.4
    * .NET Core 2.1

* No seu README, você deverá fazer uma explicação sobre a solução encontrada, tecnologias envolvidas e instrução de uso da solução. 

* É interessante que você também registre ideias que gostaria de implementar caso tivesse mais tempo.

## Problema

Imagine que você ficou responsável por construir um sistema que seja capaz de receber milhares de eventos por segundo de sensores espalhados pelo Brasil, nas regiões norte, nordeste, sudeste e sul. Seu cliente também deseja que na solução ele possa visualizar esses eventos de forma clara.

Um evento é defino por um JSON com o seguinte formato:

```json
{
   "timestamp": <Unix Timestamp ex: 1539112021301>,
   "tag": "<string separada por '.' ex: brasil.sudeste.sensor01 >",
   "valor" : "<string>"
}
```

Descrição:
 * O campo timestamp é quando o evento ocorreu em UNIX Timestamp.
 * Tag é o identificador do evento, sendo composto de pais.região.nome_sensor.
 * Valor é o dado coletado de um determinado sensor (podendo ser numérico ou string).

## Requisitos

* Sua solução deverá ser capaz de armazenar os eventos recebidos.

* Considere um número de inserções de 1000 eventos/sec. Cada sensor envia um evento a cada segundo independente se seu valor foi alterado, então um sensor pode enviar um evento com o mesmo valor do segundo anterior.

* Cada evento poderá ter o estado processado ou erro, caso o campo valor chegue vazio, o status do evento será erro caso contrário processado.

* Sua API deverá apresentar métricas sobre o volume de eventos recebidos por hora.

* Para visualização desses dados, sua solução deve possuir:
    * Uma tabela que mostre todos os eventos recebidos. Essa tabela deve ser atualizada automaticamente.
    * Um gráfico apenas para eventos com valor numérico.

* Para seu cliente, é muito importante que ele saiba o número de eventos que aconteceram por região e por sensor. Como no exemplo abaixo:
    * Região sudeste e sul ambas com dois sensores (sensor01 e sensor02):
        * brasil.sudeste - 1000
        * brasil.sudeste.sensor01 - 700
        * brasil.sudeste.sensor02 - 300
        * brasil.sul - 1500
        * brasil.sul.sensor01 - 1250
        * brasil.sul.sensor02 - 250

## Avaliação

Nossa equipe de desenvolvedores irá avaliar código, simplicidade da solução, testes unitários, arquitetura e automatização de tarefas.

Tente automatizar ao máximo sua solução. Isso porque no caso de deploy em vários servidores, não é interessante que tenhamos que entrar de máquina em máquina para instalar cada componente da solução.

Em caso de dúvida, entre em contato com o responsável pelo seu processo seletivo.