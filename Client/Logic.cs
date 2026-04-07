using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Drawing.Imaging;
using System.Drawing;
using ImageProcessor;

namespace Client
{
    /// <summary>
    /// Clase de lógica de aplicación. Debe contener las tareas que no competen a la interfaz
    /// </summary>
    public class Logic
    {
        ImageStorage _storage;

        public Logic()
        {
            _storage = new ImageStorage();
        }
    }
}
