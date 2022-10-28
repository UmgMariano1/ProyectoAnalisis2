using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad1;
using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
    public class Datos_Ficha
    {
        public Ficha VerFicha(int IdCita)
        {
            Ficha objeto = new Ficha();

            try
            {

                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {


                    SqlCommand cmd = new SqlCommand("SP_BuscarFichaMedica", oconexion);
                    cmd.Parameters.AddWithValue("IdCita", IdCita);
                    cmd.CommandType = CommandType.StoredProcedure;


                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {

                            objeto = new Ficha()
                            {
                                IdCita = Convert.ToInt32(dr["IdCita"]),
                                FechaRegistro = dr["FechaRegistro"].ToString(),
                                Motivo = dr["Cintomas"].ToString(),
                                Especialista = dr["Especialista"].ToString(),
                                Paciente = dr["Paciente"].ToString(),
                                ResultadoEx = dr["Resultado"].ToString(),
                            };
                        }
                    }

                }
            }
            catch
            {
                objeto = new Ficha();
            }

            return objeto;
        }

        public VerExamen VerFicha2(int IdCita)
        {
            VerExamen objeto = new VerExamen();

            try
            {

                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {


                    SqlCommand cmd = new SqlCommand("Sp_examenes", oconexion);
                    cmd.Parameters.AddWithValue("IdCita", IdCita);
                    cmd.CommandType = CommandType.StoredProcedure;


                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {

                            objeto = new VerExamen()
                            {
                               // IdCita = Convert.ToInt32(dr["IdCita"]),
                                Nombre = dr["Examanes"].ToString(),
                               // cantidad = Convert.ToInt32(dr["cantidad"]),

                            };
                        }
                    }

                }
            }
            catch
            {
                objeto = new VerExamen();
            }

            return objeto;
        }
        public VerMedicamento VerFicha3(int IdCita)
        {
            VerMedicamento objeto = new VerMedicamento();

            try
            {

                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {


                    SqlCommand cmd = new SqlCommand("Sp_medicamentos", oconexion);
                    cmd.Parameters.AddWithValue("IdCita", IdCita);
                    cmd.CommandType = CommandType.StoredProcedure;


                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {

                            objeto = new VerMedicamento()
                            {
                                // IdCita = Convert.ToInt32(dr["IdCita"]),
                                Medicamentos = dr["Medicamentos"].ToString(),
                                // cantidad = Convert.ToInt32(dr["cantidad"]),

                            };
                        }
                    }

                }
            }
            catch
            {
                objeto = new VerMedicamento();
            }

            return objeto;
        }


    }
}
