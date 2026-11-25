using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIPABE_DIFGRO_FAH
{
    public class BeneficiarioItem
    {
        public int id_beneficiario { get; set; }
        public string id_curp_beneficiario { get; set; }
        public string QR_CURP { get; set; }
        public string NADA { get; set; }
        public string nombre_beneficiario { get; set; }
        public string primer_apellido_beneficiario { get; set; }
        public string segundo_apellido_beneficiario { get; set; }
        public decimal? fecha_nacimiento_invert { get; set; }
        public DateTime? fecha_nacimiento { get; set; }
        public string nom_ent_fed_nac { get; set; }
        public string cve_ent_fed_reg { get; set; }
        public string sexo { get; set; }
        public string discapacidad { get; set; }
        public string indigena { get; set; }
        public string cve_civil { get; set; }
        public string afrodescendiente { get; set; }
        public string migrante { get; set; }
        public string vulnerabilidad { get; set; }
        public string tipo_discapacidad { get; set; }
        public string tipo_vialidad { get; set; }
        public string nom_vialidad { get; set; }
        public string carretera { get; set; }
        public string camino { get; set; }
        public int num_ext_1 { get; set; }
        public int num_ext_2 { get; set; }
        public string num_ext_alf_1 { get; set; }
        public int num_int_num { get; set; }
        public string num_int_alf { get; set; }
        public string tipo_asen { get; set; }
        public string nom_asen { get; set; }
        public int cp { get; set; }
        public string nom_loc { get; set; }
        public string cve_loc { get; set; }
        public string cve_loc_id { get; set; }
        public string nom_mun { get; set; }
        public string region { get; set; }
        public string cve_mun { get; set; }
        public string nom_ent { get; set; }
        public string cve_ent { get; set; }
        public string tipo_ref_1 { get; set; }
        public string nom_ref_1 { get; set; }
        public string tipo_ref_2 { get; set; }
        public string nom_ref_2 { get; set; }
        public string tipo_ref_3 { get; set; }
        public string nom_ref_3 { get; set; }
        public string descr_ubic { get; set; }
        public string ID_ESCUELA { get; set; }
        public string CCT { get; set; }
        public string NOMBRE_ESCUELA { get; set; }
        public string TURNO { get; set; }
        public string MUNICIPIO { get; set; }
        public string LOCALIDAD { get; set; }
        public string TIPO { get; set; }
        public string NIVEL { get; set; }
        public string SUBNIVEL { get; set; }
        public string GRADO { get; set; }
        public string creador { get; set; }
        public DateTime? fecha_registro_sipabe { get; set; }
        public string validado_RENAPO { get; set; }
        public string estatus_vital { get; set; }

        public override string ToString()
        {
            return "Curp: "+id_curp_beneficiario+" Nombre: "+nombre_beneficiario+" Apellido: "+primer_apellido_beneficiario+" "+segundo_apellido_beneficiario;
        }
    }
}
