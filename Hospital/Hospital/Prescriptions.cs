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

namespace Hospital
{
    public partial class Prescriptions : Form
    {
        public Prescriptions()
        {
            InitializeComponent();
        }

        private ClassProvide _db;
        string id;

        private void Prescriptions_Load(object sender, EventArgs e)
        {
            _db = ClassProvide.GetInstance();
            SQLiteConnection conn = _db.GetConnection();
            string query = "SELECT prescription_id, MedicalRecords.diagnosis as dia, Medications.name as nm, dosage_instructions FROM Prescriptions INNER JOIN MedicalRecords ON Prescriptions.record_id = MedicalRecords.record_id INNER JOIN Medications ON Prescriptions.medication_id = Medications.medication_id";
            SQLiteCommand cmd = new SQLiteCommand(query, conn);
            SQLiteDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                dataGridView1.Rows.Add(reader["prescription_id"], reader["dia"], reader["nm"], reader["dosage_instructions"]);
            }

            _db = ClassProvide.GetInstance();
            SQLiteConnection conn1 = _db.GetConnection();
            string query1 = "SELECT DISTINCT name FROM Medications";
            SQLiteCommand cmd1 = new SQLiteCommand(query1, conn1);
            SQLiteDataReader reader1 = cmd1.ExecuteReader();
            while (reader1.Read())
            {
                string data = reader1.GetString(0);
                comboBox2.Items.Add(data);
            }

            _db = ClassProvide.GetInstance();
            SQLiteConnection conn2 = _db.GetConnection();
            string query2 = "SELECT DISTINCT diagnosis FROM MedicalRecords";
            SQLiteCommand cmd2 = new SQLiteCommand(query2, conn2);
            SQLiteDataReader reader2 = cmd2.ExecuteReader();
            while (reader2.Read())
            {
                string data = reader2.GetString(0);
                comboBox1.Items.Add(data);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                _db = ClassProvide.GetInstance();
                SQLiteConnection conn = _db.GetConnection();
                string id = dataGridView1.SelectedRows[0].Cells["Column1"].Value.ToString();
                string sql = "DELETE FROM Prescriptions WHERE prescription_id = @id";
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

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                _db = ClassProvide.GetInstance();
                SQLiteConnection conn = _db.GetConnection();
                id = dataGridView1.SelectedRows[0].Cells["Column1"].Value.ToString();
                string query = "SELECT prescription_id, MedicalRecords.diagnosis as dia, Medications.name as nm, dosage_instructions FROM Prescriptions INNER JOIN MedicalRecords ON Prescriptions.record_id = MedicalRecords.record_id INNER JOIN Medications ON Prescriptions.medication_id = Medications.medication_id WHERE prescription_id = @id";
                SQLiteCommand cmd = new SQLiteCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                SQLiteDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    string dia = reader["dia"].ToString();
                    string nm = reader["nm"].ToString();
                    string dosage_instructions = reader["dosage_instructions"].ToString();

                    comboBox1.Text = dia;
                    comboBox2.Text = nm;
                    textBox1.Text = dosage_instructions;

                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string dg = comboBox1.Text;
            string nm = comboBox2.Text;
            string dosage_instructions = textBox1.Text;

            if (string.IsNullOrEmpty(dg) || string.IsNullOrEmpty(nm) || string.IsNullOrEmpty(dosage_instructions))
            {
                MessageBox.Show("Заполните все поля!");
            }
            else if (!Regex.IsMatch(nm, "^[а-яА-Я -]+$"))
            {
                MessageBox.Show("Заполните Диагноз правильно!");
            }
            else if (!Regex.IsMatch(nm, "^[а-яА-Я -]+$"))
            {
                MessageBox.Show("Заполните Лекарство правильно!");
            }
            else if (!Regex.IsMatch(dosage_instructions, "^[0-9а-яА-Я .-]+$"))
            {
                MessageBox.Show("Заполните Инструкцию к применению правильно!");
            }
            else
            {
                _db = ClassProvide.GetInstance();
                SQLiteConnection conn = _db.GetConnection();
                string query = "INSERT INTO Prescriptions (record_id, medication_id, dosage_instructions) \r\nVALUES ((SELECT record_id FROM MedicalRecords WHERE diagnosis = @dg), (SELECT medication_id FROM Medications WHERE name = @nm), @dosage_instructions);";
                SQLiteCommand command = new SQLiteCommand(query, conn);
                command.Parameters.AddWithValue("@dg", dg);
                command.Parameters.AddWithValue("@nm", nm);
                command.Parameters.AddWithValue("@dosage_instructions", dosage_instructions);
                command.ExecuteNonQuery();
                MessageBox.Show("Запись добавлена в базу!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(comboBox1.Text) || string.IsNullOrEmpty(comboBox2.Text) || string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Заполните все поля!");
            }
            else if (!Regex.IsMatch(comboBox1.Text, "^[а-яА-Я -]+$"))
            {
                MessageBox.Show("Заполните Диагноз правильно!");
            }
            else if (!Regex.IsMatch(comboBox2.Text, "^[а-яА-Я -]+$"))
            {
                MessageBox.Show("Заполните Лекарство правильно!");
            }
            else if (!Regex.IsMatch(textBox1.Text, "^[0-9а-яА-Я .-]+$"))
            {
                MessageBox.Show("Заполните Инструкцию к применению правильно!");
            }
            else
            {
                _db = ClassProvide.GetInstance();
                SQLiteConnection conn = _db.GetConnection();
                string query = "UPDATE Prescriptions SET record_id = (SELECT record_id FROM MedicalRecords WHERE diagnosis = @dg), medication_id = (SELECT medication_id FROM Medications WHERE name = @nm), dosage_instructions = @dosage_instructions WHERE prescription_id = @id";
                SQLiteCommand command = new SQLiteCommand(query, conn);
                command.Parameters.AddWithValue("@id", id);
                command.Parameters.Add("@dg", DbType.String).Value = comboBox1.Text;
                command.Parameters.Add("@nm", DbType.String).Value = comboBox2.Text;
                command.Parameters.Add("@dosage_instructions", DbType.String).Value = textBox1.Text;
                command.ExecuteNonQuery();
                MessageBox.Show("Запись успешно изменена!");
            }
        }
    }
}
