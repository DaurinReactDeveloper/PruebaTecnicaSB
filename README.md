<div align="center">

# ⚙️ Sistema de Gestión de Empleados

### Backend API

API REST desarrollada con **ASP.NET Core 8**, **Entity Framework Core** y **SQL Server** para la administración de empleados, usuarios, roles y cálculo de nómina.

La solución fue diseñada siguiendo principios de **Clean Architecture**, **SOLID**, separación de responsabilidades y buenas prácticas de desarrollo empresarial.

<br>

<img src="https://img.shields.io/badge/.NET-8-512BD4?logo=.net&logoColor=white" />
<img src="https://img.shields.io/badge/C%23-12-239120?logo=c-sharp&logoColor=white" />
<img src="https://img.shields.io/badge/SQL%20Server-Database-CC2927?logo=microsoftsqlserver&logoColor=white" />
<img src="https://img.shields.io/badge/Entity%20Framework-Core-blue" />
<img src="https://img.shields.io/badge/JWT-Security-success" />
<img src="https://img.shields.io/badge/Clean-Architecture-orange" />

</div>

---

# 📖 Descripción General

El backend expone una API REST encargada de:

* Gestión de empleados.
* Gestión de usuarios.
* Gestión de roles.
* Gestión de estados de empleados.
* Cálculo de nómina.
* Autenticación y autorización mediante JWT.
* Generación de reportes de pagos.
* Registro de eventos y errores mediante logging.

La aplicación fue desarrollada para soportar escenarios empresariales con una arquitectura escalable y mantenible.

---

# 🚀 Funcionalidades

## 👥 Gestión de Empleados

* Crear empleados.
* Actualizar empleados.
* Consultar empleados.
* Obtener empleados por ID.
* Filtrar por nombre.
* Filtrar por departamento.
* Filtrar por estado.
* Eliminación lógica de registros.

---

## 👤 Gestión de Usuarios

* Crear usuarios.
* Actualizar usuarios.
* Eliminar usuarios.
* Asignación de roles.

---

## 🏷️ Gestión de Roles

* Administración de roles.
* Asignación de permisos.
* Control de acceso basado en roles.

---

## 💰 Gestión de Nómina

Soporte para:

### Empleado Asalariado

```text
Pago Semanal = Salario Semanal
```

### Empleado por Horas

```text
Si Horas <= 40

Pago = Horas × Tarifa

Si Horas > 40

Pago = (40 × Tarifa)
     + (Horas Extras × Tarifa × 1.5)
```

### Empleado por Comisión

```text
Pago = Ventas Brutas × Tarifa Comisión
```

### Empleado Asalariado por Comisión

```text
Pago =
(Ventas Brutas × Tarifa Comisión)
+ Salario Base
+ (Salario Base × 10%)
```

---

# 🔐 Seguridad

La aplicación implementa autenticación y autorización mediante JWT.

Características:

* Login seguro.
* Tokens JWT.
* Validación de expiración.
* Autorización por roles.
* Endpoints protegidos.
* Control de acceso basado en permisos.

---

# 🛠️ Tecnologías Utilizadas

| Tecnología                | Descripción               |
| ------------------------- | ------------------------- |
| .NET 8                    | Framework principal       |
| ASP.NET Core Web API      | API REST                  |
| C#                        | Lenguaje de programación  |
| Entity Framework Core     | ORM                       |
| SQL Server                | Base de datos             |
| JWT Bearer Authentication | Seguridad                 |
| Dependency Injection      | Inyección de dependencias |
| Swagger/OpenAPI           | Documentación API         |
| Logging                   | Registro de eventos       |

---

# 🏛️ Arquitectura

La solución sigue principios de Clean Architecture.

```text
src/
│
├── GestorEmpleados.Api
│
├── GestorEmpleados.Application
│
├── GestorEmpleados.Domain
│
├── GestorEmpleados.Infrastructure
│
├── GestorEmpleados.Persistence
│
└── GestorEmpleados.Loc
```
---

# 🏗️ Principios Aplicados

* Clean Architecture.
* SOLID.
* Dependency Injection.
* Repository Pattern.
* Service Pattern.
* Separation of Concerns.
* DTO Pattern.
* Logging Centralizado.
* Validaciones de negocio.

---

# ⚙️ Requisitos Previos

Instalar:

* .NET SDK 8
* SQL Server
* SQL Server Management Studio (Opcional)

Verificar instalación:

```bash
dotnet --version
```

---

# 🗄️ Configuración de Base de Datos

La solución incluye un script SQL para la creación completa de la base de datos.

## Paso 1

Abrir SQL Server Management Studio.

## Paso 2

Ubicar el archivo:

```text
Database/
└── EmployeeManagementDB.sql
```

## Paso 3

Ejecutar el script completo.

El script crea automáticamente:

* Base de datos.
* Tablas.
* Relaciones.
* Catálogos iniciales.
* Roles base.
* Usuarios iniciales.

---

# 🚀 Configuración del Proyecto

## Paso 1 - Clonar repositorio

```bash
git clone <repository-url>
```

---

## Paso 2 - Abrir solución

```bash
GestorEmpleados.sln
```

---

## Paso 3 - Configurar Connection String

Editar:

```text
appsettings.json
```

Ejemplo:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=.;Database=EmployeeManagementDB;Trusted_Connection=True;TrustServerCertificate=True"
  }
}
```

---

## Paso 4 - Configurar JWT y URL del Frontend

Editar el archivo:

```text
appsettings.json
```

Configurar los valores de JWT, la cadena de conexión y la URL del frontend autorizado.

Ejemplo:

```json
{
  "Jwt": {
    "Key": "YourSecretKeyHere",
    "Issuer": "https://localhost:7001",
    "Audience": "http://localhost:5173",
    "Subject": "baseWebApiSubject"
  },

  "ConnectionStrings": {
    "EmployeeManagementDBContext": "Server=.;Database=EmployeeManagementDB;Trusted_Connection=True;TrustServerCertificate=True;"
  },

  "FrontendUrl": "http://localhost:5173"
}
```

### Descripción de los campos

| Campo                                           | Descripción                                       |
| ----------------------------------------------- | ------------------------------------------------- |
| `Jwt:Key`                                       | Clave utilizada para la firma del token JWT.      |
| `Jwt:Issuer`                                    | URL de la API que emite los tokens.               |
| `Jwt:Audience`                                  | URL del frontend autorizado para consumir la API. |
| `FrontendUrl`                                   | URL utilizada para la configuración de CORS.      |
| `ConnectionStrings:EmployeeManagementDBContext` | Cadena de conexión de SQL Server.                 |

### Entorno Local

```json
{
  "Jwt": {
    "Issuer": "https://localhost:7001",
    "Audience": "http://localhost:5173"
  },
  "FrontendUrl": "http://localhost:5173"
}
```

### Entorno Productivo

```json
{
  "Jwt": {
    "Issuer": "https://api.midominio.com",
    "Audience": "https://midominio.com"
  },
  "FrontendUrl": "https://midominio.com"
}
```

> Importante: El valor de `Audience` y `FrontendUrl` debe coincidir con la URL donde se encuentre desplegada la aplicación React para que la autenticación JWT y las políticas CORS funcionen correctamente.

---

## Paso 5 - Restaurar paquetes

```bash
dotnet restore
```

---

## Paso 6 - Compilar solución

```bash
dotnet build
```

---

## Paso 7 - Ejecutar API

```bash
dotnet run
```

o

```bash
dotnet watch run
```

---

# 📄 Swagger

Una vez iniciada la API:

```text
https://localhost:xxxx/swagger
```

Desde Swagger es posible:

* Consultar endpoints.
* Probar autenticación.
* Ejecutar operaciones CRUD.
* Validar respuestas.

---

# ⚡ Rendimiento

La solución fue diseñada para:

* Procesar grandes volúmenes de empleados.
* Optimizar consultas mediante Entity Framework Core.
* Reducir acoplamiento entre módulos.
* Facilitar la incorporación de nuevos tipos de empleados sin modificar código existente.

---

# 🔗 Integración Frontend

La API es consumida por una aplicación React + TypeScript mediante:

* Axios.
* JWT Authentication.
* Endpoints RESTful.
* DTOs desacoplados.

---

# 👨‍💻 Autor

Desarrollado como solución para la prueba técnica Full Stack orientada a la gestión de empleados, usuarios y nómina, aplicando principios de arquitectura limpia, seguridad y escalabilidad.

---

# 📄 Licencia

Uso académico y demostrativo.

</div>