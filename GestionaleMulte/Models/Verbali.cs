using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestionaleMulte.Models
{
    public class Verbali
    {
        public int IdVerbale { get; set; }

        [Display(Name ="Data Violazione")]
        public DateTime DataViolazione { get; set; }

        [Display(Name ="Luogo Violazione")]
        public string IndirizzoViolazione { get; set; }

        [Display(Name="Agente")]
        public string NominativoAgente { get; set; }

        [Display(Name ="Data Trascrizione Verbale")]
        public DateTime DataTrascrizione { get; set; }

        public double Importo { get; set; }


        [Display(Name ="Punti Decurtati")]
        public int DecurtamentoPunti { get; set; }


        public int IdAnagrafica { get; set; }

        public int IdViolazione { get; set; }






        public static List<Verbali> ListVerbali()
        {
            List<Verbali> verbali = new List<Verbali>();
            string connection = ConfigurationManager.ConnectionStrings["ConnectionDB"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connection);

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("select * from Verbale", conn);
                SqlDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    Verbali p = new Verbali();
                    p.IdVerbale = Convert.ToInt32(reader["IdVerbale"].ToString());
                    p.DataViolazione = Convert.ToDateTime(reader["DataViolazione"].ToString());
                    p.IndirizzoViolazione = reader["IndirizzoViolazione"].ToString();
                    p.NominativoAgente = reader["NominativoAgente"].ToString();
                    p.DataTrascrizione = Convert.ToDateTime(reader["DataTrascrizione"].ToString());
                    p.Importo = Convert.ToDouble(reader["Importo"].ToString());
                    p.DecurtamentoPunti =Convert.ToInt16 (reader["Decurtamento"].ToString());
                    p.IdAnagrafica = Convert.ToInt32(reader["IdAnagrafica"].ToString());
                    p.IdViolazione = Convert.ToInt32(reader["IdViolazione"].ToString());



                    verbali.Add(p);
                }
            }
            catch (Exception)
            {

            }
            finally
            {
                conn.Close();
            }
            return verbali;
        }

        public static void AddVerbale(Verbali p)
        {
            string connection = ConfigurationManager.ConnectionStrings["ConnectionDB"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connection);

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("insert into Verbale values (@DataViolazione,@IndirizzoViolazione,@NominativoAgente,@DataTrascrizione,@Importo,@DecurtamentoPunti,@IdAnagrafica,@IdViolazione)", conn);

                cmd.Parameters.AddWithValue("DataViolazione", p.DataViolazione);
                cmd.Parameters.AddWithValue("IndirizzoViolazione", p.IndirizzoViolazione);
                cmd.Parameters.AddWithValue("NominativoAgente", p.NominativoAgente);
                cmd.Parameters.AddWithValue("DataTrascrizione", p.DataTrascrizione);
                cmd.Parameters.AddWithValue("Importo", p.Importo);
                cmd.Parameters.AddWithValue("DecurtamentoPunti", p.DecurtamentoPunti);
                cmd.Parameters.AddWithValue("IdAnagrafica", p.IdAnagrafica);
                cmd.Parameters.AddWithValue("IdViolazione", p.IdViolazione);




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