using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using Communication;
using System.IO;

namespace Client
{
    /// <summary>
    /// Class to control one connection
    /// </summary>
    public class ConnectionWorker:Worker
    {
        /// <summary>
        /// Service Socket
        /// </summary>
        private Socket SS;

        public ConnectionWorker()
        {

        }
    }
}
