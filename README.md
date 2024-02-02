
![analytics image (flat)](https://raw.githubusercontent.com/vitr/google-analytics-beacon/master/static/badge-flat.gif)
![analytics](https://www.google-analytics.com/collect?v=1&cid=555&t=pageview&ec=repo&ea=open&dp=/Plantilla-de-repositorio/readme&dt=&tid=UA-4677001-16)

<h1 align="center"> Challenge Tekton Labs</h1>
<p align="center"> En este repositorio encontraras la implementación del reto plantado por Tekton Labs. El reto consiste básicamente en desarrollar una solución Api Rest en .Net Core 8 implementando los mejores patrones de diseño de software. Así mismo, el reto demanda aplicar los principios SOLID, Clean Code y TDD (Test-Driven Development), y para la documentación se debe considerar utilizar swagger.</p>
<p align="center"><img src="https://res.cloudinary.com/practicaldev/image/fetch/s--nsY4HBk_--/c_imagga_scale,f_auto,fl_progressive,h_420,q_auto,w_1000/https://thepracticaldev.s3.amazonaws.com/i/ge2kjywvjuee9nw53wme.png"/></p> 

## Tabla de contenidos:
---

- [Arquitectura de la Solución](#arquitectura-de-la-Solución)
- [Patrones de Diseño](#guía-de-usuario)
- [Tecnologias](#guía-de-instalación)
- [Guía de instalación Developer](#guía-de-instalación)
- [Despliegue](#cómo-contribuir)
- [Consejo Adicionales](#código-de-conducta)


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



### Implementación en .NET Core 8

En la siguiente figura se presenta el diseño de la solución en .NET Core 8 basado en el patrón de Clean Architecture. Así mismo, se puede observar las tecnologías utilizadas y las dependencias de cada capa. 

<p  align="center" href="https://freeimage.host/i/J0JkypS"><img style="width:90%; text-align: center;" src="https://iili.io/J0JkypS.md.png" alt="J0JkypS.md.png" border="0"></p>
 
    Esta arquitectura permite realizar cambios importantes en la aplicación, sin grandes impactos. Además, podrías cambiar el framework utilizado en caso de ser necesario, ya que está todo desacoplado, o cambiar la base de datos que uses o agregar alguna otra si la necesitas.

## Guía de usuario
---
Explica los pasos básicos sobre cómo usar la herramienta digital. Es una buena sección para mostrar capturas de pantalla o gifs que ayuden a entender la herramienta digital.
 	
## Guía de instalación
---
Paso a paso de cómo instalar la herramienta digital. En esta sección es recomendable explicar la arquitectura de carpetas y módulos que componen el sistema.

Según el tipo de herramienta digital, el nivel de complejidad puede variar. En algunas ocasiones puede ser necesario instalar componentes que tienen dependencia con la herramienta digital. Si este es el caso, añade también la siguiente sección.

La guía de instalación debe contener de manera específica:
- Los requisitos del sistema operativo para la compilación (versiones específicas de librerías, software de gestión de paquetes y dependencias, SDKs y compiladores, etc.).
- Las dependencias propias del proyecto, tanto externas como internas (orden de compilación de sub-módulos, configuración de ubicación de librerías dinámicas, etc.).
- Pasos específicos para la compilación del código fuente y ejecución de tests unitarios en caso de que el proyecto disponga de ellos.

### Dependencias
Descripción de los recursos externos que generan una dependencia para la reutilización de la herramienta digital (librerías, frameworks, acceso a bases de datos y licencias de cada recurso). Es una buena práctica describir las últimas versiones en las que ha sido probada la herramienta digital. 

    Puedes usar este estilo de letra diferenciar los comandos de instalación.

## Cómo contribuir
---
Esta sección explica a desarrolladores cuáles son las maneras habituales de enviar una solicitud de adhesión de nuevo código (“pull requests”), cómo declarar fallos en la herramienta y qué guías de estilo se deben usar al escribir más líneas de código. También puedes hacer un listado de puntos que se pueden mejorar de tu código para crear ideas de mejora.

## Código de conducta 
---
El código de conducta establece las normas sociales, reglas y responsabilidades que los individuos y organizaciones deben seguir al interactuar de alguna manera con la herramienta digital o su comunidad. Es una buena práctica para crear un ambiente de respeto e inclusión en las contribuciones al proyecto. 

La plataforma Github premia y ayuda a los repositorios dispongan de este archivo. Al crear CODE_OF_CONDUCT.md puedes empezar desde una plantilla sugerida por ellos. Puedes leer más sobre cómo crear un archivo de Código de Conducta (aquí)[https://help.github.com/articles/adding-a-code-of-conduct-to-your-project/]

## Autor/es
---
Nombra a el/los autor/es original/es. Consulta con ellos antes de publicar un email o un nombre personal. Una manera muy común es dirigirlos a sus cuentas de redes sociales.

## Información adicional
---
Esta es la sección que permite agregar más información de contexto al proyecto como alguna web de relevancia, proyectos similares o que hayan usado la misma tecnología.

## Licencia 
---

La licencia especifica los permisos y las condiciones de uso que el desarrollador otorga a otros desarrolladores que usen y/o modifiquen la herramienta digital.

Incluye en esta sección una nota con el tipo de licencia otorgado a esta herramienta digital. El texto de la licencia debe estar incluído en un archivo *LICENSE.md* o *LICENSE.txt* en la raíz del repositorio.

Si desconoces qué tipos de licencias existen y cuál es la mejor para cada caso, te recomendamos visitar la página https://choosealicense.com/.

Si la herramienta que estás publicando con la iniciativa Código para el Desarrollo ha sido financiada por el BID, te invitamos a revisar la [licencia oficial del banco para publicar software](https://github.com/EL-BID/Plantilla-de-repositorio/blob/master/LICENSE.md)

## Limitación de responsabilidades
Disclaimer: Esta sección es solo para herramientas financiadas por el BID.

El BID no será responsable, bajo circunstancia alguna, de daño ni indemnización, moral o patrimonial; directo o indirecto; accesorio o especial; o por vía de consecuencia, previsto o imprevisto, que pudiese surgir:

i. Bajo cualquier teoría de responsabilidad, ya sea por contrato, infracción de derechos de propiedad intelectual, negligencia o bajo cualquier otra teoría; y/o

ii. A raíz del uso de la Herramienta Digital, incluyendo, pero sin limitación de potenciales defectos en la Herramienta Digital, o la pérdida o inexactitud de los datos de cualquier tipo. Lo anterior incluye los gastos o daños asociados a fallas de comunicación y/o fallas de funcionamiento de computadoras, vinculados con la utilización de la Herramienta Digital.