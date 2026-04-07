
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Communication
{
    /// <summary>
    /// Codec Interface
    /// </summary>
    /// <typeparam name="T">T parameter</typeparam>
    public interface ICodec<T>
    {
        /// <summary>
        /// Codec in a byte sequence
        /// </summary>
        /// <param name="obj">Object that needs to be codec</param>
        /// <returns>Returns a byte sequence defining the object</returns>
        byte[] Encode(T obj);
        /// <summary>
        /// Decodecs a byte sequence into an  object.
        /// </summary>
        /// <param name="message">Byte sequence to decode</param>
        /// <returns>Returns an object defining the given sequence</returns>
        T Decode(byte[] message);
    }

    /// <summary>
    /// Binary Codec
    /// </summary>
    /// <typeparam name="T"> Data type</typeparam>
    public class BinaryCodec<T> : ICodec<T>
    {
        /// <summary>
        /// Codec in a byte sequence
        /// </summary>
        /// <param name="obj">Object that needs to be codec</param>
        /// <returns>Returns a byte sequence defining the object</returns>
        public byte[] Encode(T t)
        {
            using (var stream = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(stream, t);
                return stream.ToArray();
            }
        }

        /// <summary>
        /// Decodecs a byte sequence into an  object.
        /// </summary>
        /// <param name="message">Byte sequence to decode</param>
        /// <returns>Returns an object defining the given sequence</returns>
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
}
