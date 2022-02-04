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
    public partial class ClienteEditar : Form
    {
        public ClienteEditar()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void ClienteEditar_Load(object sender, EventArgs e)
        {
            this.Size = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            

            dataGridView1.DataSource = BLL.Clientes.Load(); 

            dataGridView1.RowTemplate.MinimumHeight = 35;

            dataGridView1.RowHeadersWidth = 4;
 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text) || String.IsNullOrEmpty(textBox2.Text) || String.IsNullOrEmpty(textBox3.Text) || String.IsNullOrEmpty(textBox4.Text) || String.IsNullOrEmpty(textBox5.Text) || String.IsNullOrEmpty(textBox6.Text) || String.IsNullOrEmpty(textBox7.Text) || String.IsNullOrEmpty(textBox7.Text))   
            {
                MessageBox.Show("Tem de preencher todos os campos", "Informação");
            }
            else
            {
                DialogResult r = MessageBox.Show("Tem a certeza que pretende alterar as informações?", "Confirmação");

                if (r == DialogResult.OK)
                {
                    BLL.Clientes.Update_Cliente(Convert.ToInt32(textBox1.Text), textBox2.Text, textBox3.Text, textBox4.Text, textBox8.Text, Convert.ToInt32(textBox7.Text), Convert.ToInt32(textBox6.Text), textBox5.Text);

                    dataGridView1.DataSource = BLL.Clientes.Load();

                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();
                    textBox5.Clear();
                    textBox6.Clear();
                    textBox7.Clear();
                    textBox8.Clear();
                }
            }       
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["Id"].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["Nome"].Value.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells["Sobrenome"].Value.ToString();
            textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells["Morada"].Value.ToString();
            textBox8.Text = dataGridView1.Rows[e.RowIndex].Cells["Email"].Value.ToString();
            textBox7.Text = dataGridView1.Rows[e.RowIndex].Cells["Telefone"].Value.ToString();
            textBox6.Text = dataGridView1.Rows[e.RowIndex].Cells["NIF"].Value.ToString();
            textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells["Localidade"].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool existe = false;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (Convert.ToInt32(row.Cells[0].Value) == Convert.ToInt32(textBox1.Text))
                {
                    MessageBox.Show("Já existe um utilizador com esse ID", "Erro");

                    existe = true;

                    textBox1.Clear();
                }
               
            }
               if (!existe) 
               {
                    MessageBox.Show("Pretende prosseguir?", "Sistema");

                    BLL.Clientes.insertCliente(Convert.ToInt32(textBox1.Text), textBox2.Text, textBox3.Text, textBox4.Text, textBox8.Text, Convert.ToInt32(textBox7.Text), Convert.ToInt32(textBox6.Text), textBox5.Text);

                    dataGridView1.DataSource = BLL.Clientes.Load();

                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();
                    textBox5.Clear();
                    textBox6.Clear();
                    textBox7.Clear();
                    textBox8.Clear();
               }
            
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Tem a certeza que pretende eliminar este cliente?", "Confirmação", MessageBoxButtons.YesNo);
            
            if (r == DialogResult.Yes)
            {
                BLL.Clientes.Desativar_Cliente(Convert.ToInt32(textBox1.Text));

                dataGridView1.DataSource = BLL.Clientes.Load();
            }
             
        }
    }
}
