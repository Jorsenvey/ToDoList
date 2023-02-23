# ToDoList
Proyecto ToDoList Prueba Tecnica
Dirigida a Jaime Correa
Presentada por Jorsenvey Perez Aguilar


Este proyecto se compone de:
1. Base de datos SQL Server 
2. Back-End realizado en .Net 6 proyecto API-Rest
3. Front-End realizado en React Antd

Explicación
Tenemos una Front hecho en ReactJs usando la interface grafica Antd, este front permite al usuario ingresar sus actividades diarias o usarlo como una lista de tareas diarias, usa la libreria axios para iteractuar con una API-Rest en .Net6, para obtener las actividades diarias del cliente, permite guardar nuevas tareas, borrar tareas, actualizar tareas, toda esta información se guarda en una base de datos Sql-Server usando en Entity framework.

La API-Rest expone 5 metodos:
1. GetAllTask: metodo Get que va a la base de datos sql-server y retorna las actividades que se encuentren en estado 0 ó 1.
2. UpdateDescriptionTask: metodo post recibe tres parametros el idTask, descriptionTask y IdStatusTask, actualiza los datos usando el IdTask
3. UdpdateStatusTask: metodo post recibe dos parametros idTask y idStatusTask, actualiza el estado de la tarea usando el IdTask
4. DeletTask: metodo post que recibe el parametro IdTask, actualiza el registro en estado 2
5. AddTask: Metodo post que recibe descriptionTask, inserta una nueva tarea y la guarda por defecto en 0

Se contruyo en 4 capas:
1. TO_DO_List_Backend: es el controller que recibe y retorna las peticiones desde el frontend
2. TO_DO_List_Backend.Application: recibe las peticiones del controller a travez de un contrato (Interface), esta capa tiene la logica de negocio, tambien hace la conversión del entity a Dto y se conecta a la capa que maneja los datos
3. TO_DO_List_Backend.Persistence: expone un contrato (interface), recibe las peticiones desde la capa de application y se encarga de conectarse a la base de datos
4.TO_DO_List_Backend.Domain: es la capa transversal que tiene las clases comunes que usa el proyecto como el modelo, el Dto y el enumerado


La base de datos tiene dos tablas:
1. [TasksList], tiene 3 columnas [IdTask] autonumerico, [DescriptionTask] Nombre de la tarea, [IdEstatusTask] estado de la tarea
2. [TaskStatus], tiene dos columnas [IdTaskStatus] es el id del estado y esta relacionado por una FK a la tabla TasksList.IdEstatusTask , [TaskDescriptionStatus] es el nombre del estado.
Adjunto los scripts de creación de la base de datos junto con los datos de prueba que realice

Resumen de todo el proyecto
En este proyecto funcionan los 5 servicios expuestos en el BackEnd, funciona la conexión con la base de datos a travez de entity framework, el front guarda tareas, actualiza el nombre de las tareas, actualiza el estado de las tareas, obtiene las tareas, elimina las tarea. lo que no me funciona fue el manejo apropiado de los checkbox, por ejemplo si una tarea esta en false el checkbox muestra que la tiene en true, intente mucho y probe diferentes formas pero no me dio

Quiero agradecerles la oportunidad de hacer esta prueba, me ayudo a afianzar mis conocimientos y aprender de React.
me gustaria trabajar con ustedes, por eso me esforce bastante durante estos días, en hacerlo lo mejor posible y de buena calidad
Muchas gracias y quedo atento, me gustaria tener una reunión y mostrar el funcionamiento desde la maquina que realice la implementación, ya que para poder subir el proyecto me toco eliminar todos los paquetes de React, que ocupaban casi 500Mb, pero no elimine nada del código fuente
