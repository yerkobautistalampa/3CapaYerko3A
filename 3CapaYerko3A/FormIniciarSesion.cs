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
    public partial class FormIniciarSesion : Form
    {
        public FormIniciarSesion()
        {
            InitializeComponent();
        }
        private void btnIniciarSecion_Click(object sender, EventArgs e)
        {
            Services objServicios = new Services();
            try
            {
                
                //almacenar en la variable global
                Program.ciPersona = objServicios.login(txtUsuario.Text,txtPassword.Text);
                string nombre = objServicios.NombreCompleto(Program.ciPersona);
                MessageBox.Show("Bienvenido al sistema \n"+nombre.ToUpper(),"acceso correcto",MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                txtUsuario.Clear();
                txtPassword.Clear();

                FormMenu f = new FormMenu();
                f.ShowDialog();
            }
            catch (Exception ex )
            {
                MessageBox.Show(ex.Message,"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void FormIniciarSesion_Load(object sender, EventArgs e)
        {

        }
        private void txtUsuario_TextChanged(object sender, EventArgs e) { }
    }
}
