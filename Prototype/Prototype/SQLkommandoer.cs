using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Prototype
{
    class SQLkommandoer
    {
        public static string HentPatient()
        {
            string navn;
            SqlConnection conn = new SqlConnection(Program.SQLforbindelse);
            SqlCommand Command = new SqlCommand();
            SqlDataReader reader;
            Command.Connection = conn;
            Command.CommandText = "";
            Command.CommandType = CommandType.StoredProcedure;
            conn.Open();
            reader = Command.ExecuteReader();
            navn = reader.GetString(1);    
            conn.Close();
            return navn;
        }
        public static void IndsaetBynavn(int postnr, string navn)
        {
            SqlConnection conn = new SqlConnection(Program.SQLforbindelse);
            SqlCommand Command = new SqlCommand();
            //SqlDataReader reader;
            Command.Connection = conn;
            Command.CommandText = "SPpost";
            Command.CommandType = CommandType.StoredProcedure;
            Command.Parameters.AddWithValue("@postNr", postnr);
            Command.Parameters.AddWithValue("@bynavn", navn);
            conn.Open();
            Command.ExecuteNonQuery();
            conn.Close();
        }
        public static Patient FindPatient(string CPR)
        {
            SqlConnection conn = new SqlConnection(Program.SQLforbindelse);
            SqlCommand Command = new SqlCommand();
            Command.Connection = conn;
            Command.CommandText = "SPfindCPR";
            Command.CommandType = CommandType.StoredProcedure;
            Command.Parameters.AddWithValue("@CPRnr", CPR);
            Patient patient = new Patient();
            conn.Open();
            using (SqlDataReader reader = Command.ExecuteReader())
            {

                //reader = Command.ExecuteReader();
                while (reader.Read())
                    patient = new Patient(reader.GetInt32(0),reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetInt32(5), reader.GetString(6), reader.GetString(7));
            }
            conn.Close();
            return patient;
        }
    }
}
