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
    public partial class FormUsuarios : Form
    {
        public FormUsuarios()
        {
            InitializeComponent();
        }

        private void FormUsuarios_Load(object sender, EventArgs e)
        {
            try
            {
                Services objServicios = new Services();
                lblUsuario.Text += objServicios.NombreCompleto(Program.ciPersona).ToUpper();
                lblCargo.Text += objServicios.obtieneCargo(Program.ciPersona).ToUpper();

                cbCargo.DataSource = objServicios.ListaCargos();
            }
            catch
            {

            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                ClassDocente d = new ClassDocente();
                d.ci = Convert.ToInt32(txtCi.Text);
                d.nombre = txtNombre.Text.ToLower();
                d.paterno = txtPaterno.Text.ToLower();
                d.materno = txtMaterno.Text.ToLower();
                d.direccion = txtDireccion.Text.ToLower();
                d.celular = Convert.ToInt32(txtCelular.Text.ToLower());
                d.genero = cbGenero.Text.Substring(0,1).ToLower();
                d.fechaNacimiento = dtpFechaNacimiento.Value;
                d.correo = txtCorreo.Text.ToLower();
                d.ultimoUsuario = Program.ciPersona;

                d.ciPersona = Convert.ToInt32(txtCi.Text);
                d.item = Convert.ToInt32(txtItem.Text);
                d.profecion = txtProfecion.Text;

                try
                {
                    Services objServicios = new Services();
                    if (objServicios.agregardocente(d))
                    {
                        MessageBox.Show("docente registrado exitosamente", "registro exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnGuardar.Enabled = false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Inserte todos los datos","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            txtItem.Clear();
            txtProfecion.Clear();

            btnGuardar.Enabled = true;
        }

        private void btnVerUsuarios_Click(object sender, EventArgs e)
        {
            FormVerUsuarios f = new FormVerUsuarios();
            f.ShowDialog();
        }
    }
}
