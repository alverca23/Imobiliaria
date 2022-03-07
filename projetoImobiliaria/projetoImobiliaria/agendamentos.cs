using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLogicLayer;


namespace projetoImobiliaria
{
    public partial class agendamentos : Form
    {
        int num;
        public agendamentos()
        {
            InitializeComponent();
        }

        private void agendamentos_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = BLL.Agendamentos.Load();
            this.Size = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height); 
            dataGridView1.RowTemplate.MinimumHeight = 35;
            dataGridView1.RowHeadersWidth = 4;

            comboBox1.DataSource = BLL.Funcionarios.Load_Nomes(); // mesmo principio da dataGridView
            comboBox1.DisplayMember = "Nome"; // nome da coluna, em principio é nome
            comboBox1.SelectedIndex = -1; // para não vir com nomes selecionados
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                                       
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["Data"].Value.ToString();
                textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells["Data"].Value.ToString();
                textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells["Data"].Value.ToString();
                textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells["Horas"].Value.ToString();
                textBox6.Text = dataGridView1.Rows[e.RowIndex].Cells["Horas"].Value.ToString();
                comboBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["Funcionario"].Value.ToString();
                textBox8.Text = dataGridView1.Rows[e.RowIndex].Cells["Localidade"].Value.ToString();

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox2.Text) || String.IsNullOrEmpty(textBox2.Text) || String.IsNullOrEmpty(textBox3.Text) || String.IsNullOrEmpty(textBox4.Text) || String.IsNullOrEmpty(textBox5.Text) || String.IsNullOrEmpty(textBox6.Text) || String.IsNullOrEmpty(comboBox1.Text) || String.IsNullOrEmpty(textBox8.Text))
            {
                MessageBox.Show("Tem de preencher os campos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {

            // DATA
            DateTime data = new DateTime(
                Convert.ToInt32(textBox4.Text),
                Convert.ToInt32(textBox3.Text),
                Convert.ToInt32(textBox2.Text)
            );

            // HORAS
            TimeSpan horas = new TimeSpan(
                Convert.ToInt32(textBox5.Text),
                Convert.ToInt32(textBox6.Text),
                0
            );
            
            // FUNCIONARIO
            string funcionario = comboBox1.Text;
            // LOCALIDADE
            string localidade = textBox8.Text;


            Random rnd = new Random();
            num = rnd.Next(10000000, 99999999);

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (Convert.ToInt32(row.Cells[0].Value) == num)
                {
                    num = rnd.Next(10000000, 99999999);
                }
            }

            BLL.Calendario.Inserir_Data(num, Convert.ToDateTime(data).ToShortDateString(), new DateTime(horas.Ticks).ToString("HH:mm"), funcionario, localidade);

            dataGridView1.DataSource = BLL.Calendario.Load_Agendamentos();

                foreach (var txtitem in this.Controls.OfType<TextBox>())
                {
                  txtitem.Clear();                   
                }

                comboBox1.SelectedIndex = -1;

            }
        }
    }
}
