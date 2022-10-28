using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad1; 

namespace CapaNegocio
{
    public class CN_GastosFundacion
    {
        private Datos_GastosFundacion objgastos = new Datos_GastosFundacion();

        //metodo para listar, 
        public List<GastosFundacion> Listar()
        {
            return objgastos.Listar();
        }



    }
}
