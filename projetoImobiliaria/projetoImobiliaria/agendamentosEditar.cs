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
    public partial class agendamentose: Form
    {
        int num;
        public agendamentose()
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
                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["Id"].Value.ToString();
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["Data"].Value.ToString();
                textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells["Horas"].Value.ToString();
                comboBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["Funcionario"].Value.ToString();
                textBox8.Text = dataGridView1.Rows[e.RowIndex].Cells["Localidade"].Value.ToString();
               
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
  
        private void button1_Click_1(object sender, EventArgs e)
        {
            BLL.Agendamentos.Atualizar_agendamentos(Convert.ToInt32(textBox1.Text), textBox2.Text,textBox5.Text, comboBox1.Text, textBox8.Text);

            dataGridView1.DataSource = BLL.Agendamentos.Load();

            foreach (var txtitem in this.Controls.OfType<TextBox>())
            {
                txtitem.Clear();
            }
            comboBox1.SelectedIndex = -1;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            BLL.Agendamentos.delete_agendamento(Convert.ToInt32(textBox1.Text), textBox2.Text, textBox5.Text, comboBox1.Text, textBox8.Text);

            dataGridView1.DataSource = BLL.Agendamentos.Load();

            foreach (var txtitem in this.Controls.OfType<TextBox>())
            {
                txtitem.Clear();
            }
            comboBox1.SelectedIndex = -1;
        }
    }
}
