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
    
    public partial class RegForm : Form
    {
        Database database = new Database();
        public RegForm()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void btn_Create_Click(object sender, EventArgs e)
        {
            
            var login = txb_Log.Text;
            var pass = txb_Pass.Text;

            string queryStr = $"insert into auth_db(login_user, password_user) values('{login}', '{pass}')";

            SqlCommand command = new SqlCommand(queryStr, database.GetConnection());

            database.openConnection();

            if(command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Аккаунт создан!", "Успех!", MessageBoxButtons.OK);
                AuthForm auth = new AuthForm();
                this.Hide();
                auth.ShowDialog();
            }
            else
            {
                MessageBox.Show("Аккаунт не создан!");
            }
            database.closeConnection();
        }

        private bool checkUser()
        {
            var login = txb_Log.Text;
            var password = txb_Pass.Text;

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();

            string queryStr = $"select login_user, password_user from auth_db where login_user = '{login}' and password_user = '{password}'";

            SqlCommand command = new SqlCommand(queryStr, database.GetConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);
            if(table.Rows.Count > 0)
            {
                MessageBox.Show("Пользователь уже существует!", "Предупреждение!");
                return true;
            }
            else
            {
                return false;
            }
        }

        private void RegForm_Load(object sender, EventArgs e)
        {
            txb_Pass.PasswordChar = '*';
            txb_Log.MaxLength = 50;
            txb_Pass.MaxLength = 50;
        }
    }
}
