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
    public partial class application : Form
    {
        public application()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            MySqlConnection connection = new MySqlConnection(@"Server=localhost;port=3306;Database=computer_and_office_equipment;username=monty;password=some_pass");
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = $"INSERT INTO `заявки` (`Request ID`, `User ID`, `Product ID`, `Quantity`, `Status`) VALUES ({random.Next(500)}, {User_info.id}, {comboBox1.Text}, {textBox1.Text}, 'В обробці');";
            try
            {
                DataTable table = new DataTable();
                DataTable table2 = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(table);
                cmd.CommandText = $"INSERT INTO `прайс-лист` (`User ID`, `Product ID`, `Price`, `Amount`) SELECT {User_info.id}, {comboBox1.Text}, t.`Price`, {textBox1.Text} FROM `товары` t WHERE t.`Product ID` = {comboBox1.Text};";
                adapter.SelectCommand = cmd;
                adapter.Fill(table2);
                MessageBox.Show("Заявка створена успішно!", "");
                this.Hide();
                client_form client= new client_form();
                client.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка!");
            }
        }

        private void application_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }
    }
}
