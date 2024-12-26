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

namespace Hospital
{
    public partial class Doctors : Form
    {
        public Doctors()
        {
            InitializeComponent();
        }

        private ClassProvide _db;
        string id;

        private void Doctors_Load(object sender, EventArgs e)
        {
            _db = ClassProvide.GetInstance();
            SQLiteConnection conn = _db.GetConnection();
            string query = "SELECT doctor_id, first_name, last_name, specialization, phone_number, email FROM Doctors";
            SQLiteCommand cmd = new SQLiteCommand(query, conn);
            SQLiteDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                dataGridView1.Rows.Add(reader["doctor_id"], reader["first_name"], reader["last_name"], reader["specialization"], reader["phone_number"], reader["email"]);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                _db = ClassProvide.GetInstance();
                SQLiteConnection conn = _db.GetConnection();
                string id = dataGridView1.SelectedRows[0].Cells["Column1"].Value.ToString();
                string sql = "DELETE FROM Doctors WHERE doctor_id = @id";
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
            string name = textBox1.Text;
            string fam = textBox2.Text;
            string sp = textBox3.Text;
            string pn = textBox4.Text;
            string em = textBox5.Text;

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(fam) || string.IsNullOrEmpty(sp) || string.IsNullOrEmpty(pn) || string.IsNullOrEmpty(em))
            {
                MessageBox.Show("Заполните все поля!");
            }
            else if (!Regex.IsMatch(name, "^[а-яА-Я -]+$"))
            {
                MessageBox.Show("Заполните Имя правильно!");
            }
            else if (!Regex.IsMatch(fam, "^[а-яА-Я -]+$"))
            {
                MessageBox.Show("Заполните Фамилию правильно!");
            }
            else if (!Regex.IsMatch(sp, "^[а-яА-Я -]+$"))
            {
                MessageBox.Show("Заполните Специализацию правильно!");
            }
            else if (!Regex.IsMatch(pn, "^[0-9 +]+$"))
            {
                MessageBox.Show("Заполните Номер телефона правильно!");
            }
            else if (!Regex.IsMatch(em, "^[A-Za-z0-9 .@+]+$"))
            {
                MessageBox.Show("Заполните Почту правильно!");
            }
            else
            {
                _db = ClassProvide.GetInstance();
                SQLiteConnection conn = _db.GetConnection();
                string query = "INSERT INTO Doctors (first_name, last_name, specialization, phone_number, email) \r\nVALUES (@name, @fam, @sp, @pn, @em);";
                SQLiteCommand command = new SQLiteCommand(query, conn);
                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@fam", fam);
                command.Parameters.AddWithValue("@sp", sp);
                command.Parameters.AddWithValue("@pn", pn);
                command.Parameters.AddWithValue("@em", em);
                command.ExecuteNonQuery();
                MessageBox.Show("Запись добавлена в базу!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(textBox3.Text) || string.IsNullOrEmpty(textBox4.Text) || string.IsNullOrEmpty(textBox5.Text))
            {
                MessageBox.Show("Заполните все поля!");
            }
            else if (!Regex.IsMatch(textBox1.Text, "^[а-яА-Я -]+$"))
            {
                MessageBox.Show("Заполните Имя правильно!");
            }
            else if (!Regex.IsMatch(textBox2.Text, "^[а-яА-Я -]+$"))
            {
                MessageBox.Show("Заполните Фамилию правильно!");
            }
            else if (!Regex.IsMatch(textBox3.Text, "^[а-яА-Я -]+$"))
            {
                MessageBox.Show("Заполните Специализацию правильно!");
            }
            else if (!Regex.IsMatch(textBox4.Text, "^[0-9 +]+$"))
            {
                MessageBox.Show("Заполните Номер телефона правильно!");
            }
            else if (!Regex.IsMatch(textBox5.Text, "^[A-Za-z0-9 .@+]+$"))
            {
                MessageBox.Show("Заполните Почту правильно!");
            }
            else
            {
                _db = ClassProvide.GetInstance();
                SQLiteConnection conn = _db.GetConnection();
                string query = "UPDATE Doctors SET first_name = @fn, last_name = @ln, specialization = @sp, phone_number = @pn, email = @em WHERE doctor_id = @id";
                SQLiteCommand command = new SQLiteCommand(query, conn);
                command.Parameters.AddWithValue("@id", id);
                command.Parameters.Add("@fn", DbType.String).Value = textBox1.Text;
                command.Parameters.Add("@ln", DbType.String).Value = textBox2.Text;
                command.Parameters.Add("@sp", DbType.String).Value = textBox3.Text;
                command.Parameters.Add("@pn", DbType.String).Value = textBox4.Text;
                command.Parameters.Add("@em", DbType.String).Value = textBox5.Text;
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
                string query = "SELECT doctor_id, first_name, last_name, specialization, phone_number, email FROM Doctors WHERE doctor_id = @id";
                SQLiteCommand cmd = new SQLiteCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                SQLiteDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    string fn = reader["first_name"].ToString();
                    string ln = reader["last_name"].ToString();
                    string sp = reader["specialization"].ToString();
                    string pn = reader["phone_number"].ToString();
                    string em = reader["email"].ToString();

                    textBox1.Text = fn;
                    textBox2.Text = ln;
                    textBox3.Text = sp;
                    textBox4.Text = pn;
                    textBox5.Text = em;

                }
            }
        }
    }
}
