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
    public class Datos_GastosFundacion
    {
        public List<GastosFundacion> Listar()
        {
            List<GastosFundacion> listar = new List<GastosFundacion>();


            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    StringBuilder sb = new StringBuilder();

                    sb.AppendLine("SELECT gg.IdGastosGenerales , gg.NombreGasto, gg.MontoGasto,");
                    sb.AppendLine("f.IdFundacion, Concat(f.Descripcion,' ', f.NombreFundacion) As Fundacion");
                    sb.AppendLine("FROM GASTOS_FUNDACION gf INNER JOIN GASTOSGENERALES gg ON gf.IdFundacion=gg.IdGastosGenerales");
                    sb.AppendLine("INNER JOIN FUNDACION f ON f.IdFundacion = gf.IdFundacion");
                    

                    SqlCommand cmd = new SqlCommand(sb.ToString(), oconexion);
                    cmd.CommandType = CommandType.Text;
                    oconexion.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            listar.Add(
                                new GastosFundacion()
                                {
                                   
                                   
                                    OgastosGenerales = new GastosGenerales() { IdGastosGenerales = Convert.ToInt32(reader["IdGastosGenerales"]), NombreGasto = reader["NombreGasto"].ToString(), MontoGasto = Convert.ToDecimal(reader["MontoGasto"]) },
                                    Ofundacion = new Fundacion() { IdFundacion = Convert.ToInt32(reader["IdFundacion"]), NombreFundacion = reader["Fundacion"].ToString() },
                                   


                                }

                                );
                        }
                    }
                }

            }
            catch
            {
                listar = new List<GastosFundacion>();

            }




            return listar;
        }
    }
}
