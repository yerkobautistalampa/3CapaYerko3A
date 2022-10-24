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
    public partial class FormCursos : Form
    {
        public FormCursos()
        {
            InitializeComponent();
        }

        private void FormCursos_Load(object sender, EventArgs e)
        {
            try
            {
                Services objServicios = new Services();
                lblUsuario.Text += objServicios.NombreCompleto(Program.ciPersona).ToUpper();
                lblCargo.Text += objServicios.obtieneCargo(Program.ciPersona).ToUpper();

                //control de fechas para cursos
                dtpFechaInicio.Value = DateTime.Today;
                dtpFechaInicio.MinDate = DateTime.Today.AddMonths(-1);
                dtpFechaInicio.MaxDate = DateTime.Today.AddYears(1);
            }
            catch
            {

            }
        }

        private void groupBox1_Enter(object sender, EventArgs e) {}

        private void txtCiDocente_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Services objServicios = new Services();
                txtNombreDocente.Clear();
                txtCelularDocente.Clear();
                txtProfecion.Clear();

                dgvDocentes.DataSource = objServicios.mostrarDocentes(Convert.ToInt32(txtCiDocente.Text));
                dgvDocentes.Refresh();
                dgvDocentes.Visible = true;
            }
            catch
            {
                MessageBox.Show("Escriba solo numeros.","Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            

        }

        private void dgvDocentes_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                txtCiDocente.Text = dgvDocentes.SelectedRows[0].Cells[0].Value.ToString();
                txtNombreDocente.Text = dgvDocentes.SelectedRows[0].Cells[1].Value.ToString();
                txtCelularDocente.Text = dgvDocentes.SelectedRows[0].Cells[2].Value.ToString();
                txtProfecion.Text = dgvDocentes.SelectedRows[0].Cells[3].Value.ToString();
                dgvDocentes.Visible = false;
            }
            catch
            {}     
        }

        private void btnCrearCurso_Click(object sender, EventArgs e)
        {
            try
            {
                ClassCurso objCurso = new ClassCurso();
                objCurso.carrera = cmbCarrera.Text.ToLower();
                objCurso.nombre = txtCurso.Text.ToLower();
                objCurso.modalidad = cmbModalidad.Text.ToLower();
                objCurso.fechaInicio = dtpFechaInicio.Value;
                objCurso.turno = cmbTurno.Text.ToLower();
                objCurso.horario = txtHorario.Text.ToLower();
                objCurso.duracion = txtDuracion.Text.ToLower();


                if (cbLunes.Checked)
                    objCurso.dias += "Lunes, ";
                if (cbMartes.Checked)
                    objCurso.dias += "Martes, ";
                if (cbMiercoles.Checked)
                    objCurso.dias += "Miercoles, ";
                if (cbJueves.Checked)
                    objCurso.dias += "jueves, ";
                if (cbViernes.Checked)
                    objCurso.dias += "Viernes, ";
                if (cbSabado.Checked)
                    objCurso.dias += "Sabado, ";
                if (cbDomingo.Checked)
                    objCurso.dias += "Domingo, ";

                objCurso.cargaHoraria = (short)numCargaHoraria.Value;
                objCurso.costo = (double)numCosto.Value;

                objCurso.ciDocente = Convert.ToInt32(txtCiDocente.Text);
                objCurso.ultimoUsuario = Program.ciPersona;

                Services objServicios = new Services();
                txtNombreDocente.Clear();
                txtCelularDocente.Clear();
                txtProfecion.Clear();
                try
                {
                    if (objServicios.agregarCurso(objCurso))
                    {
                        MessageBox.Show("Curso registrado exitosamente.", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        btnCrearCurso.Enabled = false;
                    }  
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {
                MessageBox.Show("Inserte el docente que impartira el curso.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            btnCrearCurso.Enabled = true;
            cmbCarrera.Text = "--Seleccionar--";
            txtCurso.Clear();
            txtHorario.Clear();
            txtDuracion.Clear();
            numCargaHoraria.Value=0;
            numCosto.Value = 0;
            txtCiDocente.Clear();
            dgvDocentes.Visible = false;

            txtNombreDocente.Clear();
            txtCelularDocente.Clear();
            txtProfecion.Clear();

            cbLunes.Checked = false;
            cbMartes.Checked = false;
            cbMiercoles.Checked = false;
            cbJueves.Checked = false;
            cbViernes.Checked = false;
            cbSabado.Checked = false;
            cbDomingo.Checked = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormVerCursos f = new FormVerCursos();
            f.ShowDialog();
        }

        private void btnNuevoDocente_Click(object sender, EventArgs e)
        {
            FormUsuarios f = new FormUsuarios();
            f.ShowDialog();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
