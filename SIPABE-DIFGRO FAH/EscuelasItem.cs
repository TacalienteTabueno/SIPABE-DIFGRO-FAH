using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIPABE_DIFGRO_FAH
{
    public class EscuelasItem
    {
        public string CCT { get; set; }
        public string TIPO_CT { get; set; }
        public string NOMBRE_ESCUELA { get; set; }
        public string TURNO { get; set; }
        public string STA_DES { get; set; }
        public string CLAVE_MUNICIPIO { get; set; }
        public string NOMBRE_MUNICIPIO { get; set; }
        public string CLAVE_LOCALIDAD { get; set; }
        public string NOMBRE_LOCALIDAD { get; set; }
        public string TIPO { get; set; }
        public string NIVEL { get; set; }
        public string SUBNIVEL { get; set; }

        public string TextoMostrar
        {
            get
            {
                // Si es el ítem "Seleccione", solo muestra eso
                if (string.IsNullOrEmpty(CCT) && string.IsNullOrEmpty(NOMBRE_ESCUELA))
                    return "-- Seleccione --";

                return $"{CCT} | {NOMBRE_ESCUELA} | Turno: {TURNO} | {NIVEL} - {SUBNIVEL} | {TIPO} | {STA_DES} | {NOMBRE_MUNICIPIO}, {NOMBRE_LOCALIDAD}";
            }
        }
    }
}
