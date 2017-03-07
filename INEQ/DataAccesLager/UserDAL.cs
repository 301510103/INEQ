#region using directives
using Entities;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace DataAccesLager
{
    public class UserDAL
    {
        private static IneqContext db = new IneqContext();
        public static string CONNECTIONSTRING = "server=localhost;uid=root;pwd=gotcha1349164;database=Ineq";
        public static bool iniciarSesion(string us, string pwd)
        {
            //selec count (*) frome User Where Username = 'us' AND Password ='pwd'
            //return db.Users.Where(u => u.Username == us && u.Password == pwd).Count() > 0; //-->LINQ LAMBDA
            try
            {
                //1 creamos objeto coneccion y le pasamos la cadena de coneccion ubicada en el archivo app.config
                //SqlConnection sqlConn = new SqlConnection(CONNECTIONSTRING);
                MySqlConnection sqlConn = new MySqlConnection(CONNECTIONSTRING);
                //2 abrir la conccion
                sqlConn.Open();

                //3 crar el query que utilizaras
                string query = "select * From User Where Username = @username AND Password = @password";

                //4 crar el objeto comando al cual le pasas el query y la coneccion para ejecutar el query a
                //antes mencionado
                //SqlCommand cmd = new SqlCommand(query, sqlConn);
                MySqlCommand cmd = new MySqlCommand(query, sqlConn);

                //5 agregaar los paramettros necesarios
                cmd.Parameters.AddWithValue("@username", us);
                cmd.Parameters.AddWithValue("@password", pwd);

                //6 ejecutar el query y guardar el resultado
                //SqlDataReader dr = cmd.ExecuteReader();
                MySqlDataReader dr = cmd.ExecuteReader();

                //7° - validar si contiene registros
                if (dr.HasRows)
                {
                    return true;
                }
                else
                {
                    return false;
                }
                sqlConn.Close();
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
