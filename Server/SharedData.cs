using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{

    public static class SharedData
    {
        public static double[] CurrentMap = null;
        public static bool Running = false;
        public static readonly object Maplock = new object();
    }

}
