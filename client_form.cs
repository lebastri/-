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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Курсовая
{
    public partial class client_form : Form
    {
        public client_form()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = new MySqlConnection(@"Server=localhost;port=3306;Database=computer_and_office_equipment;username=monty;password=some_pass");
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            if (radioButton2.Checked)
            {
                cmd.CommandText = $"SELECT `Request ID` AS `Номер заявки`, `User ID` AS `Код користувача`, `Product ID` AS `Код товару`, `Quantity` AS `Кількість`, `Status` AS `Статус` FROM `заявки` WHERE `User ID` = {User_info.id} AND `Request ID` = {textBox1.Text}";
                try
                {
                    DataTable table = new DataTable();
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    adapter.Fill(table);
                    dataGridView1.DataSource = table;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Помилка!");
                }
            }
            else
            {
                cmd.CommandText = $"SELECT `Request ID` AS `Номер заявки`, `User ID` AS `Код користувача`, `Product ID` AS `Код товару`, `Quantity` AS `Кількість`, `Status` AS `Статус` FROM `заявки` WHERE `User ID` = {User_info.id};";
                try
                {
                    DataTable table = new DataTable();
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    adapter.Fill(table);
                    dataGridView1.DataSource = table;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Помилка!");
                }
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked) { textBox1.Enabled = true; }
            else { textBox1.Enabled = false; }
        }

        private void client_form_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = new MySqlConnection(@"Server=localhost;port=3306;Database=computer_and_office_equipment;username=monty;password=some_pass");
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = $"SELECT `Product ID` AS `Код товару`, `Price` AS `Ціна`, `Amount` AS `Кількість` FROM `прайс-лист` WHERE `User ID` = {User_info.id};";
            try
            {
                DataTable table = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(table);
                dataGridView2.DataSource = table;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            application application = new application();
            application.Show();
        }
    }
}
