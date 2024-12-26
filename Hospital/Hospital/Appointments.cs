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
    public partial class Appointments : Form
    {
        public Appointments()
        {
            InitializeComponent();
        }

        private ClassProvide _db;
        string id;

        private void Appointments_Load(object sender, EventArgs e)
        {
            _db = ClassProvide.GetInstance();
            SQLiteConnection conn = _db.GetConnection();
            string query = "SELECT appointment_id, Patients.last_name as lnp, Doctors.last_name lnd, appointment_date, reason_for_visit, status FROM Appointments INNER JOIN Patients ON Appointments.patient_id = Patients.patient_id INNER JOIN Doctors ON Appointments.doctor_id = Doctors.doctor_id";
            SQLiteCommand cmd = new SQLiteCommand(query, conn);
            SQLiteDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                dataGridView1.Rows.Add(reader["appointment_id"], reader["lnp"], reader["lnd"], reader["appointment_date"], reader["reason_for_visit"], reader["status"]);
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

            _db = ClassProvide.GetInstance();
            SQLiteConnection conn2 = _db.GetConnection();
            string query2 = "SELECT DISTINCT last_name FROM Doctors";
            SQLiteCommand cmd2 = new SQLiteCommand(query2, conn2);
            SQLiteDataReader reader2 = cmd2.ExecuteReader();
            while (reader2.Read())
            {
                string data = reader2.GetString(0);
                comboBox2.Items.Add(data);
            }

            comboBox3.Items.Add("Запланированный");
            comboBox3.Items.Add("Отмененный");
            comboBox3.Items.Add("Завершенный");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                _db = ClassProvide.GetInstance();
                SQLiteConnection conn = _db.GetConnection();
                string id = dataGridView1.SelectedRows[0].Cells["Column1"].Value.ToString();
                string sql = "DELETE FROM Appointments WHERE appointment_id = @id";
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
            string pt = comboBox1.Text;
            string dc = comboBox2.Text;
            string ad = dateTimePicker1.Text;
            string rfv = textBox1.Text;
            string st = comboBox3.Text;

            if (string.IsNullOrEmpty(pt) || string.IsNullOrEmpty(dc) || string.IsNullOrEmpty(ad) || string.IsNullOrEmpty(rfv) || string.IsNullOrEmpty(st))
            {
                MessageBox.Show("Заполните все поля!");
            }
            else if (!Regex.IsMatch(pt, "^[а-яА-Я -]+$"))
            {
                MessageBox.Show("Заполните Пациента правильно!");
            }
            else if (!Regex.IsMatch(dc, "^[а-яА-Я -]+$"))
            {
                MessageBox.Show("Заполните Врача правильно!");
            }
            else if (!Regex.IsMatch(ad, "^[0-9а-яА-Я .-]+$"))
            {
                MessageBox.Show("Заполните Дату визита правильно!");
            }
            else if (!Regex.IsMatch(rfv, "^[а-яА-Я -]+$"))
            {
                MessageBox.Show("Заполните Причину визита правильно!");
            }
            else if (!Regex.IsMatch(st, "^[а-яА-Я -]+$"))
            {
                MessageBox.Show("Заполните Статус правильно!");
            }
            else
            {
                _db = ClassProvide.GetInstance();
                SQLiteConnection conn = _db.GetConnection();
                string query = "INSERT INTO Appointments (patient_id, doctor_id, appointment_date, reason_for_visit, status) \r\nVALUES ((SELECT patient_id FROM Patients WHERE last_name = @pt), (SELECT doctor_id FROM Doctors WHERE last_name = @dc), @ad, @rfv, @st);";
                SQLiteCommand command = new SQLiteCommand(query, conn);
                command.Parameters.AddWithValue("@pt", pt);
                command.Parameters.AddWithValue("@dc", dc);
                command.Parameters.AddWithValue("@ad", ad);
                command.Parameters.AddWithValue("@rfv", rfv);
                command.Parameters.AddWithValue("@st", st);
                command.ExecuteNonQuery();
                MessageBox.Show("Запись добавлена в базу!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(comboBox1.Text) || string.IsNullOrEmpty(comboBox2.Text) || string.IsNullOrEmpty(dateTimePicker1.Text) || string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(comboBox3.Text))
            {
                MessageBox.Show("Заполните все поля!");
            }
            else if (!Regex.IsMatch(comboBox1.Text, "^[а-яА-Я -]+$"))
            {
                MessageBox.Show("Заполните Пациента правильно!");
            }
            else if (!Regex.IsMatch(comboBox2.Text, "^[а-яА-Я -]+$"))
            {
                MessageBox.Show("Заполните Врача правильно!");
            }
            else if (!Regex.IsMatch(dateTimePicker1.Text, "^[0-9а-яА-Я .-]+$"))
            {
                MessageBox.Show("Заполните Дату визита правильно!");
            }
            else if (!Regex.IsMatch(textBox1.Text, "^[а-яА-Я, -]+$"))
            {
                MessageBox.Show("Заполните Причину визита правильно!");
            }
            else if (!Regex.IsMatch(comboBox3.Text, "^[а-яА-Я -]+$"))
            {
                MessageBox.Show("Заполните Статус правильно!");
            }
            else
            {
                _db = ClassProvide.GetInstance();
                SQLiteConnection conn = _db.GetConnection();
                string query = "UPDATE Appointments SET patient_id = (SELECT patient_id FROM Patients WHERE last_name = @pt), doctor_id = (SELECT doctor_id FROM Doctors WHERE last_name = @dc), appointment_date = @ad, reason_for_visit = @rfv, status = @st WHERE appointment_id = @id";
                SQLiteCommand command = new SQLiteCommand(query, conn);
                command.Parameters.AddWithValue("@id", id);
                command.Parameters.Add("@pt", DbType.String).Value = comboBox1.Text;
                command.Parameters.Add("@dc", DbType.String).Value = comboBox2.Text;
                command.Parameters.Add("@ad", DbType.String).Value = dateTimePicker1.Text;
                command.Parameters.Add("@rfv", DbType.String).Value = textBox1.Text;
                command.Parameters.Add("@st", DbType.String).Value = comboBox3.Text;
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
                string query = "SELECT appointment_id, Patients.last_name as lnp, Doctors.last_name lnd, appointment_date, reason_for_visit, status FROM Appointments INNER JOIN Patients ON Appointments.patient_id = Patients.patient_id INNER JOIN Doctors ON Appointments.doctor_id = Doctors.doctor_id WHERE appointment_id = @id";
                SQLiteCommand cmd = new SQLiteCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                SQLiteDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    string lnp = reader["lnp"].ToString();
                    string lnd = reader["lnd"].ToString();
                    string appointment_date = reader["appointment_date"].ToString();
                    string reason_for_visit = reader["reason_for_visit"].ToString();
                    string status = reader["status"].ToString();

                    comboBox1.Text = lnp;
                    comboBox2.Text = lnd;
                    dateTimePicker1.Text = appointment_date;
                    textBox1.Text = reason_for_visit;
                    comboBox3.Text = status;
                }
            }
        }
    }
}
