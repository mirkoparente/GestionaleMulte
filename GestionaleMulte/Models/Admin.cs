using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace GestionaleMulte.Models
{
    public class Admin
    {
        public int IdAdmin { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }



        public static List<Admin> AllAdmin()
        {
            List<Admin> admin = new List<Admin>();

            string connection = ConfigurationManager.ConnectionStrings["ConnectionDB"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connection);

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("select * from Admin", conn);
                SqlDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                   Admin a = new Admin();
                    a.IdAdmin = Convert.ToInt32(reader["IdAdmin"].ToString());
                    a.Username = reader["Username"].ToString();
                    a.Password = reader["Password"].ToString();
                   
                    admin.Add(a);
                }


            }
            catch (Exception)
            {

            }
            finally
            {
                conn.Close();
            }
            return admin;
        }
    }
}