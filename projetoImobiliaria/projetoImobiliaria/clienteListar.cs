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
    public partial class clienteListar : Form
    {
        public clienteListar()
        {
            InitializeComponent();
        }

        private void clienteListar_Load(object sender, EventArgs e)
        {
            DataTable dt = BLL.Clientes.Load();

            dataGridView1.DataSource = dt;

            dataGridView1.RowTemplate.MinimumHeight = 35;

            dataGridView1.RowHeadersWidth = 4;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGrid1_Navigate(object sender, NavigateEventArgs ne)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = BLL.Clientes.PesquisarCliente(textBox1.Text);
        }
    }
}
