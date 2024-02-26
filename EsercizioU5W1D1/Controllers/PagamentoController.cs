using EsercizioU5W1D1.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Mvc;

namespace EsercizioU5W1D1.Controllers
{
    public class PagamentoController : Controller
    {
        List<Pagamento> pagamenti = new List<Pagamento>();
        // GET: Pagamento
        public ActionResult Index()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Edilizia"].ToString();
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                conn.Open();
                string query = "SELECT * FROM Pagamenti";

                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Pagamento pagamento = new Pagamento(
                        Convert.ToInt16(reader["idPagamento"]),
                        Convert.ToInt16(reader["idDipendente"]),
                        Convert.ToDouble(reader["ammonto"]),
                        reader["tipo_pagamento"].ToString(),
                        Convert.ToDateTime(reader["data_pagamento"])
                        );
                    pagamenti.Add(pagamento);
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
            finally { conn.Close(); }
            return View(pagamenti);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Pagamento pagamento)
        {
            pagamenti.Add(pagamento);

            string connectionString = ConfigurationManager.ConnectionStrings["Edilizia"].ToString();
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                conn.Open();
                string query = "INSERT INTO Pagamenti (idDipendente, ammonto, tipo_pagamento, data_pagamento) " +
                    "VALUES (@idDipendente, @ammonto, @tipo_pagamento, @data_pagamento)";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@idDipendente", pagamento.IdDipendente);
                cmd.Parameters.AddWithValue("@ammonto", pagamento.Ammonto);
                cmd.Parameters.AddWithValue("@tipo_pagamento", pagamento.TipoPagamento);
                cmd.Parameters.AddWithValue("@data_pagamento", pagamento.DataPagamento);

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