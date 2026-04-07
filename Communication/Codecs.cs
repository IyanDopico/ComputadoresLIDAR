
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Communication
{
    /// <summary>
    /// Codec Interface
    /// </summary>
    public interface ICodec<T>
    {
        byte[] Encode(T obj);   // Convierte objeto → bytes
        T Decode(byte[] message); // Convierte bytes → objeto
    }

    /// <summary>
    /// Binary Codec
    /// </summary>
    /// <typeparam name="T"> Data type</typeparam>
    public class BinaryCodec<T> : ICodec<T>
    {
        public byte[] Encode(T t)
        {
            using (var stream = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(stream, t);
                return stream.ToArray();
            }
        }

        public T Decode(byte[] message)
        {
            using (MemoryStream stream = new MemoryStream(message))
            {
                var formatter = new BinaryFormatter();
                stream.Seek(0, SeekOrigin.Begin);
                return (T)formatter.Deserialize(stream);
            }
        }
    }
    //Funciones nuevas (No venian con el codigo original)
    public class LidarMessage
    {
        public string command {  get; set; }//Manejo de comando START STOP
        public double MapData { get; set; }// Datos del mapa 
    }
}
