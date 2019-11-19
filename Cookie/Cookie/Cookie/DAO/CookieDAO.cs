using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cookie.Models;
using System.Windows;
using System.Configuration;

namespace Cookie.DAO
{
    public class CookieDAO
    {
        private MySqlConnection conn;
        private String connectionString = ConfigurationManager.ConnectionStrings["mysql"].ConnectionString;

        public List<CookieClass> listarCookie()
        {
            List<CookieClass> listaCookie = new List<CookieClass>();
            try
            {
                conn = new MySqlConnection(connectionString);
                conn.Open();
                String query = "SELECT * FROM cookie";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Prepare();
                MySqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    CookieClass cookie = new CookieClass()
                    {
                        Id = Convert.ToInt32(dr["id"]),
                        Sabor = Convert.ToString(dr["sabor"]),
                        Valor = Convert.ToDecimal(dr["valor"])
                    };
                    listaCookie.Add(cookie);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return listaCookie;


        }

        public void inserirCookie(CookieClass cookie)
        {
            conn = new MySqlConnection(connectionString);
            conn.Open();
            String query = "INSERT INTO cookie (sabor, valor) VALUES(@sabor,@valor)";
            MySqlCommand cmd = new MySqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@sabor", cookie.Sabor);
            cmd.Parameters.AddWithValue("@valor", cookie.Valor);

            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
