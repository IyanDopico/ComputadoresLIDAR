# Simulador de Sistema LIDAR - Rover de Exploración Planetaria

## 1. Descripción del Proyecto
Este proyecto consiste en el diseño e implementación de un sistema distribuido que simula el procesamiento y distribución de datos LIDAR en un rover de exploración. El sistema utiliza una arquitectura basada en el paradigma publicador-subscriptor, similar al modelo de ROS2, para generar mapas de distancias en un servidor y distribuirlos a múltiples nodos cliente.

## 2. Arquitectura del Sistema
El sistema se compone de una arquitectura cliente-servidor con comportamiento concurrente:

* **Nodo Servidor:** Simula la adquisición de datos y los publica de manera periódica.
* **Nodos Cliente:** Aplicaciones con interfaz gráfica (WPF) que se suscriben al flujo de datos y representan los mapas en tiempo real.

## 3. Especificaciones del Servidor
El servidor actúa como el sistema de percepción del rover.
* **Datos:** Lee un fichero CSV donde cada línea representa una matriz de 32x32 (1024 valores) en formato lineal.
* **Tareas Simultáneas:**
    * Un hilo para generar datos de forma circular (vuelve al principio al terminar el fichero).
    * Un hilo para gestionar comandos de red: Start (iniciar/reanudar) y Stop (parar).
    * Un socket de escucha para recibir clientes, generando un nuevo hilo para el envío de datos a cada uno.
* **Parámetros:** Recibe por parámetros el puerto de escucha y el nombre del fichero de datos.

## 4. Especificaciones del Cliente (GUI)
Desarrollado en WPF, debe cumplir con las siguientes funciones:
* **Conectividad:** Especificar IP y puerto del servidor, con indicadores de éxito en la conexión.
* **Control:** Enviar comandos Start y Stop al servidor.
* **Visualización:** Mostrar el mapa procesado en un Canvas, permitiendo cambiar la paleta de colores térmica.
* **Persistencia:** Guardar el estado del Canvas en un fichero de imagen con formato YYMMDDHHSS.

## 5. Biblioteca de Comunicaciones e ImageProcessor
Se utiliza una biblioteca compartida para la comunicación basada en clases serializables que contienen comandos y datos de la matriz.

Para el tratamiento visual, se emplea el ensamblado `ImageProcessor` (clase `ImageStorage`):
* **SetNewMap(double[] flatMap):** Procesa el array de 1024 valores.
* **CurrentBWImage:** Propiedad para imagen en escala de grises.
* **CurrentColorImage:** Propiedad para imagen en paleta térmica continua (azul-rojo).
* **CurrentColorDiffImage:** Propiedad para imagen en paleta científica Viridis.

## 6. Requisitos de Desarrollo
* **Tecnología:** .NET Framework.
* **Documentación:** Comentarios en estilo XML (///) en todos los miembros y clases.
* **Patrón de diseño:** Política básica MVC (separación de lógica y presentación).
* **Concurrencia:** Se recomienda el uso de la clase abstracta `Worker` para la gestión de hilos.
