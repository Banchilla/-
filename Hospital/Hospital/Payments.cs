using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Hospital
{
    public partial class Payments : Form
    {
        public Payments()
        {
            InitializeComponent();
        }

        private ClassProvide _db;
        string id;


        private void Payments_Load(object sender, EventArgs e)
        {
            _db = ClassProvide.GetInstance();
            SQLiteConnection conn = _db.GetConnection();
            string query = "SELECT payment_id, Patients.last_name as lnp, amount, payment_date, payment_method FROM Payments INNER JOIN Patients ON Payments.patient_id = Patients.patient_id";
            SQLiteCommand cmd = new SQLiteCommand(query, conn);
            SQLiteDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                dataGridView1.Rows.Add(reader["payment_id"], reader["lnp"], reader["amount"], reader["payment_date"], reader["payment_method"]);
            }

            _db = ClassProvide.GetInstance();
            SQLiteConnection conn1 = _db.GetConnection();
            string query1 = "SELECT DISTINCT last_name FROM Patients";
            SQLiteCommand cmd1 = new SQLiteCommand(query1, conn1);
            SQLiteDataReader reader1 = cmd1.ExecuteReader();
            while (reader1.Read())
            {
                string data = reader1.GetString(0);
                comboBox1.Items.Add(data);
            }

            comboBox2.Items.Add("Наличные");
            comboBox2.Items.Add("Кредитная карта");
            comboBox2.Items.Add("Страхование");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                _db = ClassProvide.GetInstance();
                SQLiteConnection conn = _db.GetConnection();
                string id = dataGridView1.SelectedRows[0].Cells["Column1"].Value.ToString();
                string sql = "DELETE FROM Payments WHERE payment_id = @id";
                SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                dataGridView1.Refresh();
                MessageBox.Show("Запись удалена из базы!");
            }
            else
            {
                MessageBox.Show("Выберите запись для удаления!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string pc = comboBox1.Text;
            string am = textBox1.Text;
            string pd = dateTimePicker1.Text;
            string pm = comboBox2.Text;


            if (string.IsNullOrEmpty(pc) || string.IsNullOrEmpty(am) || string.IsNullOrEmpty(pd) || string.IsNullOrEmpty(pm))
            {
                MessageBox.Show("Заполните все поля!");
            }
            else if (!Regex.IsMatch(pc, "^[а-яА-Я -]+$"))
            {
                MessageBox.Show("Заполните Пациента правильно!");
            }
            else if (!Regex.IsMatch(am, "^[0-9 -]+$"))
            {
                MessageBox.Show("Заполните Сумму правильно!");
            }
            else if (!Regex.IsMatch(pd, "^[0-9а-яА-Я .-]+$"))
            {
                MessageBox.Show("Заполните Дату оплаты правильно!");
            }
            else if (!Regex.IsMatch(pm, "^[а-яА-Я -]+$"))
            {
                MessageBox.Show("Заполните Способ оплаты правильно!");
            }
            else
            {
                _db = ClassProvide.GetInstance();
                SQLiteConnection conn = _db.GetConnection();
                string query = "INSERT INTO Payments (patient_id, amount, payment_date, payment_method) \r\nVALUES ((SELECT patient_id FROM Patients WHERE last_name = @pc), @am, @pd, @pm);";
                SQLiteCommand command = new SQLiteCommand(query, conn);
                command.Parameters.AddWithValue("@pc", pc);
                command.Parameters.AddWithValue("@am", am);
                command.Parameters.AddWithValue("@pd", pd);
                command.Parameters.AddWithValue("@pm", pm);
                command.ExecuteNonQuery();
                MessageBox.Show("Запись добавлена в базу!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(comboBox1.Text) || string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(dateTimePicker1.Text) || string.IsNullOrEmpty(comboBox2.Text))
            {
                MessageBox.Show("Заполните все поля!");
            }
            else if (!Regex.IsMatch(comboBox1.Text, "^[а-яА-Я -]+$"))
            {
                MessageBox.Show("Заполните Пациента правильно!");
            }
            else if (!Regex.IsMatch(textBox1.Text, "^[0-9 -]+$"))
            {
                MessageBox.Show("Заполните Сумму правильно!");
            }
            else if (!Regex.IsMatch(dateTimePicker1.Text, "^[0-9а-яА-Я .-]+$"))
            {
                MessageBox.Show("Заполните Дату оплаты правильно!");
            }
            else if (!Regex.IsMatch(comboBox2.Text, "^[а-яА-Я -]+$"))
            {
                MessageBox.Show("Заполните Способ оплаты правильно!");
            }
            else
            {
                _db = ClassProvide.GetInstance();
                SQLiteConnection conn = _db.GetConnection();
                string query = "UPDATE Payments SET patient_id = (SELECT patient_id FROM Patients WHERE last_name = @pc), amount = @am, payment_date = @pd, payment_method = @pm WHERE payment_id = @id";
                SQLiteCommand command = new SQLiteCommand(query, conn);
                command.Parameters.AddWithValue("@id", id);
                command.Parameters.Add("@pc", DbType.String).Value = comboBox1.Text;
                command.Parameters.Add("@am", DbType.String).Value = textBox1.Text;
                command.Parameters.Add("@pd", DbType.String).Value = dateTimePicker1.Text;
                command.Parameters.Add("@pm", DbType.String).Value = comboBox2.Text;
                command.ExecuteNonQuery();
                MessageBox.Show("Запись успешно изменена!");
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                _db = ClassProvide.GetInstance();
                SQLiteConnection conn = _db.GetConnection();
                id = dataGridView1.SelectedRows[0].Cells["Column1"].Value.ToString();
                string query = "SELECT payment_id, Patients.last_name as lnp, amount, payment_date, payment_method FROM Payments INNER JOIN Patients ON Payments.patient_id = Patients.patient_id WHERE payment_id = @id";
                SQLiteCommand cmd = new SQLiteCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                SQLiteDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    string lnp = reader["lnp"].ToString();
                    string amount = reader["amount"].ToString();
                    string payment_date = reader["payment_date"].ToString();
                    string payment_method = reader["payment_method"].ToString();

                    comboBox1.Text = lnp;
                    textBox1.Text = amount;
                    dateTimePicker1.Text = payment_date;
                    comboBox2.Text = payment_method;

                }
            }
        }
    }
}
