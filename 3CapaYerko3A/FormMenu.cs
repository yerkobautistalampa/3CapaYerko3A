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
    public partial class FormMenu : Form
    {
        public FormMenu()
        {
            InitializeComponent();
        }

        private void FormMenu_Load(object sender, EventArgs e)
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

        private void btnAgregarCursos_Click(object sender, EventArgs e)
        {
            FormCursos f = new FormCursos();
            f.ShowDialog();
        }

        private void btnAgregarUsuario_Click(object sender, EventArgs e)
        {
            FormUsuarios f = new FormUsuarios();
            f.ShowDialog();
        }

        private void btnInscribir_Click(object sender, EventArgs e)
        {
            FormEstudiante f = new FormEstudiante();
            f.ShowDialog();
        }

        private void btnVerCursos_Click(object sender, EventArgs e)
        {}

        private void btnReportes_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void btnAgragarAdministrativos_Click(object sender, EventArgs e)
        {
            FormAdministrativos f = new FormAdministrativos();
            f.ShowDialog();
        }

        private void btnInscripcion_Click(object sender, EventArgs e)
        {
            FormInscripcion f = new FormInscripcion();
            f.ShowDialog();
        }
    }
}
