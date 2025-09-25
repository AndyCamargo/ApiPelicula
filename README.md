# API Películas

Una API REST desarrollada con .NET Core para la gestión de películas, categorías y usuarios con sistema de autenticación y autorización.

## 📋 Características

- **Gestión de Películas**: CRUD completo con soporte para imágenes
- **Gestión de Categorías**: Organización de películas por categorías
- **Sistema de Usuarios**: Registro, login y roles (admin/usuario)
- **Autenticación JWT**: Seguridad basada en tokens
- **Paginación**: Consultas optimizadas con paginación
- **Subida de Archivos**: Manejo de imágenes de películas
- **Documentación Swagger**: API documentada y testeable
- **Entity Framework**: Acceso a datos con Code First
- **AutoMapper**: Mapeo automático entre entidades y DTOs

## 🚀 Tecnologías Utilizadas

- **.NET Core 9**
- **Entity Framework Core**
- **ASP.NET Core Identity**
- **JWT (JSON Web Tokens)**
- **AutoMapper**
- **SQL Server** (base de datos)
- **Swagger/OpenAPI**

## 📁 Estructura del Proyecto

```
ApiPeliculas/
├── Controllers/
│   ├── CategoriasController.cs
│   ├── PeliculasController.cs
│   └── UsuariosController.cs
├── Data/
│   └── ApplicationDBContext.cs
├── Modelos/
│   ├── Dtos/
│   ├── Categoria.cs
│   ├── Pelicula.cs
│   ├── Usuario.cs
│   └── AppUsuario.cs
├── Repositorios/
├── PeliculasMappers/
└── wwwroot/ImagenesPeliculas/
```

## ⚙️ Configuración e Instalación

### Prerrequisitos

- .NET Core SDK 9.0 o superior
- SQL Server (Local o Azure)
- Visual Studio 2022 o VS Code

### Instalación

1. **Clonar el repositorio**
```bash
git clone https://github.com/tu-usuario/ApiPeliculas.git
cd ApiPeliculas
```

2. **Restaurar dependencias**
```bash
dotnet restore
```

3. **Configurar la cadena de conexión**
   
   Edita `appsettings.json` con tu cadena de conexión a SQL Server:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=ApiPeliculasDB;Trusted_Connection=true;"
  }
}
```

4. **Ejecutar migraciones**
```bash
dotnet ef database update
```

5. **Ejecutar la aplicación**
```bash
dotnet run
```

La API estará disponible en `https://localhost:7xxx` y `http://localhost:5xxx`

## 📚 Endpoints de la API

### 🎬 Películas

| Método | Endpoint | Descripción | Autenticación |
|--------|----------|-------------|---------------|
| `GET` | `/api/peliculas` | Obtener todas las películas (paginado) | Pública |
| `GET` | `/api/peliculas/{id}` | Obtener película por ID | Pública |
| `GET` | `/api/peliculas/GetPeliculasEnCategoria/{categoriaId}` | Películas por categoría | Pública |
| `GET` | `/api/peliculas/Buscar?nombre={nombre}` | Buscar películas por nombre | Pública |
| `POST` | `/api/peliculas` | Crear nueva película | Admin |
| `PATCH` | `/api/peliculas/{id}` | Actualizar película | Admin |
| `DELETE` | `/api/peliculas/{id}` | Eliminar película | Admin |

### 📂 Categorías

| Método | Endpoint | Descripción | Autenticación |
|--------|----------|-------------|---------------|
| `GET` | `/api/categorias` | Obtener todas las categorías | Pública |
| `GET` | `/api/categorias/{id}` | Obtener categoría por ID | Pública |
| `POST` | `/api/categorias` | Crear nueva categoría | Admin |
| `PATCH` | `/api/categorias/{id}` | Actualizar categoría (PATCH) | Admin |
| `PUT` | `/api/categorias/{id}` | Actualizar categoría (PUT) | Admin |
| `DELETE` | `/api/categorias/{id}` | Eliminar categoría | Admin |

### 👥 Usuarios

| Método | Endpoint | Descripción | Autenticación |
|--------|----------|-------------|---------------|
| `GET` | `/api/usuarios` | Obtener todos los usuarios | Requerida |
| `GET` | `/api/usuarios/{id}` | Obtener usuario por ID | Requerida |
| `POST` | `/api/usuarios/registro` | Registrar nuevo usuario | Pública |
| `POST` | `/api/usuarios/login` | Iniciar sesión | Pública |

## 🔐 Autenticación

La API utiliza JWT (JSON Web Tokens) para la autenticación. Para acceder a endpoints protegidos:

1. **Registrarse o iniciar sesión** para obtener el token
2. **Incluir el token** en el header Authorization:
```
Authorization: Bearer {tu-token-jwt}
```

### Roles de Usuario
- **Admin**: Acceso completo (CRUD en películas y categorías)
- **Usuario**: Solo consultas (GET)

## 📝 Ejemplos de Uso

### Crear una Película
```json
POST /api/peliculas
Content-Type: multipart/form-data

{
  "nombre": "Avatar",
  "descripcion": "Película de ciencia ficción",
  "duracion": 162,
  "clasificacion": 1,
  "categoriaId": 1,
  "imagen": [archivo-imagen]
}
```

### Obtener Películas con Paginación
```
GET /api/peliculas?pageNumber=1&pageSize=10
```

### Buscar Películas
```
GET /api/peliculas/Buscar?nombre=avatar
```

## 🗃️ Modelo de Datos

### Pelicula
- `Id`: Identificador único
- `Nombre`: Nombre de la película
- `Descripcion`: Descripción de la película
- `Duracion`: Duración en minutos
- `RutaImagen`: URL de la imagen
- `Clasificacion`: Enum (Siete, Trece, Dieciseis, Dieciocho)
- `FechaCreacion`: Fecha de creación
- `CategoriaId`: FK a Categoría

### Categoria
- `Id`: Identificador único
- `Nombre`: Nombre de la categoría
- `FechaCreacion`: Fecha de creación

### Usuario
- Hereda de `IdentityUser`
- `Nombre`: Nombre del usuario
- `Apellido`: Apellido del usuario

## 🔧 Características Técnicas

### Paginación
Las consultas de películas soportan paginación:
```json
{
  "pageNumber": 1,
  "pageSize": 10,
  "totalPages": 5,
  "totalItems": 50,
  "items": [...]
}
```

### Subida de Imágenes
Las imágenes se almacenan en `wwwroot/ImagenesPeliculas/` y se genera una URL pública automáticamente.

### Cache
Algunos endpoints utilizan ResponseCache para mejorar el rendimiento:
```csharp
[ResponseCache(Duration = 30)] // 30 segundos
```

### CORS
La API tiene configuración CORS para permitir peticiones desde diferentes dominios.

## 🐛 Manejo de Errores

La API retorna códigos de estado HTTP estándar:

- `200 OK`: Operación exitosa
- `201 Created`: Recurso creado
- `400 Bad Request`: Datos inválidos
- `401 Unauthorized`: No autenticado
- `403 Forbidden`: Sin permisos
- `404 Not Found`: Recurso no encontrado
- `500 Internal Server Error`: Error del servidor

## 🧪 Testing

Para probar la API puedes usar:

1. **Swagger UI**: Disponible en `/swagger` cuando ejecutes la aplicación
2. **Postman**: Importa la colección de endpoints
3. **curl**: Para pruebas desde línea de comandos

## 📖 Documentación

La API incluye documentación automática con Swagger/OpenAPI. Una vez que ejecutes la aplicación, visita:
```
https://localhost:7xxx/swagger
```

## 🤝 Contribuir

1. Fork el proyecto
2. Crea una rama para tu feature (`git checkout -b feature/AmazingFeature`)
3. Commit tus cambios (`git commit -m 'Add some AmazingFeature'`)
4. Push a la rama (`git push origin feature/AmazingFeature`)
5. Abre un Pull Request

## 📄 Licencia

Este proyecto está bajo la Licencia MIT. Ve el archivo `LICENSE` para más detalles.

## 👨‍💻 Autor

**AndyCamargo** - [GitHub](https://github.com/tu-usuario)

## 🙏 Agradecimientos

- ASP.NET Core Team por el excelente framework
- Entity Framework por la facilidad de acceso a datos
- AutoMapper por simplificar el mapeo de objetos
