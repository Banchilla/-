using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Hospital
{
    public partial class Rooms : Form
    {
        public Rooms()
        {
            InitializeComponent();
        }

        private ClassProvide _db;
        string id;

        private void Rooms_Load(object sender, EventArgs e)
        {
            _db = ClassProvide.GetInstance();
            SQLiteConnection conn = _db.GetConnection();
            string query = "SELECT room_id, room_number, type, availability_status FROM Rooms";
            SQLiteCommand cmd = new SQLiteCommand(query, conn);
            SQLiteDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                dataGridView1.Rows.Add(reader["room_id"], reader["room_number"], reader["type"], reader["availability_status"]);
            }

            _db = ClassProvide.GetInstance();
            SQLiteConnection conn3 = _db.GetConnection();
            string query3 = "SELECT DISTINCT availability_status FROM Rooms";
            SQLiteCommand cmd3 = new SQLiteCommand(query3, conn3);
            SQLiteDataReader reader3 = cmd3.ExecuteReader();
            while (reader3.Read())
            {
                string data = reader3.GetString(0);
                comboBox3.Items.Add(data);
            }

            _db = ClassProvide.GetInstance();
            SQLiteConnection conn1 = _db.GetConnection();
            string query1 = "SELECT DISTINCT type FROM Rooms";
            SQLiteCommand cmd1 = new SQLiteCommand(query1, conn1);
            SQLiteDataReader reader1 = cmd1.ExecuteReader();
            while (reader1.Read())
            {
                string data = reader1.GetString(0);
                comboBox2.Items.Add(data);
            }

            _db = ClassProvide.GetInstance();
            SQLiteConnection conn2 = _db.GetConnection();
            string query2 = "SELECT DISTINCT room_number FROM Rooms";
            SQLiteCommand cmd2 = new SQLiteCommand(query2, conn2);
            SQLiteDataReader reader2 = cmd2.ExecuteReader();
            while (reader2.Read())
            {
                string data = reader2.GetString(0);
                comboBox1.Items.Add(data);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _db = ClassProvide.GetInstance();
            SQLiteConnection conn = _db.GetConnection();
            string query = "UPDATE Rooms SET room_number = @rn, type = @tp, availability_status = @as WHERE room_id = @id";
            SQLiteCommand command = new SQLiteCommand(query, conn);
            command.Parameters.AddWithValue("@id", id);
            command.Parameters.Add("@rn", DbType.String).Value = comboBox1.Text;
            command.Parameters.Add("@tp", DbType.String).Value = comboBox2.Text;
            command.Parameters.Add("@as", DbType.String).Value = comboBox3.Text;
            command.ExecuteNonQuery();
            MessageBox.Show("Запись успешно изменена!");
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                _db = ClassProvide.GetInstance();
                SQLiteConnection conn = _db.GetConnection();
                id = dataGridView1.SelectedRows[0].Cells["Column1"].Value.ToString();
                string query = "SELECT room_id, room_number, type, availability_status FROM Rooms WHERE room_id = @id";
                SQLiteCommand cmd = new SQLiteCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                SQLiteDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    string rn = reader["room_number"].ToString();
                    string tp = reader["type"].ToString();
                    string avs = reader["availability_status"].ToString();

                    comboBox1.Text = rn;
                    comboBox2.Text = tp;
                    comboBox3.Text = avs;

                }
            }
        }
    }
}
