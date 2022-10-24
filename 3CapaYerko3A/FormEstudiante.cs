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
    public partial class FormEstudiante : Form
    {
        public FormEstudiante()
        {
            InitializeComponent();
        }

        private void FormEstudiante_Load(object sender, EventArgs e)
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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                ClassEstudiante es = new ClassEstudiante();
                es.ci = Convert.ToInt32(txtCi.Text);
                es.nombre = txtNombre.Text.ToLower();
                es.paterno = txtPaterno.Text.ToLower();
                es.materno = txtMaterno.Text.ToLower();
                es.direccion = txtDireccion.Text.ToLower();
                es.celular = Convert.ToInt32(txtCelular.Text.ToLower());
                es.genero = cbGenero.Text.Substring(0, 1).ToLower();
                es.fechaNacimiento = dtpFechaNacimiento.Value;
                es.correo = txtCorreo.Text.ToLower();
                es.ultimoUsuario = Program.ciPersona;


                try
                {
                    Services objServicios = new Services();
                    if (objServicios.agregarEstudiante(es))
                    {
                        MessageBox.Show("estudiante registrado exitosamente", "registro exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnGuardar.Enabled = false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Inserte todos los datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {

            txtCi.Clear();
            txtNombre.Clear();
            txtPaterno.Clear();
            txtMaterno.Clear();
            txtDireccion.Clear();
            txtCorreo.Clear();
            txtCelular.Clear();

            btnGuardar.Enabled = true;
        }

        private void btnVerEstudiantes_Click(object sender, EventArgs e)
        {
            FormVerEstudiantes f = new FormVerEstudiantes();
            f.ShowDialog();
        }
    }
}
