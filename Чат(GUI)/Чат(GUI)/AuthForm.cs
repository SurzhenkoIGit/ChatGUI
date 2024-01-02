using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Чат_GUI_
{
    public partial class AuthForm : Form
    {
        Database database = new Database();
        public AuthForm()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void AuthForm_Load(object sender, EventArgs e)
        {
            txb_Pass.PasswordChar = '*';
            txb_Log.MaxLength = 50;
            txb_Pass.MaxLength = 50;
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            var logUser = txb_Log.Text;
            var passUser = txb_Pass.Text;

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();

            string queryStr = $"select id, login_user, password_user from auth_db where login_user = '{logUser}' and password_user = '{passUser}'";

            SqlCommand command = new SqlCommand(queryStr, database.GetConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if(table.Rows.Count == 1 ) 
            {
                MessageBox.Show("Вы успешно вошли!", "Успех!", MessageBoxButtons.OK);
                this.Hide();
                Form1 fr = new Form1();
                fr.ShowDialog();
            }
            else
            {
                MessageBox.Show("Ошибка авторизации пользователя!", "Ошибка!", MessageBoxButtons.OK);
            }
        }



        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RegForm reg = new RegForm();
            reg.ShowDialog();
            this.Hide();
        }
    }
}
