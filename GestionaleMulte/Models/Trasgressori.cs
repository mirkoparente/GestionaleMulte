using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace GestionaleMulte.Models
{
    public class Trasgressori
    {
        public int IdTrasgressori { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public string Indirizzo { get; set; }
        public string Citta { get; set; }
        public string CAP { get; set; }


        [Display(Name ="Codice Fiscale")]
        public string CodFisc { get; set; }



        public static List<Trasgressori> ListTrasg()
        {
            List<Trasgressori> trasgressori = new List<Trasgressori>();
            string connection = ConfigurationManager.ConnectionStrings["ConnectionDB"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connection);

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("select * from Anagrafica", conn);
                SqlDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    Trasgressori p = new Trasgressori();
                    p.IdTrasgressori = Convert.ToInt32(reader["IdAnagrafica"].ToString());
                    p.Nome = reader["Nome"].ToString();
                    p.Cognome = reader["Cognome"].ToString();
                    p.Indirizzo = reader["Indirizzo"].ToString();
                    p.Citta = reader["Citta"].ToString();
                    p.CAP = reader["Cap"].ToString();
                    p.CodFisc = reader["CodFisc"].ToString();


                    trasgressori.Add(p);
                }
            }
            catch (Exception)
            {

            }
            finally
            {
                conn.Close();
            }
            return trasgressori;
        }




        public static void AddTrasg(Trasgressori p)
        {
            string connection = ConfigurationManager.ConnectionStrings["ConnectionDB"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connection);

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("insert into Anagrafica values (@Nome,@Cognome,@Indirizzo,@Citta,@CAP,@CodFisc)", conn);

                cmd.Parameters.AddWithValue("Nome", p.Nome);
                cmd.Parameters.AddWithValue("Cognome", p.Cognome);
                cmd.Parameters.AddWithValue("Indirizzo", p.Indirizzo);
                cmd.Parameters.AddWithValue("Citta", p.Citta);
                cmd.Parameters.AddWithValue("CAP", p.CAP);
                cmd.Parameters.AddWithValue("CodFisc", p.CodFisc);



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



        public static Trasgressori DettaglioP(int id)
        {
            string connection = ConfigurationManager.ConnectionStrings["ConnectionDB"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connection);

            Trasgressori p = new Trasgressori();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand($"select * from Anagrafica where IdAnagrafica={id}", conn);

                SqlDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    p.IdTrasgressori = Convert.ToInt32(reader["IdAnagrafica"].ToString());
                    p.Nome = reader["Nome"].ToString();
                    p.Cognome = reader["Cognome"].ToString();
                    p.Indirizzo = reader["Indirizzo"].ToString();
                    p.Citta = reader["Citta"].ToString();
                    p.CAP = reader["Cap"].ToString();
                    p.CodFisc = reader["CodFisc"].ToString();


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


        public static void ModificaTrasg(Trasgressori p)
        {
            string connection = ConfigurationManager.ConnectionStrings["ConnectionDB"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connection);

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("update Anagrafica set Nome=@Nome,Cognome=@Cognome,Indirizzo=@Indirizzo,Citta=@Citta,CAP=@CAP,CodFisc=@CodFisc where IdAnagrafica=@IdTrasgressori", conn);


                cmd.Parameters.AddWithValue("IdTrasgressori", p.IdTrasgressori);
                cmd.Parameters.AddWithValue("Nome", p.Nome);
                cmd.Parameters.AddWithValue("Cognome", p.Cognome);
                cmd.Parameters.AddWithValue("Indirizzo", p.Indirizzo);
                cmd.Parameters.AddWithValue("Citta", p.Citta);
                cmd.Parameters.AddWithValue("CAP", p.CAP);
                cmd.Parameters.AddWithValue("CodFisc", p.CodFisc);



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
                SqlCommand cmd = new SqlCommand($"delete from Anagrafica where IdAnagrafica={id}", conn);
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