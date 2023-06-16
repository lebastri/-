using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Курсовая
{
    public partial class dropbox : Form
    {
        public dropbox()
        {
            InitializeComponent();
        }

        private void regbtn_Click(object sender, EventArgs e)
        {
            string script = ($"insert into Пользователи values('{idtxtbox.Text}','{nametxtbox.Text}','{passtxtbox.Text}','Клієнт')");
            string connString = @"Server=localhost;port=3306;Database=computer_and_office_equipment;username=monty;password=some_pass";

            int I = 0;
            using (MySqlConnection connection = new MySqlConnection(connString))
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(script, connection);
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataTable table = new DataTable();
                adapter.Fill(table);
                if (I == 0)
                {
                    MessageBox.Show("Регестрація пройшла успішно!");
                }
                else
                {
                    this.Hide();
                    Login mp = new Login();
                    mp.Show();
                    MessageBox.Show("Регестрація пройшла успішно!");
                    this.Hide();
                    Login login = new Login();
                    login.Show();
                }
                connection.Close();
            }
        }

        private void reg_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }

        private void logbtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.Show();
        }
    }
}
