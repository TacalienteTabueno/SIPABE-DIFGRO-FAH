using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIPABE_DIFGRO_FAH
{
    public class EstadoCivilItem
    {
        public string Clave { get; set; }
        public string Descripcion { get; set; }

        public override string ToString()
        {
            return Descripcion; // Esto muestra la descripción en el ComboBox
        }
    }
}
