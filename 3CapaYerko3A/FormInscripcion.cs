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
    public partial class FormInscripcion : Form
    {
        public FormInscripcion()
        {
            InitializeComponent();
        }

        private void FormInscripcion_Load(object sender, EventArgs e)
        {
            Services objServicios = new Services();
            lblUsuario.Text += objServicios.NombreCompleto(Program.ciPersona).ToUpper();
            lblCargo.Text += objServicios.obtieneCargo(Program.ciPersona).ToUpper();

            dgvInscripciones.DataSource = objServicios.mostrarEstudiantesInscritosMes();
        }

        private void btnAgrgarNuevoEstudiante_Click(object sender, EventArgs e)
        {
            FormEstudiante f = new FormEstudiante();
            f.ShowDialog();
        }

        private void btnVerDetalles_Click(object sender, EventArgs e)
        {
            FormVerCursos f = new FormVerCursos();
            f.ShowDialog();
        }
        private void txtCiEstudiante_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Services objServicios = new Services();
                int ci = Convert.ToInt32(txtCiEstudiante.Text);
                dgvEstudiante.DataSource = objServicios.mostarEstudiantes(ci);
                dgvEstudiante.Refresh();
                dgvEstudiante.Visible = true;
            }
            catch
            {
                dgvEstudiante.Visible = false;
            }
        }

        private void dgvEstudiante_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                txtCiEstudiante.Text = dgvEstudiante.SelectedRows[0].Cells[0].Value.ToString();
                txtNombreEstudiante.Text = dgvEstudiante.SelectedRows[0].Cells[1].Value.ToString();
                dgvEstudiante.Visible = false;
            }
            catch
            { }
        }
        private void cmbCarrera_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Services objServicios = new Services();
                string carrera = cmbCarrera.Text.ToLower();
                cmbCurso.Text = "";
                cmbCurso.DataSource = objServicios.mostrarCursosMes(carrera);
                cmbCurso.DisplayMember = "nombre";
                cmbCurso.ValueMember = "codigoCurso";
            }
            catch
            {

            }
        }

        private void dgvEstudiante_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        { }
        private void btnInscribir_Click(object sender, EventArgs e)
        {
            try
            {
                ClassInscripcion objInscripcion = new ClassInscripcion();
                objInscripcion.ciEstudiante = Convert.ToInt32(txtCiEstudiante.Text);
                objInscripcion.ciAdministrativo = Program.ciPersona;
                objInscripcion.codigoCurso = (short)cmbCurso.SelectedValue;
                objInscripcion.ultimoUsuario= Program.ciPersona;

                Services objServicios = new Services();
                if (objServicios.agregarInscripcion(objInscripcion))
                {
                    MessageBox.Show("Inscripcion registrado exitosamente.", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    btnInscribir.Enabled = false;
                    dgvInscripciones.DataSource = objServicios.mostrarEstudiantesInscritosMes();
                    dgvInscripciones.Refresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("inserte estudiante y seleccione el curso", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtCiEstudiante.Clear();
            txtNombreEstudiante.Clear();
            cmbCarrera.Text = "--Seleccionar--";
            cmbCurso.Text = "";
            btnInscribir.Enabled = true;
        }
    }
}
