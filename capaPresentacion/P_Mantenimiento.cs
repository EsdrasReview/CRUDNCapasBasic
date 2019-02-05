using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using capaEntidad;
using capaNegocio;

namespace capaPresentacion
{
    public partial class P_Mantenimiento : Form
    {
        public P_Mantenimiento()
        {
            InitializeComponent();
        }

        private void P_Mantenimiento_Load(object sender, EventArgs e)
        {
            Listar_Empleado();
        }

        E_Empleados objEntidad = new E_Empleados();
        N_Empleado objNegocio = new N_Empleado();

        void Listar_Empleado()
        {
            DataTable dt = objNegocio.N_Listado();
            dataGrid.DataSource = dt;
        }

        void insertar()
        {
     
            objEntidad.nom = txtnombre.Text;
            objEntidad.edad = Convert.ToInt32(txtedad.Text);
            objEntidad.sexo = txtsexo.Text;
            objEntidad.sueldo = Convert.ToDouble(txtsueldo.Text);

            objNegocio.N_Insertar(objEntidad);

            MessageBox.Show("Registro Ingresado Correctamente");
        }

        private void btninsert_Click(object sender, EventArgs e)
        {
            insertar();
            Listar_Empleado();
            limpiartex();
        }

        void limpiartex()
        {
            txtcod.Text = "";
            txtedad.Text = "";
            txtnombre.Text = "";
            txtsexo.Text = "";
            txtsueldo.Text = "";
        }

        private void dataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGrid.Rows[e.RowIndex].Cells["Eliminar"].Selected)
            {
                int eliminar = Convert.ToInt32(dataGrid.Rows[e.RowIndex].Cells["codEmp"].Value.ToString());
                objNegocio.N_Eliminar(eliminar);
                Listar_Empleado();
            } 
            else if(dataGrid.Rows[e.RowIndex].Cells["Editar"].Selected)
            {
                txtcod.Text = dataGrid.Rows[e.RowIndex].Cells["codEmp"].Value.ToString();
                txtnombre.Text = dataGrid.Rows[e.RowIndex].Cells["nomEmp"].Value.ToString();
                txtedad.Text = dataGrid.Rows[e.RowIndex].Cells["edadEmp"].Value.ToString();
                txtsexo.Text = dataGrid.Rows[e.RowIndex].Cells["sexoEmp"].Value.ToString();
                txtsueldo.Text = dataGrid.Rows[e.RowIndex].Cells["sueldoEmp"].Value.ToString();
            }
        }

        private void btnedit_Click(object sender, EventArgs e)
        {
            editar();
            Listar_Empleado();
            limpiartex();
        }

        void editar()
        {

            objEntidad.cod = Convert.ToInt32(txtcod.Text);
            objEntidad.nom = txtnombre.Text;
            objEntidad.edad = Convert.ToInt32(txtedad.Text);
            objEntidad.sexo = txtsexo.Text;
            objEntidad.sueldo = Convert.ToDouble(txtsueldo.Text);

            objNegocio.N_Editar(objEntidad);

            MessageBox.Show("Registro Editado Correctamente");
        }
    }
}
