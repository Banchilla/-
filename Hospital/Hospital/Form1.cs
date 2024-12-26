using System.Data;
using System.Data.SQLite;
using System.Runtime.Intrinsics.Arm;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Hospital
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private ClassProvide _db;
        string id;

        private void отделToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Departments dp = new Departments();
            dp.ShowDialog(this);
        }

        private void доктораToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Doctors dc = new Doctors();
            dc.ShowDialog(this);
        }

        private void пациентыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Patients pt = new Patients();
            pt.ShowDialog(this);
        }

        private void персоналToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Staff st = new Staff();
            st.ShowDialog(this);
        }

        private void лекарстваToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Medications md = new Medications();
            md.ShowDialog(this);
        }

        private void палатыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Rooms rm = new Rooms();
            rm.ShowDialog(this);
        }

        private void платежиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Payments pm = new Payments();
            pm.ShowDialog(this);
        }

        private void предписанияКЛекарствамToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Prescriptions pr = new Prescriptions();
            pr.ShowDialog(this);
        }

        private void записиНаПриемToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Appointments appointments = new Appointments();
            appointments.ShowDialog(this);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _db = ClassProvide.GetInstance();
            SQLiteConnection conn = _db.GetConnection();
            string query = "SELECT \r\n    MedicalRecords.record_id as id, \r\n    Patients.last_name as lnp, \r\n    Doctors.last_name as lnd, \r\n    MedicalRecords.visit_date as vd, \r\n    MedicalRecords.diagnosis as d, \r\n    MedicalRecords.treatment_plan tp, \r\n    MedicalRecords.notes as n \r\nFROM \r\n    MedicalRecords\r\nINNER JOIN \r\n    Patients ON MedicalRecords.patient_id = Patients.patient_id\r\nINNER JOIN \r\n    Doctors ON MedicalRecords.doctor_id = Doctors.doctor_id;";
            SQLiteCommand cmd = new SQLiteCommand(query, conn);
            SQLiteDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                dataGridView1.Rows.Add(reader["id"], reader["lnp"], reader["lnd"], reader["vd"], reader["d"], reader["tp"], reader["n"]);
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
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                _db = ClassProvide.GetInstance();
                SQLiteConnection conn = _db.GetConnection();
                id = dataGridView1.SelectedRows[0].Cells["Column1"].Value.ToString();
                string query = "SELECT \r\n    MedicalRecords.record_id as id, \r\n    Patients.last_name as lnp, \r\n    Doctors.last_name as lnd, \r\n    MedicalRecords.visit_date as vd, \r\n    MedicalRecords.diagnosis as d, \r\n    MedicalRecords.treatment_plan tp, \r\n    MedicalRecords.notes as n \r\nFROM \r\n    MedicalRecords\r\nINNER JOIN \r\n    Patients ON MedicalRecords.patient_id = Patients.patient_id\r\nINNER JOIN \r\n    Doctors ON MedicalRecords.doctor_id = Doctors.doctor_id WHERE record_id = @id";
                SQLiteCommand cmd = new SQLiteCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                SQLiteDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    string lnp = reader["lnp"].ToString();
                    string lnd = reader["lnd"].ToString();
                    string vd = reader["vd"].ToString();
                    string d = reader["d"].ToString();
                    string tp = reader["tp"].ToString();
                    string n = reader["n"].ToString();

                    comboBox1.Text = lnp;
                    comboBox2.Text = lnd;
                    dateTimePicker1.Text = vd;
                    textBox1.Text = d;
                    textBox2.Text = tp;
                    textBox3.Text = n;

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
                string sql = "DELETE FROM MedicalRecords WHERE record_id = @id";
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
            string vd = dateTimePicker1.Text;
            string dg = textBox1.Text;
            string tp = textBox2.Text;
            string nt = textBox3.Text;

            if (string.IsNullOrEmpty(pt) || string.IsNullOrEmpty(dc) || string.IsNullOrEmpty(vd) || string.IsNullOrEmpty(dg) || string.IsNullOrEmpty(tp) || string.IsNullOrEmpty(nt))
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
            else if (!Regex.IsMatch(vd, "^[а-яА-Я0-9 .-]+$"))
            {
                MessageBox.Show("Заполните Дату визита правильно!");
            }
            else if (!Regex.IsMatch(dg, "^[а-яА-Я .-]+$"))
            {
                MessageBox.Show("Заполните Диагноз правильно!");
            }
            else if (!Regex.IsMatch(tp, "^[а-яА-Я .-]+$"))
            {
                MessageBox.Show("Заполните План лечения правильно!");
            }
            else if (!Regex.IsMatch(nt, "^[а-яА-Я .-]+$"))
            {
                MessageBox.Show("Заполните Записи правильно!");
            }
            else
            {
                _db = ClassProvide.GetInstance();
                SQLiteConnection conn = _db.GetConnection();
                string query = "INSERT INTO MedicalRecords (patient_id, doctor_id, visit_date, diagnosis, treatment_plan, notes) \r\nVALUES ((SELECT patient_id FROM Patients WHERE last_name = @pt), (SELECT doctor_id FROM Doctors WHERE last_name = @dc), @vd, @dg, @tp, @nt);";
                SQLiteCommand command = new SQLiteCommand(query, conn);
                command.Parameters.AddWithValue("@pt", pt);
                command.Parameters.AddWithValue("@dc", dc);
                command.Parameters.AddWithValue("@vd", vd);
                command.Parameters.AddWithValue("@dg", dg);
                command.Parameters.AddWithValue("@tp", tp);
                command.Parameters.AddWithValue("@nt", nt);
                command.ExecuteNonQuery();
                MessageBox.Show("Запись добавлена в базу!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(comboBox1.Text) || string.IsNullOrEmpty(comboBox2.Text) || string.IsNullOrEmpty(dateTimePicker1.Text) || string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(textBox3.Text))
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
            else if (!Regex.IsMatch(dateTimePicker1.Text, "^[а-яА-Я0-9 .-]+$"))
            {
                MessageBox.Show("Заполните Дату визита правильно!");
            }
            else if (!Regex.IsMatch(textBox1.Text, "^[а-яА-Я .-]+$"))
            {
                MessageBox.Show("Заполните Диагноз правильно!");
            }
            else if (!Regex.IsMatch(textBox2.Text, "^[а-яА-Я ,.-]+$"))
            {
                MessageBox.Show("Заполните План лечения правильно!");
            }
            else if (!Regex.IsMatch(textBox3.Text, "^[а-яА-Я .-]+$"))
            {
                MessageBox.Show("Заполните Записи правильно!");
            }
            else
            {
                _db = ClassProvide.GetInstance();
                SQLiteConnection conn = _db.GetConnection();
                string query = "UPDATE MedicalRecords SET patient_id = (SELECT patient_id FROM Patients WHERE last_name = @pt), doctor_id = (SELECT doctor_id FROM Doctors WHERE last_name = @dc), visit_date = @vd, diagnosis = @dg, treatment_plan = @tp, notes = @nt WHERE record_id = @id";
                SQLiteCommand command = new SQLiteCommand(query, conn);
                command.Parameters.AddWithValue("@id", id);
                command.Parameters.Add("@pt", DbType.String).Value = comboBox1.Text;
                command.Parameters.Add("@dc", DbType.String).Value = comboBox2.Text;
                command.Parameters.Add("@vd", DbType.String).Value = dateTimePicker1.Text;
                command.Parameters.Add("@dg", DbType.String).Value = textBox1.Text;
                command.Parameters.Add("@tp", DbType.String).Value = textBox2.Text;
                command.Parameters.Add("@nt", DbType.String).Value = textBox3.Text;
                command.ExecuteNonQuery();
                MessageBox.Show("Запись успешно изменена!");
            }
        }
    }
}
