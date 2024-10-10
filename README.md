# App

## Estrutura básica
A solução está dividida em projetos (camadas), cada um com sua responsabilidade. Atente-se para função específica de cada projeto para que nenhuma responsabilidade seja invadida por outro projeto.

- **App.Shared:** O projeto "Shared" (Compartilhado) contém constantes, métodos de extensão, filtros e classes helpers que podem ser usados por todos os demais projetos da aplicação.
- **App.services:** Serviços são implementações que não fazem diretamente parte do escopo da solução ou companhia. Exemplo: não é responsabilidade do sistema/companhia criar arquivos de log, mas estes são necessários para se ter uma rastreabilidade do que acontece no sistema. Este então deve ser um serviço externo a aplicação.
- **App.Repository:** Camada de acesso aos dados. Somente nesta camada devem ser escritas queries e demais consultas no banco de dados. Existem métodos genéricos para salvamento e atualização dos registros, no entanto, caso seja necessária a criação de métodos específicos para esta finalidade, estes devem ser escritos na camada de repositório.
- **App.IoC:** Camada de inversão de controle.
- **App.Infrastructure:** Camada com configurações estruturais do sistema como conexão com banco de dados e mapeamento das entidades.
-  **App.Domain:** Camada com informações de domínio da aplicação. Contem as entidades, enumeradores, objetos de valor e DTOs. Todos separados em contextos delimitados.
- **App.Business:** Camada com as regras de negócio da aplicação.
- **App.Api:** Camada de apresentação.

## Núcleo do sistema
O objetivo desta aplicação (solução) é servir de base estrutural para outras aplicações. O núcleo deve conter código e regras que serão herdadas por todos os demais projetos e sua estrutura, funcionalidades e regras não devem ser sobrescritas por projetos herdeiros. Qualquer mudança a ser feita no núcleo do sistema, deverá ser realizada na banch core e posteriormente herdada pelas demais branches.

