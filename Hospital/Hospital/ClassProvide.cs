using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace Hospital
{
    internal class ClassProvide
    {

        private static ClassProvide _instance;
        private SQLiteConnection _connection;

        private ClassProvide()
        {
            _connection = new SQLiteConnection("Data Source=C:\\Users\\Андрей\\Desktop\\курсач\\hospital.db");
            _connection.Open();
        }

        public static ClassProvide GetInstance()
        {
            if (_instance == null)
            {
                _instance = new ClassProvide();
            }
            return _instance;
        }

        public SQLiteConnection GetConnection()
        {
            return _connection;
        }

        public void CloseConnection()
        {
            if (_connection != null)
            {
                _connection.Close();
            }
        }

    }
}
