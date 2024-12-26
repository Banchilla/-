using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Hospital
{
    public partial class Patients : Form
    {
        public Patients()
        {
            InitializeComponent();
        }

        private ClassProvide _db;
        string id;

        private void Patients_Load(object sender, EventArgs e)
        {
            _db = ClassProvide.GetInstance();
            SQLiteConnection conn = _db.GetConnection();
            string query = "SELECT patient_id, first_name, last_name, date_of_birth, gender, address, phone_number, email, insurance_info FROM Patients";
            SQLiteCommand cmd = new SQLiteCommand(query, conn);
            SQLiteDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                dataGridView1.Rows.Add(reader["patient_id"], reader["first_name"], reader["last_name"], reader["date_of_birth"], reader["gender"], reader["address"], reader["phone_number"], reader["email"], reader["insurance_info"]);
            }

            _db = ClassProvide.GetInstance();
            SQLiteConnection conn3 = _db.GetConnection();
            string query3 = "SELECT DISTINCT gender FROM Patients";
            SQLiteCommand cmd3 = new SQLiteCommand(query3, conn3);
            SQLiteDataReader reader3 = cmd3.ExecuteReader();
            while (reader3.Read())
            {
                string data = reader3.GetString(0);
                comboBox1.Items.Add(data);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                _db = ClassProvide.GetInstance();
                SQLiteConnection conn = _db.GetConnection();
                string id = dataGridView1.SelectedRows[0].Cells["Column1"].Value.ToString();
                string sql = "DELETE FROM Patients WHERE patient_id = @id";
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
            string fn = textBox1.Text;
            string ln = textBox6.Text;
            string db = dateTimePicker1.Text;
            string gn = comboBox1.Text;
            string ad = textBox5.Text;
            string np = textBox8.Text;
            string em = textBox3.Text;
            string str = textBox4.Text;

            if (string.IsNullOrEmpty(fn) || string.IsNullOrEmpty(ln) || string.IsNullOrEmpty(db) || string.IsNullOrEmpty(gn) || string.IsNullOrEmpty(ad) || string.IsNullOrEmpty(np) || string.IsNullOrEmpty(em) || string.IsNullOrEmpty(str))
            {
                MessageBox.Show("Заполните все поля!");
            }
            else if (!Regex.IsMatch(fn, "^[а-яА-Я -]+$"))
            {
                MessageBox.Show("Заполните Имя правильно!");
            }
            else if (!Regex.IsMatch(ln, "^[а-яА-Я -]+$"))
            {
                MessageBox.Show("Заполните Фамилию правильно!");
            }
            else if (!Regex.IsMatch(db, "^[0-9а-яА-Я .-]+$"))
            {
                MessageBox.Show("Заполните Дату рождения правильно!");
            }
            else if (!Regex.IsMatch(gn, "^[а-яА-Я]+$"))
            {
                MessageBox.Show("Заполните Пол правильно!");
            }
            else if (!Regex.IsMatch(ad, "^[а-яА-Я .,0-9-]+$"))
            {
                MessageBox.Show("Заполните Адрес правильно!");
            }
            else if (!Regex.IsMatch(np, "^[0-9 +]+$"))
            {
                MessageBox.Show("Заполните Номер телефона правильно!");
            }
            else if (!Regex.IsMatch(em, "^[0-9 a-zA-Z @.]+$"))
            {
                MessageBox.Show("Заполните Почту правильно!");
            }
            else if (!Regex.IsMatch(str, "^[а-яА-Я 0-9]+$"))
            {
                MessageBox.Show("Заполните Страховку правильно!");
            }
            else
            {
                _db = ClassProvide.GetInstance();
                SQLiteConnection conn = _db.GetConnection();
                string query = "INSERT INTO Patients (first_name, last_name, date_of_birth, gender, address, phone_number, email, insurance_info) \r\nVALUES (@fn, @ln, @db, @gn, @ad, @np, @em, @str);";
                SQLiteCommand command = new SQLiteCommand(query, conn);
                command.Parameters.AddWithValue("@fn", fn);
                command.Parameters.AddWithValue("@ln", ln);
                command.Parameters.AddWithValue("@db", db);
                command.Parameters.AddWithValue("@gn", gn);
                command.Parameters.AddWithValue("@ad", ad);
                command.Parameters.AddWithValue("@np", np);
                command.Parameters.AddWithValue("@em", em);
                command.Parameters.AddWithValue("@str", str);
                command.ExecuteNonQuery();
                MessageBox.Show("Запись добавлена в базу!");
            }

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                _db = ClassProvide.GetInstance();
                SQLiteConnection conn = _db.GetConnection();
                id = dataGridView1.SelectedRows[0].Cells["Column1"].Value.ToString();
                string query = "SELECT patient_id, first_name, last_name, date_of_birth, gender, address, phone_number, email, insurance_info FROM Patients WHERE patient_id = @id";
                SQLiteCommand cmd = new SQLiteCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                SQLiteDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    string fn = reader["first_name"].ToString();
                    string ln = reader["last_name"].ToString();
                    string db = reader["date_of_birth"].ToString();
                    string gn = reader["gender"].ToString();
                    string ad = reader["address"].ToString();
                    string pn = reader["phone_number"].ToString();
                    string em = reader["email"].ToString();
                    string str = reader["insurance_info"].ToString();

                    textBox1.Text = fn;
                    textBox6.Text = ln;
                    dateTimePicker1.Text = db;
                    comboBox1.Text = gn;
                    textBox5.Text = ad;
                    textBox8.Text = pn;
                    textBox3.Text = em;
                    textBox4.Text = str;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox3.Text) || string.IsNullOrEmpty(textBox4.Text) || string.IsNullOrEmpty(textBox8.Text) || string.IsNullOrEmpty(textBox6.Text) || string.IsNullOrEmpty(textBox5.Text) || string.IsNullOrEmpty(comboBox1.Text) || string.IsNullOrEmpty(dateTimePicker1.Text))
            {
                MessageBox.Show("Заполните все поля!");
            }
            else if (!Regex.IsMatch(textBox1.Text, "^[а-яА-Я -]+$"))
            {
                MessageBox.Show("Заполните Имя правильно!");
            }
            else if (!Regex.IsMatch(textBox6.Text, "^[а-яА-Я -]+$"))
            {
                MessageBox.Show("Заполните Фамилию правильно!");
            }
            else if (!Regex.IsMatch(dateTimePicker1.Text, "^[0-9а-яА-Я .-]+$"))
            {
                MessageBox.Show("Заполните Дату рождения правильно!");
            }
            else if (!Regex.IsMatch(comboBox1.Text, "^[а-яА-Я]+$"))
            {
                MessageBox.Show("Заполните Пол правильно!");
            }
            else if (!Regex.IsMatch(textBox5.Text, "^[а-яА-Я .,0-9-]+$"))
            {
                MessageBox.Show("Заполните Адрес правильно!");
            }
            else if (!Regex.IsMatch(textBox8.Text, "^[0-9 +]+$"))
            {
                MessageBox.Show("Заполните Номер телефона правильно!");
            }
            else if (!Regex.IsMatch(textBox3.Text, "^[0-9 a-zA-Z @.]+$"))
            {
                MessageBox.Show("Заполните Почту правильно!");
            }
            else if (!Regex.IsMatch(textBox4.Text, "^[а-яА-Я 0-9]+$"))
            {
                MessageBox.Show("Заполните Страховку правильно!");
            }
            else
            {
                _db = ClassProvide.GetInstance();
                SQLiteConnection conn = _db.GetConnection();
                string query = "UPDATE Patients SET first_name = @fn, last_name = @ln, date_of_birth = @db, gender = @gn, address = @ad, phone_number = @pn, email = @em, insurance_info = @str WHERE patient_id = @id";
                SQLiteCommand command = new SQLiteCommand(query, conn);
                command.Parameters.AddWithValue("@id", id);
                command.Parameters.Add("@fn", DbType.String).Value = textBox1.Text;
                command.Parameters.Add("@ln", DbType.String).Value = textBox6.Text;
                command.Parameters.Add("@db", DbType.String).Value = dateTimePicker1.Text;
                command.Parameters.Add("@gn", DbType.String).Value = comboBox1.Text;
                command.Parameters.Add("@ad", DbType.String).Value = textBox5.Text;
                command.Parameters.Add("@pn", DbType.String).Value = textBox8.Text;
                command.Parameters.Add("@em", DbType.String).Value = textBox3.Text;
                command.Parameters.Add("@str", DbType.String).Value = textBox4.Text;
                command.ExecuteNonQuery();
                MessageBox.Show("Запись успешно изменена!");
            }
        }
    }
}
