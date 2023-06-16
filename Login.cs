using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Курсовая
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        

        private void logbtn_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = new MySqlConnection(@"Server=localhost;port=3306;Database=computer_and_office_equipment;username=monty;password=some_pass");
            int a;
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from пользователи where `User ID` = '" + logintxtbox.Text+"' and Password = '"+passtxtbox.Text+ "' and Role in ('Менеджери', 'Продавці', 'Комірники')";
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(table);
            a = Convert.ToInt32(table.Rows.Count.ToString());
            if (a == 0)
            {
                cmd.CommandText = "select * from пользователи where `User ID` = '" + logintxtbox.Text + "' and Password = '" + passtxtbox.Text + "' and Role in ('Клієнти')";
                MySqlDataAdapter adapter2 = new MySqlDataAdapter(cmd);
                adapter2.Fill(table);
                a = Convert.ToInt32(table.Rows.Count.ToString());
                if (a == 0)
                {
                    MessageBox.Show("Такого користувача нема");
                }
                else
                {
                    User_info.id = logintxtbox.Text;
                    this.Hide();
                    client_form client_Form = new client_form();
                    client_Form.Show();
                }
            }
            else
            {
                this.Hide();
                database database = new database();
                database.Show();
            }
            connection.Close();
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }

        private void regbtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            dropbox reg = new dropbox();
            reg.Show();
        }
    }
}
