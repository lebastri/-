using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace Курсовая
{
    public partial class database : Form
    {
        public database()
        {
            InitializeComponent();
        }



        private void database_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = new MySqlConnection(@"Server=localhost;port=3306;Database=computer_and_office_equipment;username=monty;password=some_pass");
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            string command_sql = "select * from пользователи";
            if (checkBox1.Checked || checkBox2.Checked || checkBox3.Checked)
            {
                command_sql += " where";
            }

            if (checkBox1.Checked)
            {
                command_sql += $" `User ID` = '{findUserID.Text}'";
            }

            if (checkBox2.Checked)
            {
                if (checkBox1.Checked)
                {
                    command_sql += $" AND `Name` = '{findName.Text}'";
                }
                else
                {
                    command_sql += $" `Name` = '{findName.Text}'";
                }
            }

            if (checkBox3.Checked)
            {
                if (checkBox1.Checked || checkBox2.Checked)
                {
                    command_sql += $" AND `Role` = '{comboBox1.Text}'";
                }
                else
                {
                    command_sql += $" `Role` = '{comboBox1.Text}'";
                }
            }
            cmd.CommandText = command_sql;
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked) { findUserID.Enabled = true; }
            else { findUserID.Enabled = false; }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked) { findName.Enabled = true; }
            else { findName.Enabled = false; }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked) { comboBox1.Enabled = true; }
            else { comboBox1.Enabled = false; }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || comboBox2.Text == "")
            {
                MessageBox.Show("Заповніть усі поля");
            }
            else
            {
                MySqlConnection connection = new MySqlConnection(@"Server=localhost;port=3306;Database=computer_and_office_equipment;username=monty;password=some_pass");
                connection.Open();
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = $"INSERT INTO Пользователи (`User ID`, `Name`, `Password`, `Role`) VALUES ('{textBox3.Text}', '{textBox4.Text}', '{textBox5.Text}', '{comboBox2.Text}');";
                try
                {
                    DataTable table = new DataTable();
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    adapter.Fill(table);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Помилка!");
                }
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == "" || textBox5.Text == "")
            {
                MessageBox.Show("Заповніть усі поля");
            }
            else
            {
                MySqlConnection connection = new MySqlConnection(@"Server=localhost;port=3306;Database=computer_and_office_equipment;username=monty;password=some_pass");
                connection.Open();
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = $"DELETE FROM Пользователи WHERE `User ID` = '{textBox3.Text}' AND `Password` = '{textBox5.Text}';";
                try
                {
                    DataTable table = new DataTable();
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    adapter.Fill(table);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Помилка!");
                }
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || comboBox2.Text == "")
            {
                MessageBox.Show("Заповніть усі поля");
            }
            else
            {
                MySqlConnection connection = new MySqlConnection(@"Server=localhost;port=3306;Database=computer_and_office_equipment;username=monty;password=some_pass");
                connection.Open();
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = $"UPDATE Пользователи SET `Name` = '{textBox4.Text}', `Password` = '{textBox5.Text}', `Role` = '{comboBox2.Text}' WHERE `User ID` = '{textBox3.Text}';";
                try
                {
                    DataTable table = new DataTable();
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    adapter.Fill(table);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Помилка!");
                }
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = new MySqlConnection(@"Server=localhost;port=3306;Database=computer_and_office_equipment;username=monty;password=some_pass");
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            string command_sql = "SELECT * FROM Товары";
            if (checkBox4.Checked || checkBox5.Checked || checkBox6.Checked || checkBox7.Checked)
            {
                command_sql += " where";
            }

            if (checkBox4.Checked)
            {
                command_sql += $" `Product ID` = '{textBox1.Text}'";
            }

            if (checkBox5.Checked)
            {
                if (checkBox4.Checked)
                {
                    command_sql += $" AND `Name` = '{textBox2.Text}'";
                }
                else
                {
                    command_sql += $" `Name` = '{textBox2.Text}'";
                }
            }

            if (checkBox6.Checked)
            {
                if (checkBox5.Checked || checkBox4.Checked)
                {
                    command_sql += $" AND `Category` = '{textBox8.Text}'";
                }
                else
                {
                    command_sql += $" `Category` = '{textBox8.Text}'";
                }
            }

            if (checkBox7.Checked)
            {
                if (checkBox5.Checked || checkBox4.Checked || checkBox6.Checked)
                {
                    command_sql += $" AND `Price` = '{textBox7.Text}'";
                }
                else
                {
                    command_sql += $" `Price` = '{textBox7.Text}'";
                }
            }
            cmd.CommandText = command_sql;
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(table);
            dataGridView2.DataSource = table;
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked) { textBox1.Enabled = true; }
            else { textBox1.Enabled = false; }
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked) { textBox2.Enabled = true; }
            else { textBox2.Enabled = false; }
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox6.Checked) { textBox8.Enabled = true; }
            else { textBox8.Enabled = false; }
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox7.Checked) { textBox7.Enabled = true; }
            else { textBox7.Enabled = false; }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox11.Text == "" || textBox10.Text == "" || textBox6.Text == "" || textBox9.Text == "")
            {
                MessageBox.Show("Заповніть усі поля");
            }
            else
            {
                MySqlConnection connection = new MySqlConnection(@"Server=localhost;port=3306;Database=computer_and_office_equipment;username=monty;password=some_pass");
                connection.Open();
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = $"INSERT INTO Товары (`Product ID`, `Name`, `Category`, `Price`, `Description`) VALUES ('{textBox11.Text}', '{textBox10.Text}', '{textBox6.Text}', '{textBox9.Text}', '{textBox12.Text}');";
                try
                {
                    DataTable table = new DataTable();
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    adapter.Fill(table);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Помилка!");
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (textBox11.Text == "" || textBox10.Text == "" || textBox6.Text == "" || textBox9.Text == "")
            {
                MessageBox.Show("Заповніть усі поля");
            }
            else
            {
                MySqlConnection connection = new MySqlConnection(@"Server=localhost;port=3306;Database=computer_and_office_equipment;username=monty;password=some_pass");
                connection.Open();
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = $"UPDATE Товары SET `Name` = '{textBox10.Text}', `Category` = '{textBox6.Text}', `Price` = '{textBox9.Text}', `Description` = '{textBox12.Text}' WHERE `Product ID` = {textBox11.Text};";
                try
                {
                    DataTable table = new DataTable();
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    adapter.Fill(table);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Помилка!");
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (textBox11.Text == "")
            {
                MessageBox.Show("Заповніть поле Product ID");
            }
            else
            {
                MySqlConnection connection = new MySqlConnection(@"Server=localhost;port=3306;Database=computer_and_office_equipment;username=monty;password=some_pass");
                connection.Open();
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = $"DELETE FROM Товары WHERE `Product ID` = {textBox11.Text};";
                try
                {
                    DataTable table = new DataTable();
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    adapter.Fill(table);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Помилка!");
                }
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = new MySqlConnection(@"Server=localhost;port=3306;Database=computer_and_office_equipment;username=monty;password=some_pass");
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = textBox13.Text == "" ? "select * from клиенты" : $"select * from клиенты where `User ID` = {textBox13.Text};";
            try
            {
                DataTable table = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(table);
                dataGridView4.DataSource = table;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка!");
            }
            
        }

        private void button14_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = new MySqlConnection(@"Server=localhost;port=3306;Database=computer_and_office_equipment;username=monty;password=some_pass");
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = $"INSERT INTO `клиенты` (`User ID`, `Name`, `Address`, `Contact Information`) VALUES ('{textBox15.Text}', '{textBox23.Text}', '{textBox19.Text}', '{textBox22.Text}');";
            try
            {
                DataTable table = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(table);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка!");
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (textBox15.Text == "")
            {
                MessageBox.Show("Заповніть поле User ID");
            }
            else
            {
                MySqlConnection connection = new MySqlConnection(@"Server=localhost;port=3306;Database=computer_and_office_equipment;username=monty;password=some_pass");
                connection.Open();
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = $"DELETE FROM `клиенты` WHERE `User ID` = {textBox15.Text};";
                try
                {
                    DataTable table = new DataTable();
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    adapter.Fill(table);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Помилка!");
                }
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = new MySqlConnection(@"Server=localhost;port=3306;Database=computer_and_office_equipment;username=monty;password=some_pass");
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = $"UPDATE `клиенты` SET `Name` = '{textBox23.Text}', `Address` = '{textBox19.Text}', `Contact Information` = '{textBox22.Text}' WHERE `User ID` = {textBox15.Text};";
            try
            {
                DataTable table = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(table);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка!");
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = new MySqlConnection(@"Server=localhost;port=3306;Database=computer_and_office_equipment;username=monty;password=some_pass");
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = $"INSERT INTO `поставки` (`Supply ID`, `Product ID`, `Quantity`, `Supply Date`) VALUES ({textBox14.Text}, {textBox16.Text}, {textBox17.Text}, '{dateTimePicker1.Value.Date.ToString("dd.MM.yyyy")}');";
            try
            {
                DataTable table = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(table);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка!");
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            DateTime date = dateTimePicker1.Value.Date;
            MySqlConnection connection = new MySqlConnection(@"Server=localhost;port=3306;Database=computer_and_office_equipment;username=monty;password=some_pass");
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = $"UPDATE `поставки` SET `Product ID` = {textBox16.Text}, `Quantity` = {textBox17.Text}, `Supply Date` = '{date.ToString("yyyy-MM-dd")}' WHERE `Supply ID` = {textBox14.Text};";
            try
            {
                DataTable table = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(table);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка!");
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = new MySqlConnection(@"Server=localhost;port=3306;Database=computer_and_office_equipment;username=monty;password=some_pass");
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = $"DELETE FROM `поставки` WHERE `Supply ID` = 2;";
            try
            {
                DataTable table = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(table);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка!");
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = new MySqlConnection(@"Server=localhost;port=3306;Database=computer_and_office_equipment;username=monty;password=some_pass");
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = textBox18.Text == "" ? "select * from поставки" : $"select * from поставки where `Supply ID` = {textBox18.Text};";
            try
            {
                DataTable table = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(table);
                dataGridView5.DataSource = table;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка!");
            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = new MySqlConnection(@"Server=localhost;port=3306;Database=computer_and_office_equipment;username=monty;password=some_pass");
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = textBox26.Text == "" ? "select * from `отпуск товаров`" : $"select * from `отпуск товаров` where `Sales ID` = {textBox26.Text};";
            try
            {
                DataTable table = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(table);
                dataGridView6.DataSource = table;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка!");
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = new MySqlConnection(@"Server=localhost;port=3306;Database=computer_and_office_equipment;username=monty;password=some_pass");
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = $"INSERT INTO `отпуск товаров` (`Sales ID`, `Product ID`, `User ID`, `Quantity`, `Sales Date`) VALUES ({textBox20.Text}, {textBox24.Text}, {textBox21.Text}, {textBox25.Text}, '{dateTimePicker2.Value.Date.ToString("yyyy-MM-dd")}');";
            try
            {
                DataTable table = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(table);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка!");
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = new MySqlConnection(@"Server=localhost;port=3306;Database=computer_and_office_equipment;username=monty;password=some_pass");
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = $"UPDATE `отпуск товаров` SET `Product ID` = {textBox24.Text}, `User ID` = {textBox21.Text}, `Quantity` = {textBox25.Text}, `Sales Date` = '{dateTimePicker2.Value.Date.ToString("yyyy-MM-dd")}' WHERE `Sales ID` = {textBox20.Text};";
            try
            {
                DataTable table = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(table);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка!");
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = new MySqlConnection(@"Server=localhost;port=3306;Database=computer_and_office_equipment;username=monty;password=some_pass");
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = $"DELETE FROM `отпуск товаров` WHERE `Sales ID` = {textBox20.Text};";
            try
            {
                DataTable table = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(table);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка!");
            }
        }

        private void button21_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = new MySqlConnection(@"Server=localhost;port=3306;Database=computer_and_office_equipment;username=monty;password=some_pass");
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = textBox27.Text == "" ? "select * from `заявки`" : $"select * from `заявки` where `Request ID` = {textBox27.Text};";
            try
            {
                DataTable table = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(table);
                dataGridView7.DataSource = table;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка!");
            }
        }

        private void button24_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = new MySqlConnection(@"Server=localhost;port=3306;Database=computer_and_office_equipment;username=monty;password=some_pass");
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = $"INSERT INTO `заявки` (`Request ID`, `User ID`, `Product ID`, `Quantity`, `Status`) VALUES ({textBox31.Text}, {textBox30.Text}, {textBox29.Text}, {textBox28.Text}, '{textBox32.Text}');";
            try
            {
                DataTable table = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(table);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка!");
            }
        }

        private void button23_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = new MySqlConnection(@"Server=localhost;port=3306;Database=computer_and_office_equipment;username=monty;password=some_pass");
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = $"UPDATE `заявки` SET `Product ID` = {textBox29.Text}, `Quantity` = {textBox28.Text}, `Status` = '{textBox32.Text}' WHERE `Request ID` = {textBox31.Text};";
            try
            {
                DataTable table = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(table);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка!");
            }
        }

        private void button22_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = new MySqlConnection(@"Server=localhost;port=3306;Database=computer_and_office_equipment;username=monty;password=some_pass");
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = $"DELETE FROM `заявки` WHERE `Request ID` = {textBox31.Text};";
            try
            {
                DataTable table = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(table);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка!");
            }
        }

        private void button28_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = new MySqlConnection(@"Server=localhost;port=3306;Database=computer_and_office_equipment;username=monty;password=some_pass");
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            if (textBox39.Text == "" && textBox38.Text == "")
            {
                cmd.CommandText = "select * from `комплектация`";
            }
            else if (textBox39.Text == "" && !(textBox38.Text == ""))
            {
                cmd.CommandText = $"select * from `комплектация` where `Request ID` = {textBox38.Text};";
            }
            else if (!(textBox39.Text == "") && textBox38.Text == "")
            {
                cmd.CommandText = $"select * from `комплектация` where `Assembly ID` = {textBox39.Text};";
            }
            else
            {
                cmd.CommandText = $"select * from `комплектация` where `Request ID` = {textBox38.Text} and `Assembly ID` = {textBox39.Text};";
            }
            try
            {
                DataTable table = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(table);
                dataGridView8.DataSource = table;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка!");
            }
        }

        private void button27_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = new MySqlConnection(@"Server=localhost;port=3306;Database=computer_and_office_equipment;username=monty;password=some_pass");
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = $"INSERT INTO `комплектация` (`Assembly ID`, `Request ID`, `Category`, `Quantity`) VALUES ({textBox37.Text}, {textBox35.Text}, '{textBox36.Text}', {textBox34.Text});";
            try
            {
                DataTable table = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(table);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка!");
            }
        }

        private void button26_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = new MySqlConnection(@"Server=localhost;port=3306;Database=computer_and_office_equipment;username=monty;password=some_pass");
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = $"UPDATE `комплектация` SET `Request ID` = {textBox35.Text}, `Category` = '{textBox36.Text}', `Quantity` = {textBox34.Text} WHERE `Assembly ID` = {textBox37.Text};";
            try
            {
                DataTable table = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(table);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка!");
            }
        }

        private void button25_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = new MySqlConnection(@"Server=localhost;port=3306;Database=computer_and_office_equipment;username=monty;password=some_pass");
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = $"DELETE FROM `комплектация` WHERE `Assembly ID` = {textBox37.Text};";
            try
            {
                DataTable table = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(table);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка!");
            }
        }

        private void button29_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = new MySqlConnection(@"Server=localhost;port=3306;Database=computer_and_office_equipment;username=monty;password=some_pass");
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = textBox33.Text == "" ? "select * from `прайс-лист`" : $"select * from `прайс-лист` where `User ID` = {textBox33.Text};";
            try
            {
                DataTable table = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(table);
                dataGridView9.DataSource = table;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка!");
            }
        }

        private void button32_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = new MySqlConnection(@"Server=localhost;port=3306;Database=computer_and_office_equipment;username=monty;password=some_pass");
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = $"INSERT INTO `прайс-лист` (`User ID`, `Product ID`, `Price`, `Amount`) VALUES ({textBox43.Text}, {textBox40.Text}, {textBox42.Text}, {textBox41.Text});";
            try
            {
                DataTable table = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(table);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка!");
            }
        }

        private void button31_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = new MySqlConnection(@"Server=localhost;port=3306;Database=computer_and_office_equipment;username=monty;password=some_pass");
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = $"UPDATE `прайс-лист` SET `Price` = {textBox42.Text}, `Amount` = {textBox41.Text} WHERE `User ID` = {textBox43.Text} AND `Product ID` = {textBox40.Text};";
            try
            {
                DataTable table = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(table);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка!");
            }
        }

        private void button30_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = new MySqlConnection(@"Server=localhost;port=3306;Database=computer_and_office_equipment;username=monty;password=some_pass");
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = $"DELETE FROM `прайс-лист` WHERE `User ID` = {textBox43.Text} AND `Product ID` = {textBox40.Text};";
            try
            {
                DataTable table = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(table);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка!");
            }
        }
    }
}
