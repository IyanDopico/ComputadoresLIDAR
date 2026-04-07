using System;
using System.Text;
using System.Collections.Concurrent;
using System.Net.Sockets;
using System.IO;
using Communication;

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
                    double[] mapToSend=null;
                    lock (SharedData.Maplock) 
                    {
                        if (SharedData.CurrentMap != null)
                        {
                            mapToSend = (double[])
                        }
                    }
                }
            }
        }

    }

}
