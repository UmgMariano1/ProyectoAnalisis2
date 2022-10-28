using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad1;



namespace CapaDatos
{
    public class Datos_MenuAdmin
    {
        public MenuAdmin verMenu()
        {
            MenuAdmin objeto = new MenuAdmin();


            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {

                    SqlCommand cmd = new SqlCommand("SpMenuAdmin", oconexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    oconexion.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            objeto = new MenuAdmin()
                            {
                                CantidadUsuario = Convert.ToInt32(reader["Usuarios"]),
                                CantidadMedico = Convert.ToInt32(reader["Medicos"]),
                                CantidadEnfermero = Convert.ToInt32(reader["Enfermeros"]),
                                CantidadEspecialista = Convert.ToInt32(reader["Especialistas"]),
                            };


                        }
                    }
                }

            }
            catch
            {
                objeto = new MenuAdmin();

            }




            return objeto;
        }
    }
}
