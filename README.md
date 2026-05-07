# Agendador de Taredas | Ad Ministerio Atos

Esse projeto se concentra em criar um agendador de tarefas para de forma assincrona e programada, executar ações como:
- Agendar lives no Youtube com base em eventos da Igreja
- Encaminhar mensagens de telegram/whatsapp programaticamente com base em linhas de uma tabela

## Arquitetura
O projeto precisa seguir uma arquitetura que lembre um pouco da clean arch, sendo:
- Core: 
    - modelos de dados (rich domain), 
    - serviços (tanto de dominio - um por modelo - quanto para multiplos dominios - ações especificas.
    - interfaces: aqui decidimos o contrato dos repositorios e serviços especificos
- Aplication: 
    - Commanders
    - Contratos para:
        - Serviços externos (storage, comunicação)
- Infra:
    - repositorios concretos (usando o ORM
    - mapeadores (classmap do nhibernate)
    - serviços/helpers/utils que implementam concretamente os serviços especificados na aplicação
- Jobs
    - Contratos: interfaces dos jobs

## Fluxo
### Agendador de lives no youtube
```mermaid
sequenceDiagram
  participant Trigger as Trigger (Quartz)
  participant Job as Job
  participant Service as Service
  participant Communication as Communication

  Trigger ->>+ Job: 1. Executa o job de agendamento de lives semanal
  Job ->>+ Service: 1.1 Verifica os eventos no banco
  Job ->>+ Service: 1.2  Verifica os agendamento no banco
  Job ->>+ Service: 1.3 Chama o serviço de agendamento
  Job ->>+ Service: 1.4 Persiste os dados de agendamento
  Job ->>+ Communication: 1.5 Envia o log completo no telegram
```

## Proximos passos
- [ ] Criar endpoints para rodar um job manualmente
- [x] Alterar a forma de comunicação com o banco de rest para SQL (NHibernate)
- [x] Usar o Liquibase para criar e versionar o banco
- [ ] Verificar o uso das SDKs do Telegram, Youtube e Cloudnary em vez das APIs
