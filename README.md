## Projeto de Task Lista (criação de tarefas)
Projeto desenvolvido em Asp .Net Core 2.2 para lista de tarefas

## Estrutura de implementação:

	Business: biblioteca que contém todas as regras de negócio e suas respectivas interface
	Core: biblioteca que contém todas as classes reutilizadas por toda aplicação
	ModelData: biblioteca que contém todos os modelos de dados, view models, e migration
	Repository: biblioteca que contém todas os repositórios da aplicação
	Util: biblioteca que contém todos o utilitário da aplicação. Ex: enums, constantes, poderia ser funções, entre outras.
	WebApp: aplicação web desenvolvinda em .Net Core 2.2, com uso de API e consumo via front-end independente 
      
## Objetivo
  Demonstrar o uso da tecnologia asp .net core 2.2, como alguns design patterns e algumas boas práticas em desenvolvimento
  
## Tecnologia Front-End

* **[Mustache js](https://mustache.github.io/)** 
* **[Jquery](https://jquery.com/)** 
* **[Bootstrap](https://getbootstrap.com/)** 
* **[Font Awesome](https://fontawesome.com/)** 

## Tela
 Tela de inclusão, exclusão, e edição das tarefas.
 Para marcar ou desmarcar uma tarefa como finalizada, somente clicar na linha da tarefa, caso queira ver a documentação da API só clicar no link do topo, você será redirecionado para a documentação que foi utilizado o [Swagger](https://swagger.io/)
![alt text](https://raw.githubusercontent.com/wellingtonalvesdasilva/projeto-list-task-netcore22/master/WebApp/wwwroot/img/tela.PNG)
