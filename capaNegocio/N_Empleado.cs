
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using capaDatos;
using capaEntidad;
using System.Data;

namespace capaNegocio
{
    public class N_Empleado
    {

        D_Empleados objdata = new D_Empleados();

        public DataTable N_Listado()
        {
            return objdata.D_Listado();
        }

        public void N_Insertar(E_Empleados emp)
        {
            objdata.D_Insertar(emp);
        }

        public void N_Editar(E_Empleados emp)
        {
            objdata.D_Editar(emp);
        }

        public void N_Eliminar(int cod)
        {
            objdata.D_Eliminar(cod);
        }
    }
}
