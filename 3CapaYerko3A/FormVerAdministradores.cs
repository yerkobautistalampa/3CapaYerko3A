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

using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Data.SqlClient;

namespace _3CapaYerko3A
{
    public partial class FormVerAdministradores : Form
    {
        public FormVerAdministradores()
        {
            InitializeComponent();
        }

        private void FormVerAdministradores_Load(object sender, EventArgs e)
        {
            try
            {
                Services objServicios = new Services();
                lblUsuario.Text += objServicios.NombreCompleto(Program.ciPersona).ToUpper();
                lblCargo.Text += objServicios.obtieneCargo(Program.ciPersona).ToUpper();
                
                //cargar los cargos al combo box
                List<string> x = new List<string>();
                x = objServicios.ListaCargos();
                x.RemoveAt(0);
                cbSelecionarCargos.DataSource = x;

                dataAdministradores.DataSource = objServicios.mostarAdministradores();
            }
            catch
            {
                MessageBox.Show("problemas con la base de datos");
            }
        }

        private void btnDescargarPdf_Click(object sender, EventArgs e)
        {
            if (dataAdministradores.Rows.Count > 0)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "PDF (*.pdf)|*.pdf";
                sfd.FileName = "Output.pdf";
                bool fileError = false;
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(sfd.FileName))
                    {
                        try
                        {
                            File.Delete(sfd.FileName);
                        }
                        catch (IOException ex)
                        {
                            fileError = true;
                            MessageBox.Show("It wasn't possible to write the data to the disk." + ex.Message);
                        }
                    }
                    if (!fileError)
                    {
                        try
                        {
                            PdfPTable pdfTable = new PdfPTable(dataAdministradores.Columns.Count);
                            pdfTable.DefaultCell.Padding = 3;
                            pdfTable.WidthPercentage = 100;
                            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;

                            foreach (DataGridViewColumn column in dataAdministradores.Columns)
                            {
                                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                                pdfTable.AddCell(cell);
                            }

                            foreach (DataGridViewRow row in dataAdministradores.Rows)
                            {
                                foreach (DataGridViewCell cell in row.Cells)
                                {
                                    pdfTable.AddCell(cell.Value.ToString());
                                }
                            }

                            using (FileStream stream = new FileStream(sfd.FileName, FileMode.Create))
                            {
                                Document pdfDoc = new Document(PageSize.A4, 10f, 20f, 20f, 10f);
                                PdfWriter.GetInstance(pdfDoc, stream);
                                pdfDoc.Open();
                                pdfDoc.Add(new Paragraph("                            reporte de docentes"));
                                pdfDoc.Add(pdfTable);
                                pdfDoc.Close();
                                stream.Close();
                            }

                            MessageBox.Show("Data Exported Successfully !!!", "Info");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error :" + ex.Message);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("No Record To Export !!!", "Info");
            }
        }

        private void cbSelecionarCargos_SelectedIndexChanged(object sender, EventArgs e)
        {
            Services objServicios = new Services();
            dataAdministradores.DataSource = null;
            dataAdministradores.DataSource = objServicios.mostarAdministradores(cbSelecionarCargos.Text);
            dataAdministradores.Refresh();

        }
    }
}
