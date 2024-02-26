using EsercizioU5W1D1.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Mvc;

namespace EsercizioU5W1D1.Controllers
{
    public class DipendenteController : Controller
    {
        List<Dipendente> dipendenti = new List<Dipendente>();
        // GET: Dipendente
        public ActionResult Index()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Edilizia"].ToString();
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                conn.Open();
                string query = "SELECT * FROM Dipendenti";

                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Dipendente dipendente = new Dipendente(
                        Convert.ToInt16(reader["idDipendente"]),
                        reader["nome"].ToString(),
                        reader["cognome"].ToString(),
                        reader["indirizzo"].ToString(),
                        reader["codice_fiscale"].ToString(),
                        Convert.ToBoolean(reader["sposato"]),
                        Convert.ToInt16(reader["n_figli"]),
                        reader["mansione"].ToString()
                        );
                    dipendenti.Add(dipendente);
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
            finally { conn.Close(); }
            return View(dipendenti);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Dipendente dipendente)
        {
            dipendenti.Add(dipendente);

            string connectionString = ConfigurationManager.ConnectionStrings["Edilizia"].ToString();
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                conn.Open();
                string query = "INSERT INTO Dipendenti (nome, cognome, indirizzo, codice_fiscale, sposato, n_figli, mansione) " +
                    "VALUES (@nome, @cognome, @indirizzo, @codice_fiscale, @sposato, @n_figli, @mansione)";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@nome", dipendente.Nome);
                cmd.Parameters.AddWithValue("@cognome", dipendente.Cognome);
                cmd.Parameters.AddWithValue("@indirizzo", dipendente.Indirizzo);
                cmd.Parameters.AddWithValue("@codice_fiscale", dipendente.CodiceFiscale);
                cmd.Parameters.AddWithValue("@sposato", dipendente.Sposato);
                cmd.Parameters.AddWithValue("@n_figli", dipendente.FigliACarico);
                cmd.Parameters.AddWithValue("@mansione", dipendente.Mansione);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
            finally { conn.Close(); }

            return View();
        }
    }
}