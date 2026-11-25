using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIPABE_DIFGRO_FAH
{
    public class SolicitudItem
    {
        public int Id_Solicitud { get; set; }
        public string NOMBRE_APOYO { get; set; }
        public DateTime? Fecha_Solicitud { get; set; }
        public decimal? Fecha_Solicitud_Invert { get; set; }
        public DateTime? Fecha_Captura { get; set; }
        public string Cve_Ent_Fed { get; set; }
        public string Nom_Ent_Fed { get; set; }
        public string Cve_Municipio { get; set; }
        public string Nom_Municipio { get; set; }
        public string Cve_Localidad { get; set; }
        public string Nom_Localidad { get; set; }
        public string Cve_Localidad_ID { get; set; }
        public string Region_Apoyo { get; set; }
        public string Desc_Tipo_Beneficio { get; set; }
        public string Tipo_Beneficio_U_Med { get; set; }
        public string Clave_Beneficio_DIF_Nacional { get; set; }
        public string Cve_Tipo_Beneficiario { get; set; }
        public decimal? Cantidad_Apoyo { get; set; }
        public string Beneficiario_Fisico_CURP { get; set; }
        public string Beneficiario_Moral_RFC { get; set; }
        public string Institucion { get; set; }
        public string Direccion { get; set; }
        public string Programa { get; set; }
        public string Cve_Programa { get; set; }
        public string Cve_Dependencia { get; set; }
        public string Cve_Intraprograma { get; set; }
        public string Estado_Solicitud { get; set; }
        public string ID_Escuela { get; set; }
        public string CCT { get; set; }
        public string Nombre_Escuela { get; set; }
        public string Turno_Escuela { get; set; }
        public string Municipio_Escuela { get; set; }
        public string Localidad_Escuela { get; set; }
        public string Tipo_Escuela { get; set; }
        public string Nivel_Escuela { get; set; }
        public string Subnivel_Escuela { get; set; }
        public string Grado_Escuela { get; set; }
        public string Capturista { get; set; }
        public string Ejercicio_Fiscal { get; set; }
        public string Fuent_Financiamiento { get; set; }
        public string ID_Curp_Beneficiario { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine("===== SolicitudItem =====");
            sb.AppendLine($"Id_Solicitud: {Id_Solicitud}");
            sb.AppendLine($"NOMBRE_APOYO: {NOMBRE_APOYO}");
            sb.AppendLine($"Fecha_Solicitud: {(Fecha_Solicitud.HasValue ? Fecha_Solicitud.Value.ToString("yyyy-MM-dd") : "null")}");
            sb.AppendLine($"Fecha_Solicitud_Invert: {(Fecha_Solicitud_Invert.HasValue ? Fecha_Solicitud_Invert.Value.ToString() : "null")}");
            sb.AppendLine($"Fecha_Captura: {(Fecha_Captura.HasValue ? Fecha_Captura.Value.ToString("yyyy-MM-dd") : "null")}");
            sb.AppendLine($"Cve_Ent_Fed: {Cve_Ent_Fed}");
            sb.AppendLine($"Nom_Ent_Fed: {Nom_Ent_Fed}");
            sb.AppendLine($"Cve_Municipio: {Cve_Municipio}");
            sb.AppendLine($"Nom_Municipio: {Nom_Municipio}");
            sb.AppendLine($"Cve_Localidad: {Cve_Localidad}");
            sb.AppendLine($"Nom_Localidad: {Nom_Localidad}");
            sb.AppendLine($"Cve_Localidad_ID: {Cve_Localidad_ID}");
            sb.AppendLine($"Region_Apoyo: {Region_Apoyo}");
            sb.AppendLine($"Desc_Tipo_Beneficio: {Desc_Tipo_Beneficio}");
            sb.AppendLine($"Tipo_Beneficio_U_Med: {Tipo_Beneficio_U_Med}");
            sb.AppendLine($"Clave_Beneficio_DIF_Nacional: {Clave_Beneficio_DIF_Nacional}");
            sb.AppendLine($"Cve_Tipo_Beneficiario: {Cve_Tipo_Beneficiario}");
            sb.AppendLine($"Cantidad_Apoyo: {(Cantidad_Apoyo.HasValue ? Cantidad_Apoyo.Value.ToString() : "null")}");
            sb.AppendLine($"Beneficiario_Fisico_CURP: {Beneficiario_Fisico_CURP}");
            sb.AppendLine($"Beneficiario_Moral_RFC: {Beneficiario_Moral_RFC}");
            sb.AppendLine($"Institucion: {Institucion}");
            sb.AppendLine($"Direccion: {Direccion}");
            sb.AppendLine($"Programa: {Programa}");
            sb.AppendLine($"Cve_Programa: {Cve_Programa}");
            sb.AppendLine($"Cve_Dependencia: {Cve_Dependencia}");
            sb.AppendLine($"Cve_Intraprograma: {Cve_Intraprograma}");
            sb.AppendLine($"Estado_Solicitud: {Estado_Solicitud}");
            sb.AppendLine($"ID_Escuela: {ID_Escuela}");
            sb.AppendLine($"CCT: {CCT}");
            sb.AppendLine($"Nombre_Escuela: {Nombre_Escuela}");
            sb.AppendLine($"Turno_Escuela: {Turno_Escuela}");
            sb.AppendLine($"Municipio_Escuela: {Municipio_Escuela}");
            sb.AppendLine($"Localidad_Escuela: {Localidad_Escuela}");
            sb.AppendLine($"Tipo_Escuela: {Tipo_Escuela}");
            sb.AppendLine($"Nivel_Escuela: {Nivel_Escuela}");
            sb.AppendLine($"Subnivel_Escuela: {Subnivel_Escuela}");
            sb.AppendLine($"Grado_Escuela: {Grado_Escuela}");
            sb.AppendLine($"Capturista: {Capturista}");
            sb.AppendLine($"Ejercicio_Fiscal: {Ejercicio_Fiscal}");
            sb.AppendLine($"Fuent_Financiamiento: {Fuent_Financiamiento}");
            sb.AppendLine($"ID_Curp_Beneficiario: {ID_Curp_Beneficiario}");
            sb.AppendLine("==========================");

            return sb.ToString();
        }

        public static void registrarSolicitud(SolicitudItem solicitudItem)
        {
            string query = @"
        INSERT INTO SOLICITUD (
            NOMBRE_APOYO, Fecha_Solicitud, Fecha_Solicitud_Invert, 
            Fecha_Captura, Cve_Ent_Fed, Nom_Ent_Fed, Cve_Municipio, Nom_Municipio,
            Cve_Localidad, Nom_Localidad, Cve_Localidad_ID, Region_Apoyo,
            Desc_Tipo_Beneficio, Tipo_Beneficio_U_Med, Clave_Beneficio_DIF_Nacional,
            Cve_Tipo_Beneficiario, Cantidad_Apoyo, Beneficiario_Fisico_CURP,
            Beneficiario_Moral_RFC, Institucion, Direccion, Programa, Cve_Programa,
            Cve_Dependencia, Cve_Intraprograma, Estado_Solicitud, ID_Escuela, CCT,
            Nombre_Escuela, Turno_Escuela, Municipio_Escuela, Localidad_Escuela,
            Tipo_Escuela, Nivel_Escuela, Subnivel_Escuela, Grado_Escuela,
            Capturista, Ejercicio_Fiscal, Fuent_Financiamiento, ID_Curp_Beneficiario
        ) VALUES (
            @NOMBRE_APOYO, @Fecha_Solicitud, @Fecha_Solicitud_Invert,
            @Fecha_Captura, @Cve_Ent_Fed, @Nom_Ent_Fed, @Cve_Municipio, @Nom_Municipio,
            @Cve_Localidad, @Nom_Localidad, @Cve_Localidad_ID, @Region_Apoyo,
            @Desc_Tipo_Beneficio, @Tipo_Beneficio_U_Med, @Clave_Beneficio_DIF_Nacional,
            @Cve_Tipo_Beneficiario, @Cantidad_Apoyo, @Beneficiario_Fisico_CURP,
            @Beneficiario_Moral_RFC, @Institucion, @Direccion, @Programa, @Cve_Programa,
            @Cve_Dependencia, @Cve_Intraprograma, @Estado_Solicitud, @ID_Escuela, @CCT,
            @Nombre_Escuela, @Turno_Escuela, @Municipio_Escuela, @Localidad_Escuela,
            @Tipo_Escuela, @Nivel_Escuela, @Subnivel_Escuela, @Grado_Escuela,
            @Capturista, @Ejercicio_Fiscal, @Fuent_Financiamiento, @ID_Curp_Beneficiario
        );";

            // 3. Usa bloques using para asegurar la liberación de recursos (conexión y comando).
            using (SqlConnection conn = new SqlConnection(LoginForm.CadenaDeConexionGlobal))
            {
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    // 4. Agrega los parámetros. Usa DBNull.Value para los valores nulos.
                    // command.Parameters.AddWithValue("@Id_Solicitud", solicitudItem.Id_Solicitud);
                    command.Parameters.AddWithValue("@NOMBRE_APOYO", solicitudItem.NOMBRE_APOYO ?? (object)DBNull.Value);

                    // Manejo especial para fechas nulas (nullable DateTime)
                    command.Parameters.AddWithValue("@Fecha_Solicitud", solicitudItem.Fecha_Solicitud ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Fecha_Solicitud_Invert", solicitudItem.Fecha_Solicitud_Invert ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Fecha_Captura", solicitudItem.Fecha_Captura ?? (object)DBNull.Value);

                    command.Parameters.AddWithValue("@Cve_Ent_Fed", solicitudItem.Cve_Ent_Fed ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Nom_Ent_Fed", solicitudItem.Nom_Ent_Fed ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Cve_Municipio", solicitudItem.Cve_Municipio ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Nom_Municipio", solicitudItem.Nom_Municipio ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Cve_Localidad", solicitudItem.Cve_Localidad ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Nom_Localidad", solicitudItem.Nom_Localidad ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Cve_Localidad_ID", solicitudItem.Cve_Localidad_ID ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Region_Apoyo", solicitudItem.Region_Apoyo ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Desc_Tipo_Beneficio", solicitudItem.Desc_Tipo_Beneficio ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Tipo_Beneficio_U_Med", solicitudItem.Tipo_Beneficio_U_Med ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Clave_Beneficio_DIF_Nacional", solicitudItem.Clave_Beneficio_DIF_Nacional ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Cve_Tipo_Beneficiario", solicitudItem.Cve_Tipo_Beneficiario ?? (object)DBNull.Value);

                    command.Parameters.AddWithValue("@Cantidad_Apoyo", solicitudItem.Cantidad_Apoyo ?? (object)DBNull.Value);

                    command.Parameters.AddWithValue("@Beneficiario_Fisico_CURP", solicitudItem.Beneficiario_Fisico_CURP ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Beneficiario_Moral_RFC", solicitudItem.Beneficiario_Moral_RFC ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Institucion", solicitudItem.Institucion ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Direccion", solicitudItem.Direccion ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Programa", solicitudItem.Programa ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Cve_Programa", solicitudItem.Cve_Programa ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Cve_Dependencia", solicitudItem.Cve_Dependencia ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Cve_Intraprograma", solicitudItem.Cve_Intraprograma ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Estado_Solicitud", solicitudItem.Estado_Solicitud ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@ID_Escuela", solicitudItem.ID_Escuela ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@CCT", solicitudItem.CCT ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Nombre_Escuela", solicitudItem.Nombre_Escuela ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Turno_Escuela", solicitudItem.Turno_Escuela ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Municipio_Escuela", solicitudItem.Municipio_Escuela ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Localidad_Escuela", solicitudItem.Localidad_Escuela ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Tipo_Escuela", solicitudItem.Tipo_Escuela ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Nivel_Escuela", solicitudItem.Nivel_Escuela ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Subnivel_Escuela", solicitudItem.Subnivel_Escuela ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Grado_Escuela", solicitudItem.Grado_Escuela ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Capturista", solicitudItem.Capturista ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Ejercicio_Fiscal", solicitudItem.Ejercicio_Fiscal ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Fuent_Financiamiento", solicitudItem.Fuent_Financiamiento ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@ID_Curp_Beneficiario", solicitudItem.ID_Curp_Beneficiario ?? (object)DBNull.Value);

                    // 5. Abre la conexión y ejecuta el comando.
                    try
                    {
                        conn.Open();
                        int filasAfectadas = command.ExecuteNonQuery();

                        if (filasAfectadas > 0)
                        {
                            MessageBox.Show("Solicitud registrada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (SqlException ex)
                    {
                        // Si hay un error de SQL (como una columna mal escrita), te lo mostrará aquí
                        MessageBox.Show($"Error de Base de Datos: {ex.Message}\n\nNúmero de error: {ex.Number}", "Error SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error inesperado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
