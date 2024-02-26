using System;

namespace EsercizioU5W1D1.Models
{
    public class Pagamento
    {
        public int IdPagamento { get; set; }
        public int IdDipendente { get; set; }
        public double Ammonto { get; set; }
        public string TipoPagamento { get; set; }
        public DateTime DataPagamento { get; set; }

        public Pagamento() { }
        public Pagamento(int idPagamento, int idDipendente, double ammonto, string tipoPagamento, DateTime dataPagamento)
        {
            IdPagamento = idPagamento;
            IdDipendente = idDipendente;
            Ammonto = ammonto;
            TipoPagamento = tipoPagamento;
            DataPagamento = dataPagamento;
        }

    }
}