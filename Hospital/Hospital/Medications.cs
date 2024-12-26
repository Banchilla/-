using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Hospital
{
    public partial class Medications : Form
    {
        public Medications()
        {
            InitializeComponent();
        }

        private ClassProvide _db;
        string id;
        private byte[] imageBytes;

        private void Medications_Load(object sender, EventArgs e)
        {
            _db = ClassProvide.GetInstance();
            SQLiteConnection conn = _db.GetConnection();
            string query = "SELECT medication_id, name, dosage, side_effects FROM Medications";
            SQLiteCommand cmd = new SQLiteCommand(query, conn);
            SQLiteDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                dataGridView1.Rows.Add(reader["medication_id"], reader["name"], reader["dosage"], reader["side_effects"]);
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                _db = ClassProvide.GetInstance();
                SQLiteConnection conn = _db.GetConnection();
                id = dataGridView1.SelectedRows[0].Cells["Column1"].Value.ToString();
                string query = "SELECT medication_id, name, dosage, side_effects, photo FROM Medications WHERE medication_id = @id;";
                SQLiteCommand cmd = new SQLiteCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                SQLiteDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    string nm = reader["name"].ToString();
                    string ds = reader["dosage"].ToString();
                    string se = reader["side_effects"].ToString();

                    textBox1.Text = nm;
                    textBox2.Text = ds;
                    textBox3.Text = se;

                    byte[] pht = (byte[])reader["photo"];
                    MemoryStream ms = new MemoryStream(pht);
                    pictureBox1.Image = System.Drawing.Image.FromStream(ms);
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox1.Refresh();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                _db = ClassProvide.GetInstance();
                SQLiteConnection conn = _db.GetConnection();
                string id = dataGridView1.SelectedRows[0].Cells["Column1"].Value.ToString();
                string sql = "DELETE FROM Medications WHERE medication_id = @id";
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
            string nm = textBox1.Text;
            string ds = textBox2.Text;
            string se = textBox3.Text;

            if (string.IsNullOrEmpty(nm) || string.IsNullOrEmpty(ds) || string.IsNullOrEmpty(se))
            {
                MessageBox.Show("Заполните все поля!");
            }
            else if (!Regex.IsMatch(nm, "^[а-яА-Я -]+$"))
            {
                MessageBox.Show("Заполните Название правильно!");
            }
            else if (!Regex.IsMatch(ds, "^[а-яА-Я0-9 -]+$"))
            {
                MessageBox.Show("Заполните Объем правильно!");
            }
            else if (!Regex.IsMatch(se, "^[а-яА-Я -]+$"))
            {
                MessageBox.Show("Заполните Симптомы правильно!");
            }
            else
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Filter = "Image files (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png";
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        imageBytes = File.ReadAllBytes(openFileDialog.FileName);
                        _db = ClassProvide.GetInstance();
                        SQLiteConnection conn = _db.GetConnection();
                        string query = "INSERT INTO Medications (name, dosage, side_effects, photo) \r\nVALUES (@nm, @ds, @se, @phot);";
                        SQLiteCommand command = new SQLiteCommand(query, conn);
                        command.Parameters.AddWithValue("@nm", nm);
                        command.Parameters.AddWithValue("@ds", ds);
                        command.Parameters.AddWithValue("@se", se);
                        command.Parameters.AddWithValue("@phot", imageBytes);
                        command.ExecuteNonQuery();
                        MessageBox.Show("Запись добавлена в базу!");
                    }

                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(textBox3.Text))
            {
                MessageBox.Show("Заполните все обязательные поля (*)!");
            }
            else if (!Regex.IsMatch(textBox1.Text, "^[а-яА-Я -]+$"))
            {
                MessageBox.Show("Заполните Название правильно!");
            }
            else if (!Regex.IsMatch(textBox2.Text, "^[а-яА-Я0-9 -]+$"))
            {
                MessageBox.Show("Заполните Объем правильно!");
            }
            else if (!Regex.IsMatch(textBox3.Text, "^[а-яА-Я -]+$"))
            {
                MessageBox.Show("Заполните Симптомы правильно!");
            }
            else
            {
                _db = ClassProvide.GetInstance();
                SQLiteConnection conn = _db.GetConnection();
                string query = "UPDATE Medications SET name = @nm, dosage = @ds, side_effects = @se WHERE medication_id = @id";
                SQLiteCommand command = new SQLiteCommand(query, conn);
                command.Parameters.AddWithValue("@id", id);
                command.Parameters.Add("@nm", DbType.String).Value = textBox1.Text;
                command.Parameters.Add("@ds", DbType.String).Value = textBox2.Text;
                command.Parameters.Add("@se", DbType.String).Value = textBox3.Text;
                command.ExecuteNonQuery();
                MessageBox.Show("Запись успешно изменена!");
            }
        }
    }
}
