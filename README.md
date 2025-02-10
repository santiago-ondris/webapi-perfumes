# WEB API PERFUME - Backend

## Descripción

Este proyecto es la API REST para la gestión de perfumes. La API permite consultar, crear, actualizar y eliminar perfumes, así como generar reportes en formato CSV. Se implementa siguiendo los siguientes patrones y tecnologías:

- **Arquitectura en Capas:** Separa la lógica en las siguientes capas: **Infrastructure, Persistence, Domain, Application y WebApi**.
- **CQRS:** Separa la lógica de comandos y consultas.
- **Middleware Personalizado:** Manejo centralizado de excepciones.
- **Subida de Imágenes con Cloudinary:** Para gestionar imágenes.
- **Swagger:** Para la documentación interactiva de la API.
- **JWT Authentication:** Seguridad basada en tokens.
- **Despliegue en Azure App Service:** Para poder comunicar la API con un FrontEnd.

## Tecnologías y Herramientas

- **.NET 9 SDK**
- **ASP.NET Core Web API**
- **Entity Framework Core**
- **CQRS y MediatR**
- **FluentValidation**
- **JWT Authentication**
- **Cloudinary SDK**
- **Swagger**
- **Azure App Service**

## Estructura del Proyecto

El proyecto está organizado en las siguientes capas:

- **Domain:** Entidades de la aplicación.
- **Persistence:** Contexto de datos y configuración de Entity Framework.
- **Infrastructure:** Configuracion de reporte, seguridad y servicio de fotos.
- **Application:** Lógica de aplicación, comandos, queries, validadores y mapeos (AutoMapper).
- **WebApi:** Controladores, middleware y configuración de la API.

## Requisitos

- [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- Base de datos SQlite
- Configuración de Cloudinary (agrega tus credenciales en el archivo `appsettings.json`)
- Una llave secreta para JWT en el `appsettings.json` (por ejemplo, `TokenKey`)

## Instalación y Ejecución

1. **Clonar el repositorio:**

   ```bash
   git clone https://github.com/santiago-ondris/webapi-perfumes.git
