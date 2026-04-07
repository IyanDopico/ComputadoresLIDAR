using System;
using System.Text;
using System.Collections.Concurrent;
using System.Net.Sockets;
using System.IO;
using Communication;
using System.Threading;

namespace Server
{
    /// <summary>
    /// Wrapper del hilo trabajador que atenderá peticiones
    /// </summary>
    public class RequestWorker : Worker
    {
        private Socket _socket;
        private BinaryCodec<LidarMessage> _messageCodec;

        public RequestWorker(Socket ServiceSocket)
        {
            _socket = ServiceSocket;
            _messageCodec = new BinaryCodec<LidarMessage>();
        }
        protected override void doWork()
        {
            try
            {
                while (!_endSignal)
                {
                    double[] mapToSend = null;
                    lock (SharedData.Maplock)
                    {
                        if (SharedData.CurrentMap != null)
                        {
                            mapToSend = (double[])SharedData.CurrentMap.Clone();
                        }
                    }
                    if (mapToSend != null) 
                    {
                        LidarMessage message = new LidarMessage
                        {
                            Command = LidarCommand.None,
                            MapData = mapToSend
                        };
                        SendMessage(message);
                    }
                    Thread.Sleep(1000);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }finally {
                try
                {
                    _socket.Close();
                }
                catch (Exception)
                {
                    Console.WriteLine("Fallo cierre");

                }
                
            }
        }

    }

}
