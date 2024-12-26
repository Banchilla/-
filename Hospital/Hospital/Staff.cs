using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Hospital
{
    public partial class Staff : Form
    {
        public Staff()
        {
            InitializeComponent();
        }

        private ClassProvide _db;
        string id;

        private void Staff_Load(object sender, EventArgs e)
        {
            _db = ClassProvide.GetInstance();
            SQLiteConnection conn = _db.GetConnection();
            string query = "SELECT staff_id, first_name, last_name, position, department FROM Staff";
            SQLiteCommand cmd = new SQLiteCommand(query, conn);
            SQLiteDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                dataGridView1.Rows.Add(reader["staff_id"], reader["first_name"], reader["last_name"], reader["position"], reader["department"]);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                _db = ClassProvide.GetInstance();
                SQLiteConnection conn = _db.GetConnection();
                string id = dataGridView1.SelectedRows[0].Cells["Column1"].Value.ToString();
                string sql = "DELETE FROM Staff WHERE staff_id = @id";
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
            string ln = textBox2.Text;
            string pos = textBox3.Text;
            string dep = textBox4.Text;

            if (string.IsNullOrEmpty(fn) || string.IsNullOrEmpty(ln) || string.IsNullOrEmpty(pos) || string.IsNullOrEmpty(dep))
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
            else if (!Regex.IsMatch(pos, "^[а-яА-Я -]+$"))
            {
                MessageBox.Show("Заполните Позицию правильно!");
            }
            else if (!Regex.IsMatch(dep, "^[а-яА-Я]+$"))
            {
                MessageBox.Show("Заполните Отдел правильно!");
            }
            else
            {
                _db = ClassProvide.GetInstance();
                SQLiteConnection conn = _db.GetConnection();
                string query = "INSERT INTO Staff (first_name, last_name, positions, department) \r\nVALUES (@fn, @ln, @pos, @dep);";
                SQLiteCommand command = new SQLiteCommand(query, conn);
                command.Parameters.AddWithValue("@fn", fn);
                command.Parameters.AddWithValue("@ln", ln);
                command.Parameters.AddWithValue("@pos", pos);
                command.Parameters.AddWithValue("@dep", dep);
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
                string query = "SELECT staff_id, first_name, last_name, position, department FROM Staff WHERE staff_id = @id";
                SQLiteCommand cmd = new SQLiteCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                SQLiteDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    string fn = reader["first_name"].ToString();
                    string ln = reader["last_name"].ToString();
                    string sp = reader["position"].ToString();
                    string pn = reader["department"].ToString();

                    textBox1.Text = fn;
                    textBox2.Text = ln;
                    textBox3.Text = sp;
                    textBox4.Text = pn;

                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(textBox3.Text) || string.IsNullOrEmpty(textBox4.Text))
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
                MessageBox.Show("Заполните Позицию правильно!");
            }
            else if (!Regex.IsMatch(textBox4.Text, "^[а-яА-Я]+$"))
            {
                MessageBox.Show("Заполните Отдел правильно!");
            }
            else
            {
                _db = ClassProvide.GetInstance();
                SQLiteConnection conn = _db.GetConnection();
                string query = "UPDATE Staff SET first_name = @fn, last_name = @ln, position = @po, department = @dep WHERE staff_id = @id";
                SQLiteCommand command = new SQLiteCommand(query, conn);
                command.Parameters.AddWithValue("@id", id);
                command.Parameters.Add("@fn", DbType.String).Value = textBox1.Text;
                command.Parameters.Add("@ln", DbType.String).Value = textBox2.Text;
                command.Parameters.Add("@po", DbType.String).Value = textBox3.Text;
                command.Parameters.Add("@dep", DbType.String).Value = textBox4.Text;
                command.ExecuteNonQuery();
                MessageBox.Show("Запись успешно изменена!");
            }
        }
    }
}
