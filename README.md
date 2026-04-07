# Simulador de Sistema LIDAR - Rover de Exploración Planetaria

## 1. Descripción del Proyecto
[cite_start]Este proyecto consiste en el diseño e implementación de un sistema distribuido que simula el procesamiento y distribución de datos LIDAR en un rover de exploración[cite: 5]. [cite_start]El sistema utiliza una arquitectura basada en el paradigma publicador-subscriptor, similar al modelo de ROS2, para generar mapas de distancias en un servidor y distribuirlos a múltiples nodos cliente[cite: 6, 17].

## 2. Arquitectura del Sistema
[cite_start]El sistema se compone de una arquitectura cliente-servidor con comportamiento concurrente[cite: 19]:

* [cite_start]**Nodo Servidor:** Simula la adquisición de datos y los publica de manera periódica[cite: 24].
* [cite_start]**Nodos Cliente:** Aplicaciones con interfaz gráfica (WPF) que se suscriben al flujo de datos y representan los mapas en tiempo real[cite: 25, 68].

## 3. Especificaciones del Servidor
[cite_start]El servidor actúa como el sistema de percepción del rover[cite: 38].
* [cite_start]**Datos:** Lee un fichero CSV donde cada línea representa una matriz de 32x32 (1024 valores) en formato lineal[cite: 41, 42, 46].
* **Tareas Simultáneas:**
    * [cite_start]Un hilo para generar datos de forma circular (vuelve al principio al terminar el fichero)[cite: 56, 57].
    * [cite_start]Un hilo para gestionar comandos de red: Start (iniciar/reanudar) y Stop (parar)[cite: 58, 59, 60].
    * [cite_start]Un socket de escucha para recibir clientes, generando un nuevo hilo para el envío de datos a cada uno[cite: 61, 62].
* [cite_start]**Parámetros:** Recibe por parámetros el puerto de escucha y el nombre del fichero de datos[cite: 65].

## 4. Especificaciones del Cliente (GUI)
[cite_start]Desarrollado en WPF, debe cumplir con las siguientes funciones[cite: 68, 69]:
* [cite_start]**Conectividad:** Especificar IP y puerto del servidor, con indicadores de éxito en la conexión[cite: 70, 71].
* [cite_start]**Control:** Enviar comandos Start y Stop al servidor[cite: 73].
* [cite_start]**Visualización:** Mostrar el mapa procesado en un Canvas, permitiendo cambiar la paleta de colores térmica[cite: 74, 75].
* [cite_start]**Persistencia:** Guardar el estado del Canvas en un fichero de imagen con formato YYMMDDHHSS[cite: 76].

## 5. Biblioteca de Comunicaciones e ImageProcessor
[cite_start]Se utiliza una biblioteca compartida para la comunicación basada en clases serializables que contienen comandos y datos de la matriz[cite: 88, 89, 90].

[cite_start]Para el tratamiento visual, se emplea el ensamblado `ImageProcessor` (clase `ImageStorage`)[cite: 94, 95]:
* [cite_start]**SetNewMap(double[] flatMap):** Procesa el array de 1024 valores[cite: 101, 102].
* [cite_start]**CurrentBWImage:** Propiedad para imagen en escala de grises[cite: 108, 109].
* [cite_start]**CurrentColorImage:** Propiedad para imagen en paleta térmica continua (azul-rojo)[cite: 111, 113, 119].
* [cite_start]**CurrentColorDiffImage:** Propiedad para imagen en paleta científica Viridis[cite: 120, 122, 123].

## 6. Requisitos de Desarrollo
* [cite_start]**Tecnología:** .NET Framework[cite: 27].
* [cite_start]**Documentación:** Comentarios en estilo XML (///) en todos los miembros y clases[cite: 125, 126].
* [cite_start]**Patrón de diseño:** Política básica MVC (separación de lógica y presentación)[cite: 127, 128].
* [cite_start]**Concurrencia:** Se recomienda el uso de la clase abstracta `Worker` para la gestión de hilos[cite: 131].
