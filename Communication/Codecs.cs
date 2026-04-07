using System;                                      // Tipos básicos (Serializable, etc.)
using System.IO;                                   // MemoryStream
using System.Runtime.Serialization.Formatters.Binary; // BinaryFormatter

namespace Communication
{
    /// <summary>
    /// Interfaz genérica para codificar/decodificar objetos
    /// </summary>
    public interface ICodec<T>
    {
        byte[] Encode(T obj);   // Convierte objeto → bytes
        T Decode(byte[] message); // Convierte bytes → objeto
    }

    /// <summary>
    /// Implementación usando serialización binaria
    /// </summary>
    public class BinaryCodec<T> : ICodec<T>
    {
        public byte[] Encode(T t)
        {
            // Stream en memoria donde se construyen los bytes
            using (var stream = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                // BinaryFormatter convierte el objeto completo en binario

                formatter.Serialize(stream, t);
                // Serializa el objeto 't' dentro del stream

                return stream.ToArray();
                // Devuelve el contenido del stream como array de bytes
            }
        }

        public T Decode(byte[] message)
        {
            // Se crea un stream a partir del array recibido
            using (var stream = new MemoryStream(message))
            {
                var formatter = new BinaryFormatter();

                stream.Seek(0, SeekOrigin.Begin);
                // Asegura que la lectura empieza desde el byte 0

                return (T)formatter.Deserialize(stream);
                // Reconstruye el objeto original desde los bytes
            }
        }
    }

    /// <summary>
    /// Enum para evitar errores con strings tipo "START"/"STOP"
    /// </summary>
    [Serializable] // Necesario para poder serializarlo
    public enum LidarCommand
    {
        None,   // Mensaje sin comando (solo datos)
        Start,  // Iniciar simulación/envío
        Stop    // Parar simulación/envío
    }

    /// <summary>
    /// Mensaje que viaja entre cliente y servidor
    /// </summary>
    [Serializable] // OBLIGATORIO para BinaryFormatter
    public class LidarMessage
    {
        public LidarCommand Command { get; set; } 
        // Campo de control:
        // - Start → arrancar simulación
        // - Stop → detener
        // - None → mensaje de datos

        public double[] MapData { get; set; }
        // Datos del mapa LIDAR:
        // - Array lineal de 1024 doubles (32x32)
        // - null cuando el mensaje es solo de control
    }
}