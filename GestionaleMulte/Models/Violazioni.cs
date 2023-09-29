using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace GestionaleMulte.Models
{
    public class Violazioni
    {
        public int IdViolazioni { get; set; }
        public string Descrizione { get; set; }



        public static List<Violazioni> AllVio()
        {
            List<Violazioni> violazioni = new List<Violazioni>();

            string connection = ConfigurationManager.ConnectionStrings["ConnectionDB"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connection);

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("select * from TipoViolazione", conn);
                SqlDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    Violazioni v = new Violazioni();
                    v.IdViolazioni = Convert.ToInt32(reader["IdViolazione"].ToString());
                    v.Descrizione = reader["Descrizione"].ToString();


                    violazioni.Add(v);
                }


            }
            catch (Exception)
            {

            }
            finally
            {
                conn.Close();
            }
            return violazioni;
        }



        public static void AddVio(Violazioni p)
        {
            string connection = ConfigurationManager.ConnectionStrings["ConnectionDB"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connection);

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("insert into TipoViolazione values (@Descrizione)", conn);

                cmd.Parameters.AddWithValue("Descrizione", p.Descrizione);
                



                cmd.ExecuteNonQuery();



            }
            catch (Exception)
            {

            }
            finally
            {
                conn.Close();
            }

        }


        public static Violazioni DettaglioP(int id)
        {
            string connection = ConfigurationManager.ConnectionStrings["ConnectionDB"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connection);

            Violazioni p = new Violazioni();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand($"select * from TipoViolazione where IdViolazione={id}", conn);

                SqlDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    p.IdViolazioni = Convert.ToInt32(reader["IdViolazione"].ToString());
                    p.Descrizione = reader["Descrizione"].ToString();
                  


                }
            }
            catch (Exception)
            {

            }
            finally
            {
                conn.Close();
            }
            return p;
        }


        public static void ModificaVio(Violazioni p)
        {
            string connection = ConfigurationManager.ConnectionStrings["ConnectionDB"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connection);

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand($"update TipoViolazione set Descrizione=@Descrizione where IdViolazione={p.IdViolazioni}", conn);


                cmd.Parameters.AddWithValue("Descrizione", p.Descrizione);
               


                cmd.ExecuteNonQuery();

            }
            catch (Exception)
            {

            }
            finally
            {
                conn.Close();
            }
        }

        public static void Delete(int id)
        {
            string connection = ConfigurationManager.ConnectionStrings["ConnectionDB"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connection);
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand($"delete from TipoViolazione where IdViolazione={id}", conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {

            }
            finally
            {
                conn.Close();
            }
        }
    }
}