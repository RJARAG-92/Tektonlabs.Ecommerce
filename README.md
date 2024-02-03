
![analytics image (flat)](https://raw.githubusercontent.com/vitr/google-analytics-beacon/master/static/badge-flat.gif)
![analytics](https://www.google-analytics.com/collect?v=1&cid=555&t=pageview&ec=repo&ea=open&dp=/Plantilla-de-repositorio/readme&dt=&tid=UA-4677001-16)

<h1 align="center"> Challenge Tekton Labs</h1>
<p align="center"> En este repositorio encontraras la implementación del reto plantado por Tekton Labs. El reto consiste básicamente en desarrollar una solución Api Rest en .Net Core 8 implementando los mejores patrones de diseño de software. Así mismo, el reto demanda aplicar los principios SOLID, Clean Code y TDD (Test-Driven Development), y para la documentación se debe considerar utilizar swagger.

</p>
<p align="center"><img src="https://res.cloudinary.com/practicaldev/image/fetch/s--nsY4HBk_--/c_imagga_scale,f_auto,fl_progressive,h_420,q_auto,w_1000/https://thepracticaldev.s3.amazonaws.com/i/ge2kjywvjuee9nw53wme.png"/></p> 

Ver documentación del Challenge [Aquí](https://github.com/RJARAG-92/Tektonlabs.Ecommerce/blob/db0015de585b1de3fb5f6d2d456530d70e77a7dc/Evaluacion%20-%20.Net.pdf) 


## Tabla de contenidos:
---

- [Arquitectura de la Solución](#arquitectura-de-la-Solución)
- [Patrones de Diseño](#patrones-de-diseño)
- [Guía de instalación](#guía-de-instalación)
- [Despliegue en Contenedor](#despliegue-en-contenedor)
- [Conclusiones](#Conclusiones)


## Arquitectura de la Solución
---
La arquitectura de la solución se basa en Clean Architecture. Clean Architecture se representa principalmente en 04 capas: Domain, Application, Infrastucture y Presentation.

<p align="center"><img style="width:300px; text-align: center;" src="https://www.ssw.com.au/rules/static/6b8c75864933e5265075d7ae7f90b165/d7542/ca-diagram.png"/></p> 

En ese sentido, el diseño de la solución, está definido por las siguientes capas:
- Domain: Esta capa es el corazon de la arquitectura, contiene todas las entidades, enumeraciones, excepciones, tipos y lógicas específicas de la capa de dominio.
- Application: Esta capa contiene toda la lógica de la aplicación, DTOs, mapeadores. Depende de la capa de dominio, pero no depende de ninguna otra capa o proyecto. Esta capa define interfaces que son implementadas por capas externas.
- Infraestructure: Esta capa contiene clases para acceder a recursos externos como base de datos, sistemas de archivos, servicios web, SMTP, mensajería, colas, etc. Estas clases deben basarse en interfaces definidas dentro de la capa de aplicación.
- Persistence: Esta capa se ha agregado para interactuar con base de datos externos o con otros tipos de repositorios de datos.
- Presentation: Esta capa basicamen habilita endpoints e interactua con la capa de Application.
- Common: Esta capa es transversal, interactua con todas las capas, implementa funciones comunes o clases bases.



### Clean Architecture en .NET Core 8

En la siguiente figura se presenta el diseño de la solución en .NET Core 8 basado en el patrón de Clean Architecture. Así mismo, se puede observar las tecnologías utilizadas y las dependencias de cada capa. 

<p  align="center" href="https://freeimage.host/i/J0JkypS"><img style="width:90%; text-align: center;" src="https://iili.io/J0JkypS.png" alt="CleanArchitectureNetCore" border="0"></p>
 
Esta arquitectura permite realizar cambios importantes en la aplicación, sin grandes impactos. Además, permite cambiar el framework implementado en caso de ser necesario, ya que sus componentes están altamente desacoplado, o cambiar la base de datos o agregar alguna otra.

En la siguiente figura se evidencia la implementación la arquitectura propuesta en .NET Core 8, estructurado la solución en N-capas.

<p  align="center" href="https://freeimage.host/i/J0JkypS"><img style="width:90%; text-align: center;" src="https://iili.io/J0dR9EJ.png" alt="ImplementacionCleanArchitectureNetCore" border="0"></p>

## Patrones de Diseño
---
Los patrones de diseño son técnicas para resolver problemas comunes en el desarrollo de software y otros ámbitos referentes al diseño de interacción o interfaces. 

En la solución propuesta, como ya habiamos mencionado anteriormente, está basada en el Patrón Clean Architecture. En las siguientes capas se detalla los patrones implementados y sus principales aspectos técnicos.

### Capa de Presentation
- Patrón Inyeccion de Dependencias (OI)
- Control de Versiones de API utilizando parametros en el segmento en la URL.
- Logger, registro de log en texto plano con Serilog.
- Middleware para manejo global de Excepciones 
- Despliegue en Contenedores Docker
- Documentar APi con Swagger y ReDoc

### Capa de Application
- Patrón Inyección de Dependencias (OI)
- Patrón DTO
- Patrón Mediador
- Patrón CQRS 
- Patrón Decorador
- Middleware para Logging de Peticiones Http
- Almacenamiento en Cache con Lazy

### Capa de Infraestructure
- Patrón Inyección de Dependencias (OI)
- Patrón Options

### Capa de Persistence
- Patrón Inyección de Dependencias (OI)
- Patrón Repository
- Patrón Unit of Work 
- Dapper
 	
## Guía de instalación
---
Estas instrucciones te guiarán para obtener una copia de este proyecto en funcionamiento en tu máquina local para propósitos de desarrollo y pruebas.

### Pre requisitos 

Lista de software y herramientas, incluyendo versiones, que necesitas para instalar y ejecutar este proyecto:

- Sistema Operativo 10 a más
- Visual Studio 2022 - .Net 8
- SQL Server Management Studio 19
- SQL Server 16.0 - Autenticacion con Windows
- Docker Engine v24.0.7
- Git 2.43.0.windows.1
- mockapi.io:  https://65bbd87652189914b5bd34a9.mockapi.io/ 

### Instalación
Una guía paso a paso sobre cómo configurar el entorno de desarrollo e instalar todas las dependencias.

1. Clonar repositorio usando git bash.

        git clone https://github.com/RJARAG-92/Tektonlabs.Ecommerce.git

2. Abrir SQL Server Management Studio y ejecutar el archivo script_db_ecommerce.sql del repositorio clonado. Tener en consideración que el proyecto esta configurado para conectar con autenticación con Window, en caso desea cambiar se debe modificar el appsetting de la capa webApi.

3. Abrir la solución Tektonlabs.Ecommerce.sln con Visual Studio 2022, recordar que la propuesta está implementado con .Net 8.

4. Compilar la solución.

5. Iniciar depuración con IIS Express o Docker. 

6. Probar el servicio Products con swagger: http://localhost:49173/swagger/index.html. Tener en consideración el puerto, para nuestro caso usamos el puerto 49173.

## Despliegue en Contenedor
---
Una guía paso a paso para desplegar la aplicación con docker.

1. Ubicarnos en la raiz del repositorio clonado.

2. Generar imagen utilizando el siguiente comando

        docker build -f Tektonlabs.Ecommerce.WebApi/Dockerfile --force-rm -t tekton-webapi:v1 .

3. Ejecutar el contenedor utilizando el siguiente comando

        docker run -d -p 8080:8080 tekton-webapi:v1

Tener en consideración que el puerto debe estar disponible, y tenga comunicación con la base de datos. Recordar que el swagger solo esta disponibilizado para entorno de desarrollo.

## Conclusiones
---
Podemos concluir que la solución  basada en Clean Architecture, está estructurada en capas contiguas, es ideal cuando se tiene un proyecto a largo plazo, se puede testear con facilidad y sobretodo contar con alta tolerancia al cambio. 

Cabe mencionar que los puntos planteados en el reto de Tekton Labs han sido cubiertos en su totalidad. Desde implementar patrones, aplicar principios SOLID y Clean Code, hasta el desarrollo de pruebas unitarias.
