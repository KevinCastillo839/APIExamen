# APIExamen# Gestión de Cursos y Estudiantes

## Descripción
Este proyecto es una API REST desarrollada en .NET para gestionar cursos y estudiantes. Cada estudiante puede estar inscrito en un único curso.

## Tecnologías
- .NET 8
- Entity Framework Core
- SQL Server
- Firebase Admin SDK (para notificaciones push)

## Requisitos
- Visual Studio 2022 o superior
- .NET SDK 8.0 o superior
- SQL Server o SQL Server Express

## Configuración del proyecto

1. **Clonar el repositorio**:
   ```bash
   git clone https://github.com/KevinCastillo839/APIExamen.git
   ```

2. **Actualizar cadena de conexión**:
   - Abrir `appsettings.json`.
   - Cambiar el valor de `DefaultConnection` colocando tu **usuario**, **contraseña**.

3. **Aplicar migraciones a la base de datos**:
   Desde la terminal:
   ```
   dotnet restore
   dotnet build
   dotnet ef database update
   ```

4. **Compilar y ejecutar**:
   Nos situamos en la carpeta apiexamen usando el comando cd
   - Compilar el proyecto:
     ```terminal de Visual Studio
     dotnet build
     ```
   - Iniciar el servidor API:
     ```terminal de Visual Studio
     dotnet watch run
     ```




## Rama Principal
- `main`
