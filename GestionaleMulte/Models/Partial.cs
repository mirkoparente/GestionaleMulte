using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace GestionaleMulte.Models
{
    public class Partial
    {
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public int IdVerbali { get; set; }

        public int Punti { get; set; }


        //select raggruppati per trasgressore




        public static List<Partial> joinTrasg()
        {
            List<Partial> list = new List<Partial>();

            string connection = ConfigurationManager.ConnectionStrings["ConnectionDB"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connection);

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("select  Anagrafica.Nome, Anagrafica.Cognome,COUNT(Verbale.IdVerbale) as tot FROM Anagrafica  INNER JOIN Verbale ON Anagrafica.IdAnagrafica = Verbale.IdAnagrafica GROUP BY Anagrafica.Nome, Anagrafica.Cognome", conn);
                SqlDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    Partial p= new Partial();
                    p.Nome = reader["Nome"].ToString();
                    p.Cognome = reader["Cognome"].ToString();
                    p.IdVerbali = Convert.ToInt32(reader["tot"].ToString());
                    
                    list.Add(p);
                }
            }
            catch (Exception)
            {

            }
            finally
            {
                conn.Close();
            }
            return list;
        }
        public static List<Partial> joinPunti()
        {
            List<Partial> list = new List<Partial>();

            string connection = ConfigurationManager.ConnectionStrings["ConnectionDB"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connection);

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("select Anagrafica.Nome, Anagrafica.Cognome, SUM(Verbale.Decurtamento) AS totPunti FROM Anagrafica INNER JOIN Verbale ON Anagrafica.IdAnagrafica = Verbale.IdAnagrafica GROUP BY Anagrafica.Nome, Anagrafica.Cognome", conn);
                SqlDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    Partial p = new Partial();
                    p.Nome = reader["Nome"].ToString();
                    p.Cognome = reader["Cognome"].ToString();
                    p.Punti = Convert.ToInt32(reader["totPunti"].ToString());

                    list.Add(p);
                }
            }
            catch (Exception)
            {

            }
            finally
            {
                conn.Close();
            }
            return list;
        }
    }
}