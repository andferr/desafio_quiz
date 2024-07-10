
# Desafio Quiz - Clean Code e Clean Architecture

Um desafio de estudo para juniors de um projeto .NET seguindo conceitos de Clean Architecture e Clean Code. 
## Descrição do desafio

`Objetivo:` Desenvolver e reforçar conhecimentos de Arquitetura, POO, Design Patterns, Clean Code, SOLID e .NET 8.

`Dinâmica:` O projeto será desenvolvido a partir de uma base de código pré-construída que implementa a estrutura recomendada para a Clean Architecture e um banco de dados pré-existente. A aplicação deve seguir o escopo definido neste documento e após finalizada deverá ser apresentada e discutida com outros desenvolvedores.

`Escopo:` O sistema desejado é uma plataforma de gamificação para a empresa. Inicialmente, o foco é criar quizzes envolvendo informações, números e curiosidades sobre a Maislaudo.


**A plataforma deve possuir os seguintes requisitos:**
-   **Perfis de colaboradores:**
    -   Existem dois tipos de perfis - gestão e funcionário padrão.
    -   Perfil de Gestão: Terá acesso à área administrativa, podendo criar quizzes.
    -   Perfil Comum: Poderá apenas responder ao quiz atual.

-   **Segurança/Autenticação:**
    -   Deve existir um endpoint de autenticação.
    -   Para todas operações o usuário deve estar autenticado.
    -   O usuário poderá trocar sua senha através de um endpoint
    -   O usuário deve ser forçado a trocar a senha inicial. Realizando essa troca ele é ativado.
    -   Usuários inativos não conseguem realizar nenhuma outra operação.
    -   Visualização de Ranking: Todos os perfis podem visualizar o ranking dos funcionários.

-   **Tipos de Quizzes:**
    -   Múltipla Escolha: Composto por 5 opções, sendo apenas uma correta.
    -   Numérico: Possui um valor correto, e ganha quem mais se aproximar deste valor.
-   **Cadastro de Quizzes:** 
    -   O cadastro deve permitir a inserção da pergunta, das opções de resposta, a indicação da resposta correta ou o valor que os usuários tentarão acertar.
-   **Pontuação:**
    -   Cada quiz vale 10 pontos para quem acertar.
    -   O primeiro a acertar recebe 5 pontos adicionais.
    -   Este ponto adicional só será atribuído se mais de uma pessoa acertar a resposta ou houver um empate no palpite do número correto.
-   **Ranking:**
    -   Os pontos devem ser contabilizados e somados, permitindo a consulta do ranking dos funcionários com as maiores pontuações.
-   **Respostas:**
    -   Cada usuário pode responder o quiz apenas uma vez.
-   **Requisitos técnicos:**
    - Autenticação JWT, Criptografia de senha, seeder para inserir os primeiros usuários.
    - O sistema se trata apenas de uma API e deve receber e retornar dados de forma a ser possível a construção de um frontend independente. 
### Estrutura base do projeto

    .
    ├── docs                    # Documentação e outros arquivos auxiliares do projeto
    ├── src                     # Código fonte do projeto
    │   ├── Quiz
    │   │    ├── Core
    │   │    │    ├── Application
    │   │    │    └── Domain
    │   │    ├── Infraestructure
    │   │    │    └── Persistence
    │   │    ├── Presentation
    │   │    │    └── WebApi
    └── README.md

### Anexos

**Arquitetura do projeto**
![Representação da arquitetura do projeto, circulos concentricos que representam de fora para dentro as camadas Presentation, Infraestruture e Core](/docs/arquitetura.jpg)

**Modelo ER**
![Diagrama entidade relacionamento da base de dados](/docs/modelo_eer.png)