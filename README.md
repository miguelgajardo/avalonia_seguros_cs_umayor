# Gestor de Productos - Consola

![C#](https://img.shields.io/badge/C%23-239120?logo=c-sharp&logoColor=white)
![.NET](https://img.shields.io/badge/.NET-512BD4?logo=dotnet&logoColor=white)

Aplicación GUI en Avalonia para asignar Pólizas de Seguro en C# con .NET.

## Características Principales

✅ **Funcionalidad**  
- Crear, Listar Cliente y Asignar Póliza
- Persistencia en memoria mediante `ArrayList` DatosSistema

📋 **Estructura de Cliente**  
- RUT  
- Nombre  
- Apellido  
- Teléfono  
- Pólizas  

🔄 **Operaciones Avanzadas**  
- Simulación de asignación de Pólizas calculadas en UF

## Estructura del Proyecto

MyAvaloniaApp/
├── Models         # Modelo
└── Services       # Servicios UF y Dialogs
└── ViewModels     # Lógica
└── Views          # Vistas axaml y cs

##  Requisitos

.NET 9 SDK

Terminal/Consola

## Cómo Ejecutar

Clonar repositorio

Navegar al directorio del proyecto

Ejecutar: dotnet run | si es necesario dotnet clean previo

## Menú Principal

1. Agregar Cliente
2. Listar Clientes
3. Asignar Póliza

## Ejemplo de Uso

> Clientes > Agregar Cliente:
RUT: 9.876.543-2
Nombre: Paulino
Apellido: Solis
Telefono: +56987654321

> Clientes > Listar Clientes:
9.876.543-2 | Paulino | Solis | +56987654321

>Pólizas > Simular Adquisición :
Seleccionar Cliente | Automotriz | 2 (años) | 3.4 (Prima en UF)

## Notas Técnicas

🔹 Implementado con ArrayList para almacenamiento
🔹 Validación básica de entradas
🔹 Formato valores en UF

## Mejoras Futuras

◻ Inclusión de Interfaces para el CRUD Completo de Cliente

⌨️ Desarrollado como ejercicio para la asignatura de C# Tec Mayor.