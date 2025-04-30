using chetirehpalubnik.Entities;
using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chetirehpalubnik
{
    public class Database
    {
        private readonly MySqlConnection _connection = new MySqlConnection("server=localhost; user=root; database=kanstov; port=3306; password=Test!2345");

        public List<Tovar> GetTovars()
        {
            List<Tovar> tovarlst = new List<Tovar>();

            string Query = "select Tovar.Id_tovar, Tovar.Naimenovanie, Category_tovar.Category_tovar,Tovar.Opisanie, " +
                          "Tovar.Price, Tovar.Size_max_vozmog_sale, Tovar.Picture, Tovar.Deistvyushay_sale " +
                          "from Tovar " +
                          "JOIN Category_tovar ON Tovar.ID_Category_tovara = Category_tovar.ID_Category_tovara " +
                          "JOIN Proizvoditel ON Tovar.ID_Proizvoditela = Proizvoditel.ID_Proizvoditela " +
                          "JOIN Postavshik ON Tovar.ID_Postavshika = Postavshik.ID_Postavshika";

            try
            {
                _connection.Open();

                MySqlCommand command = new MySqlCommand(Query, _connection);

                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Tovar tovar = new Tovar();

                    tovar.Id_tovar = Convert.ToInt32(reader["Id_tovar"]); 
                    tovar.Naimenovanie = reader["Naimenovanie"].ToString();
                    tovar.Category_tovara = reader["Category_tovar"].ToString();                   
                    tovar.Opisanie = reader["Opisanie"].ToString();
                    tovar.Price = Convert.ToDecimal(reader["Price"]);
                    tovar.Size_max_vozmog_sale = Convert.ToInt32(reader["Size_max_vozmog_sale"]);
                    tovar.Picture = reader["Picture"].ToString();
                    tovar.Deistvyushay_sale = Convert.ToInt32(reader["Deistvyushay_sale"]);
                    tovarlst.Add(tovar);
                    Console.WriteLine(tovar);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                _connection.Close();
            }
            return tovarlst;
        }
    }
}


       