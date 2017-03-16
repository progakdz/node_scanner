using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows;

namespace node_scanner
{
    public class DBClass
    {
        const string serverName = "127.0.0.1"; // Адрес сервера
        const string userName = "root"; // Имя пользователя
        const string dbName = "node_list"; //Имя базы данных
        const string port = "3306"; // Порт для подключения
        const string password = "89270022173"; // Пароль для подключения
        const string connStr = "server=" + serverName + 
                               ";user=" + userName +
                               ";database=" + dbName +
                               ";port=" + port +
                               ";password=" + password + ";";
        MySqlConnection conn = new MySqlConnection(connStr);

        private bool startDBConnection()
        {
            try
            {
                conn.Open();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }

        public DataTable getState()
        {
            if (!startDBConnection())
            {
                return null;
            }
            string sql = "SELECT * FROM it_dep"; // Строка запроса
            MySqlCommand sqlCom = new MySqlCommand(sql, conn);
            sqlCom.ExecuteNonQuery();

            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(sqlCom);
            DataTable dt = new DataTable();
            dataAdapter.Fill(dt);

            conn.Close();

            return dt;
        }

        public bool setState(string point, int state)
        {
            try
            {
                if (!startDBConnection())
                {
                    return false;
                }
                string sql = "UPDATE it_dep SET state=" + state + " WHERE point='" + point + "'"; // Строка запроса
                MySqlCommand sqlCom = new MySqlCommand(sql, conn);
                sqlCom.ExecuteNonQuery();

                conn.Close();

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }
    }
}
