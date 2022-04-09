using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Entity;
using Microsoft.Reporting.WinForms;
using Microsoft.Office.Interop.Excel;
namespace Gestion_Congés
{
    public partial class Gestion_Conge : Form
    {
        Gérer_Conges GConges = new Gérer_Conges();
        Gestion_CongesEntities Gsc = new Gestion_CongesEntities();
        GesEmploye GsE = new GesEmploye();
        Stock_Conge stc = new Stock_Conge();
        Conge con = new Conge();
        public Gestion_Conge()
        {
            InitializeComponent();
               string[] s = new string[] { "Administratif", "Annulé", "Exceptionnel" };
              comCon.Items.AddRange(s);
            GConges.Nbjours();
        }

        private void button1_Click(object sender, EventArgs e)
        {

                if (GConges.AjouterConge(int.Parse(comboBox1.SelectedItem.ToString()), comCon.SelectedItem.ToString() , DateTime.Parse(dateTimePicker1.Text), int.Parse(textBox5.Text)) == true)
                {

                    GConges.Modifier_Stock_Conge(int.Parse(comboBox1.SelectedItem.ToString()), int.Parse(textBox5.Text));


                    MessageBox.Show("Congés Ajoute Avec Success");
                    dataGridView1.DataSource = Gsc.Conges.Select(c => new
                    {
                        Matricule = c.GesEmploye.Matricule,
                        Nom = c.GesEmploye.Nom,
                        Prenom = c.GesEmploye.Prenom,
                        Type_Congé = c.TypeConge,
                        Durée = c.Duree,
                        Date_Debut = c.DateDebut,
                        Date_Final = c.DateFin
                    }).ToList();
                }
                else
                {
                    MessageBox.Show("déja Existe");
                }
            

        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog save = new SaveFileDialog() { Filter = "Exel Workbook|*.xlsx", ValidateNames = true })
            {
                if (save.ShowDialog() == DialogResult.OK)
                {
                    Microsoft.Office.Interop.Excel.Application Excel = new Microsoft.Office.Interop.Excel.Application();
                    Workbook wb = Excel.Workbooks.Add(XlSheetType.xlWorksheet);
                    Worksheet ws = (Worksheet)Excel.ActiveSheet;
                    Excel.Visible = false;
                    ws.Cells[1, 1] = "Matricule";
                    ws.Cells[1, 2] = "Nom";
                    ws.Cells[1, 3] = "Prenom";
                    ws.Cells[1, 4] = "Type_Congé";
                    ws.Cells[1, 5] = "Durée";
                    ws.Cells[1, 6] = "Date_Debut";
                    ws.Cells[1, 7] = "Date_Final";
                    //Adjust width 
                    Range rg;
                    for (int j = 1; j < 8; j++)
                    {
                        rg = (Range)ws.Cells[1, j];
                        rg.ColumnWidth = 18;
                    }
                    var ListConge = Gsc.Conges.ToList();
                    int i = 2;
                    foreach (var c in ListConge)
                    {
                        ws.Cells[i, 1] = c.GesEmploye.Matricule = c.Matricule;
                        ws.Cells[i, 2] = c.GesEmploye.Nom;
                        ws.Cells[i, 3] = c.GesEmploye.Prenom;
                        ws.Cells[i, 4] = c.TypeConge;
                        ws.Cells[i, 5] = c.Duree;
                        ws.Cells[i, 6] = c.DateDebut.ToString();
                        ws.Cells[i, 7] = c.DateFin.ToString();
                        i++;
                    }
                    wb.SaveAs(save.FileName);
                    Excel.Quit();
                    MessageBox.Show("sauvgarder Avec Success !!", "saved", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Conges_Raport cr = new Conges_Raport();
            this.Hide();
            cr.ShowDialog();
        }
        private void Gestion_Conge_Load(object sender, EventArgs e)
        {
            var com = Gsc.GesEmployes.Select(emp => emp.Matricule).Distinct();
            comboBox1.DataSource = com.ToList();
            //comboBox2.DataSource = com.ToList();
            dataGridView1.DataSource = Gsc.Conges.Select(c => new {
                Matricule = c.GesEmploye.Matricule,
                Nom = c.GesEmploye.Nom,
                Prenom = c.GesEmploye.Prenom,
                Type_Congé = c.TypeConge,
                Durée = c.Duree,
                Date_Debut = c.DateDebut,
                Date_Final = c.DateFin
         }).ToList();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

       

        private void button4_Click(object sender, EventArgs e)
        {

            if (dataGridView1.Rows.Count != 0)
            {
                DateTime Date = dateTimePicker2.Value.Date.AddDays(30);
                dataGridView1.DataSource = Gsc.Conges.Where(s => s.DateDebut >= dateTimePicker2.Value.Date && s.DateDebut <= Date).Select(c => new {
                    Matricule = c.GesEmploye.Matricule,
                    Nom = c.GesEmploye.Nom,
                    Prenom = c.GesEmploye.Prenom,
                    Type_Congé = c.TypeConge,
                    Durée = c.Duree,
                    Date_Debut = c.DateDebut,
                    Date_Final = c.DateFin
                }).ToList();
            }
           
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            Gestion_Conge f = new Gestion_Conge();
            f.ShowDialog();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Hide();
            Gestion_Employe f = new Gestion_Employe();
            f.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int MultiSelect = 0;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {

                if (Convert.ToBoolean(row.Cells[0].Value) == true)
                {
                    MultiSelect++;
                }
            }
            if (MultiSelect == 0)
            {
                MessageBox.Show("Selectionner Congé");
            }
            else
            {
                DialogResult R = MessageBox.Show("veulez Vous vraiment supprimer", "supprimer", MessageBoxButtons.YesNo);
                if (R == DialogResult.Yes)
                {
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value) == true)
                        {
                           GConges.SupprimerConge(int.Parse(row.Cells[1].Value.ToString()));
                        }
                    }
                   
                    dataGridView1.DataSource = Gsc.Conges.Select(c => new {
                        Matricule = c.GesEmploye.Matricule,
                        Nom = c.GesEmploye.Nom,
                        Prenom = c.GesEmploye.Prenom,
                        Type_Congé = c.TypeConge,
                        Durée = c.Duree,
                        Date_Debut = c.DateDebut,
                        Date_Final = c.DateFin
                    }).ToList();
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Minimized;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.Hide();
           Ajoute_User f = new Ajoute_User();
            f.ShowDialog();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f = new Form1();
         //   f.activateControls();
            f.ShowDialog();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Hide();
            StockConge f = new StockConge();
            f.ShowDialog();

        }
    }
}
