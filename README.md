# Dogi

La aplicación se encuentra corriendo en la siguiente [dirección](https://hotapi.azurewebsites.net/graphql).

# Tabla de Contenidos

- [Introducción](#introducción)
- [Instalación](#instalación)
- [Despliegue](#despliegue)
- []
- [Descripción técnica](#descripción-técnica)
  - [Requisitos funcionales y no funcionales](#requisitos-funcionales-y-no-funcionales)
- [Arquitectura de la aplicación](#arquitectura-de-la-aplicación)
  - [Componentes](#componentes)
- [Modelo de datos](#modelo-de-datos)
- [Tecnologías utilizadas](#tecnologías-utilizadas)
- [Metodología de desarrollo](#metodología-de-desarrollo)
- [Justificacion temporal](#justificacion-temporal)
- [Conclusiones](#conclusiones)
  - [Posibles mejoras](#posibles-mejoras)
  - [Principales dificultades](#principales-dificultades)


## Introducción

El objetivo del proyecto es exponer una API que pueda ser integrada y sirva para cualquier protectora de animales facilitando las tareas básicas y estándar de este tipo de establecimientos.

Tareas como nuevos registros, expedientes individuales, adopciones, vacunaciones, revisiones médicas

## Instalación

Necesitas cumplir los siguientes requisitos para poder ejecutar el proyecto.

- NET 6.
- Windows o sistema Linux.

## Instrucciones

Clona el repositorio.
```shell
git clone git@github.com:dEzequiel/Dogi.git
cd Dogi
```

Construye el proyecto con sus dependencias.
```shell
dotnet build
```

Ejecuta el proyecto principal.
```shell
dotnet run \Api\Api.csproj
```
## Despliegue

La aplicación estuvo corriendo unos días en los servidores de aplicaciones web de Azure, junto a la base de datos en los servicios de bases de datos. He tenido que dar de baja a estos servicios hasta la fecha 12/06/2023 por el costo imprevisto que me supuso tener la base de datos en marcha.

Actualmente hay una deuda que me impide poder utilizar sus servicios y, por lo tanto, seguir dando hospedaje a la aplicación. (Hay pruebas de que estuvo operativa) Estoy buscando otra opcion.

# Descripción técnica

## Requisitos funcionales y no funcionales

Los actores que se involucran en el sistema son 3. Dos de ellos son trabajadores de una protectora con la diferenciacion entre un administrador y un veterinario. El tercero es un usuario normal.

**Historias de usuario**

-  Como administrador quiero permitir el registro de nuevos animales que lleguen a la protectora.
-  Como administrador registrar información de los dueños encontrados en un chip.
- Como administrar bloquear las solicitudes de adopciones para personas prohibidas.
- Como administrador publicar adopciones pendientes disponibles para aplicar.
- Como administrador descartar y aprobar aplicaciones para una adopción.
- Como veterinario o administrador crear una revisión médica.
- Como veterinario dar por completado o en observación una revisión médica.
- Como usuario listar las adopciones disponibles para aplicar.
- Como usuario aplicar a una solicitud de adopción.

**Requisitos no funcionales**


## Arquitectura de la aplicación

![arquitectura](https://github.com/dEzequiel/Dogi/assets/91556738/3fa74c20-9cea-48ff-9382-e934bc0e7650)

## Componentes

![componentes](https://github.com/dEzequiel/Dogi/assets/91556738/5c884d67-b21c-4131-a89a-6bed73c929e7)

**Domain Layer**

- **Veterinary** contiene la implementación de entidades relacionadas al modulo de veterinaria.

- **Authorization** contiene la implementación de entidades relacionadas al modulo de autenticación y autorización.

- **Adoption** contiene la implementación de entidades relacionadas con el modulo de adopción.

- **Shelter** contiene la implementación de las entidades relacionadas en rasgos generales con las entidades existentes en una protectora de animales.

- **Enumerators** contiene la implementación de los enumeradores en relación a las opciones disponibles dentro de operaciones que tengan como entidad relacionada estados o tipos.

- **Value Objects** contiene la implementación de objetos los cuales no tienen una entidad en si y su valor reside en la información que contienen.

**Hotchocolate GraphQL Server (API Layer)** 

- **Queries** expone todos aquellos objetos a los que un usuario autenticado y con los permisos necesarios puede obtener. 

- **Mutations** expone todas aquellas mutaciones disponibles a los usuarios autenticados y con los permisos necesarios para realizar cambios en la base de datos.

- **Hotchocolate EnumTypes** contiene todos los enumeradores del dominio para poder ser utilizado dentro de mutaciones o queries como valores.

- **Hotchocolate InputTypes** contiene todos los objetos utilizados como argumentos pasados a las mutaciones.

- **Hotchocolate ObjectTypes** contiene todos los objetos utilizados en el dominio con la intención de proteger contra autorización o ignorar campos presentes en las entidades de dominio.

**Application Layer**

- **Read Services** contiene todas las implementaciones para poder leer entidades almacenada en base de datos. Cada servicio corresponde a una entidad del dominio.

- **Write Services** contiene todas las implementaciones para poder escribir, actualizar y borrar entidades de la base de datos. Cada servicio corresponde a una entidad del dominio.

- **CQRS Features** contiene todas las features divididas en Commands o Queries para la partición lógica de los flujos del sistema, lectura y escritura.

- **WelcomeManager** contiene toda la lógica necesaria para hacer posible el registro de nuevos animales en el sistema.

- **UserManager** contiene la implementación para el registro, inicio de sesión, generación de token para la autenticación y asignación de roles.

- **AdoptionManager** contiene la lógica para hacer posible el registro de animales disponibles para la adopción, aplicaciones a una adopción por parte de usuarios y asignación de adopciones cerradas a personas.

- **VeterinaryManager** contiene la lógica para generar consultas medicas adheridas a un animal, registro de vacunaciones o revisiones medicas.

**Infraestructure Layer**

- **Authentication handler** es un handler de autorización utilizado para determinar si el actual usuario tiene los permisos necesarios para realizar la acción.

- **Authentication policies y Authentication provider** contiene la implementación para registrar el handler de autorizacion con las politicas provenientes del authentication provider.

- **Database context** es instancia que representa una sesión con la base de datos. Se registran todas las tablas y configuracion.

- **UnitOfWork** es la implementación necesaria para aplicar el patrón unidad de trabajo donde todas las operaciones se hacen en una sola transacción con éxito o sin el.

- **EntityFrameWork Configuration** contiene todas las configuraciones de las entides de dominio como tablas en la base de datos.

- **Repositories implementation** contiene las implementacion de los repositorios para el acceso a datos.

**Crosscuting** 

- **Exceptions** contiene las excepciones conocidas del sistema.
- **Interfaces** contiene la definición de tipos utilizados a través del sistema.
- **DTOs** contiene la implementación de data transfer objects utilizados a través del sistema.

## Modelo de datos

![Dogi Data Model](https://github.com/dEzequiel/Dogi/assets/91556738/c4af4170-437c-442d-8b3b-dafd2e6e1477)

## Tecnologías utilizadas

[C#]()

- **.NET 6** es un conjunto de herramientas y tecnologías proporcionadas por Microsoft. que permiten a los programadores crear aplicaciones para diferentes sistemas operativos y dispositivos. Permite la interoperabilidad entre diferentes lenguajes de programación, lo que significa que puedes combinar componentes escritos en distintos lenguajes. [Referencia](https://learn.microsoft.com/en-us/training/dotnet/).

- **Ardalis.GuardClauses** es una librería que me permite aplicar el patrón guard clause (técnica para fallar rápidamente en un método, especialmente en un constructor. Si un método (o instancia de objeto) requiere ciertos valores para funcionar correctamente). [Referencia](https://ardalis.com/guard-clauses-and-exceptions-or-validation/) - [Repositorio](https://github.com/ardalis/GuardClauses)

- **xUnit** es una herramienta de prueba gratuita, de código abierto y centrada en la comunidad para el .NET Framework. [Referencia](https://xunit.net/) - [Repositorio](https://github.com/xunit/xunit)

- **Moq** es una librería utilizada en pruebas unitarias para aislar la clase bajo prueba de sus dependencias y garantizar que se llama a los métodos adecuados en los objetos dependientes. [Referencia](https://learn.microsoft.com/en-us/shows/visual-studio-toolbox/unit-testing-moq-framework) - [Repositorio](https://github.com/moq/moq)

[GraphQL](https://graphql.org/)

- **Hotchocolate** es un servidor GraphQL de código abierto creado para la plataforma Microsoft .NET. Elimina la complejidad de crear API de GraphQL desde cero con características integradas para consultas, mutaciones y suscripciones. [Referencia](https://chillicream.com/docs/hotchocolate/v13/security) - [Repositorio](https://github.com/ChilliCream/graphql-platform)


# Metodología de desarrollo

Se debe de tener en cuenta que durante todo el desarrollo del proyecto se ha experimentado la falta de conocimientos profundos del dominio al cual Dogi da una solución. Se ha investigado por cuenta propia documentos, protocolos y múltiples fuentes de información, desde documentos publicados por el Gobierno de España sobre protectoras o santuarios de animales hasta información otorgada por una protectora cercana como es la Protectora de Son Reus. 

Con esto en mente, se ha optado una **metodología incremental** construyendo funcionalidades del sistema pequeñas para al final de agruparlas y dar con la implementación para una solución a la problemática que en ese momento se intentaba solucionar. Cuando se creaba una implementación pequeña se hacía con el objetivo a futuro de que formara parte de una implementación mucho más grande. 

Por ejemplo, cuando se realizaba el módulo de bienvenida (WelcomeManager) se empezó implementando la lógica para recibir al animal sin tener en cuenta si este tiene chip o no, esta casuística se identificó más adelante analizando el funcionamiento del módulo y sus carencias.

Otro ejemplo sería el módulo de veterinaria (VeterinaryManager) donde se empezó desarrollando la implementación que permita a un usuario normal realizar aplicaciones encima de una adopción disponible. Al terminarla la implementación se tiene en mente la pregunta "a que estás aplicando?

Esto ha tenido muchos frutos a nivel personal y de conocimientos para organizar código o ideas que no están encima del papel pero que a futuro lo estarán.

# Justificacion temporal

![tiempo](https://github.com/dEzequiel/Dogi/assets/91556738/4a4bc5e8-f90c-4215-87fc-8f6ad3d37366)

Con el trazamiento del tiempo invertido en el proyecto no he tenido problema cuando empecé a desarrollar los módulos. Como se dijo antes, nada de experiencia en el dominio se traduce en que el módulo de recepción, donde todo empieza, fue donde más tiempo se invirtió, duplicando el tiempo que se había establecido en el anteproyecto. En el anteproyecto no sale reflejado las horas que se han invertido en investigación fuera de la implementación de los protocolos de actuación y actividades que realizan las protectoras de animales. Esta investigación se hizo antes de empezar a trazar regularmente el tiempo invertido en el proyecto. No fue algo que tuve en mente trazar, lo hacía en mis horas libres navegando por internet, poniéndome en contacto específicamente con la perrera de Son Reus y leyendo PDF.

Las franjas de algunos módulos se dividen en un mismo bloque al ver que no se podía avanzar en la implementación de x módulo sin tener la implementación y de un módulo. Por ejemplo, el módulo de veterinaria no se podría empezar a desarrollar si no existiese el módulo de expediente individual.

He de admitir que el trazar el tiempo de desarrollo al principio del proyecto cuando no se tiene asumido todo se hace fácil, una tarea regular y cotidiana, pero cuando se me empezaban a venir los días encima se me hizo más complicado siempre.

# Conclusiones

## Posibles mejoras

El sistema de autorización está basado en políticas que hacen referencia a los permisos que asignados a un rol, cada tipo de usuario tiene un rol asignado. Esto en Dogi significa que cada acción que vaya a realizar un usuario se requiere de un permiso que autorice que ese usuario puede realizarla. La lista de permisos no es enorme pero tiene un tamaño considerable como para optar por otra via y creo fuermennte que podría sustituir este sistema de autorizacion por un sistema basado en roles. Esto es algo a estudiar, pues si se apllica esta autorización basada en roles se deberá de poder igualar a la autorización actual que tienen ciertos tipos de objetos Hotchocolate con campos individuales securizados.

También algo que no me llamaba mucho es la implementación actual para validar si un usuaario tiene los permisos para realizar una acción, cada vez que un usuario realice una acción que esté autorizada se realiza una peticion a base de datos para ver si el usuario tiene el permiso requerido asignado.

Una tarea que sigue pendiente es mejorar el sistema de respuestas que ofrece Hotchocolate dentro del proyecto. Tanto los errores como las respuestas que devuelve el servidor Hotchocolate en ciertos la mayoría de casos no son serializados en respuestas HTTP conocidas en servicios REST, GraphQL devuelve un objeto estándar en todas las respuestas que contiene o los datos o errores.   

En el apartado de tests que quiere realizar mejores implementaciones de testing para una API GraphQL. Hotchocolate da herramientas para realizar el testing de las respuestas.

## Principales dificultades 

Al principio del proyecto cometí el gran error de estimar sin tener en mente la cantidad de tiempo necesario para aprender una implementación de una tecnología como lo es GraphQL con Hotchocolate la cual no esta muy apoyada en documentación extensa y minuciosa como Apollo Server en el ecosistema NodeJS. Hubo una gran inversion de tiempo en conocer como funcionaba algunos términos que trae GraphQL en contra a ciertos términos conocidos y interiorizados por codificar siempre servicios REST. Por ejemplo, las respuestas con codigo http.

Conectándolo con lo anterior, la falta de conocimientos y de tiempo para conocer, implementar y desplegar servicios de Azure me han mermado tanto en estado de animo (no saber que hacer, no entender los recursos que encontraba, falta de ciertos conocimientos) como en desesperación al tener que cumplir una tarea y ver que no consigues desplegar tu proyecto.

Con Azure he invertido/gastado gran cantidad de tiempo conociendo que servicios me daban lo que realmente yo requería. Una gran dificultad que me llego a desesperar es no tener claro como desplegar la API y que fuera accesible desde fuera de mi local junto a un cliente (Banana Cake Pop) que permita ejecutar GraphQL. 

- ¿Se despliegan por separado?
- ¿Se despliegan juntos?
- ¿Se despliega la API y desde el cliente eat.banancakepop.com apunto a ella?
- ¿Es necesario desplegar una interfaz como Banana Cake Pop si no tengo un frotend?
- ¿Necesito un servicio de Azure Web App solo para el cliente Banana Cake Pop?
- ¿Realmente se despliega en Azure API Management?
- ¿Es Azure Functions la mejor forma de desplegar una API GraphQL?

Otra dificultad con la cual lidie unos 2-3 dias fue entender como Hotchocolate se comportaba junto al sistema de autenticación de .NET. Al principio tenia la idea de que Hotchocolate se encargaría tanto de la autenticación como de la autorización pero no era así. La autenticación corre por parte de .NET y la autorización corre (si así se decide) por parte de Hotchocolate. Gaste tiempo desarrollando un middleware para la autenticación que verificaba el token JWT del usuario, cuando un middleware ya viene incluido para autenticar al usuario (reinventando la rueda como un champion).

## Conclusión

Disfrute haciendo este proyecto, la idea, la misión y la tecnología. El proyecto continuará su desarrollo hasta un producto final gratuito que se pueda implementar, es mi objetivo para estos 6 meses de año que quedan.
