using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LogicaNegocios;
using Entidades;

namespace _3CapaYerko3A
{
    public partial class FormModulos : Form
    {
        public FormModulos()
        {
            InitializeComponent();
        }

        private void FormModulos_Load(object sender, EventArgs e)
        {
            try
            {
                Services objServicios = new Services();
                lblUsuario.Text += objServicios.NombreCompleto(Program.ciPersona).ToUpper();
                lblCargo.Text += objServicios.obtieneCargo(Program.ciPersona).ToUpper();
            }
            catch
            {

            }
        }
    }
}
