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
using System.Data.OleDb;
using System.Runtime.InteropServices;

namespace projetoImobiliaria.Conta
{
    public partial class Conta : Form
    {
        [DllImport("Gdi32.dLL", EntryPoint = "CreateRoundRectRgn")]

        private static extern IntPtr CreateRoundRectRgn

        (
        int nLeftRect,
        int nTopRect,
        int nRightRect,
        int nBottomRect,
        int nWithEllipse,
        int nHeightEllipse
        );

        public Conta()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
        }

        private void Conta_Load(object sender, EventArgs e)
        {
            this.ActiveControl = exit_btn;
            
        }

        private void login_btn_Click(object sender, EventArgs e)
        {
            if (user_tb.Text == "Username" && password_tb.Text == "Password")
            {
                //MessageBox.Show("Introduza os dados de acesso");
                globais.ADM = true;
                main f1 = new main();
                f1.Show();
            }

            DataTable dt = BLL.Login.login_info_request(user_tb.Text, password_tb.Text);

            if(dt.Rows.Count > 0)
            {
                globais.ADM = (bool)dt.Rows[0][3];
                main f1 = new main();
                f1.Show();
            }


        }

        private void user_tb_Leave(object sender, EventArgs e)
        {
            if (user_tb.Text == "")
            {
                user_tb.Text = "Username";
            }
        }

        private void password_tb_Enter(object sender, EventArgs e)
        {
            if (password_tb.Text == "Password")
            {
                password_tb.Text = "";
            }
        }

        private void password_tb_Leave(object sender, EventArgs e)
        {
            if (password_tb.Text == "")
            {
                password_tb.Text = "Password";
                password_tb.UseSystemPasswordChar = false;
            }
        }

        private void user_tb_Enter(object sender, EventArgs e)
        {
            if (user_tb.Text == "Username")
            {
                user_tb.Text = "";
            }
        }

        private void password_tb_TextChanged(object sender, EventArgs e)
        {
            password_tb.UseSystemPasswordChar = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
