using DigiBank.Contratos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiBank.Classes
{
    public abstract class Conta : Banco, IConta
    {

        // Construtor
        public Conta()
        {
            NumeroDaAgencia = "0001";
            NumeroDaContaSequencial++;
            Movimentacoes = new List<Extrato>();
        }

        // Atributos
        public double Saldo { get; protected set; }
        public string NumeroDaAgencia { get; private set; }
        public string NumeroDaConta { get; protected set; }
        public static int NumeroDaContaSequencial { get; private set; }

        private List<Extrato> Movimentacoes;

        // Métodos
        public double ConsultaSaldo()
        {
            return Saldo;
        }

        public void Deposita(double valor)
        {
            DateTime dataAtual = DateTime.Now;

            Movimentacoes.Add(new Extrato(dataAtual, "Deposito", valor ));
            Saldo += valor;
        }

        public bool Saca(double valor)
        {
           if(valor > ConsultaSaldo())
            {
                return false;
            }
            else
            {
                DateTime dataAtual = DateTime.Now;

                Movimentacoes.Add(new Extrato(dataAtual, "Saque", -valor));

                Saldo -= valor;
                return true;
            }
        }

        public string GetCodigoDoBanco()
        {
            return CodigoDoBanco;
        }

        public string GetNumeroDaAgencia()
        {
            return NumeroDaAgencia;
        }

        public string GetNumeroDaConta()
        {
            return NumeroDaConta;
        }

        public List<Extrato> Extrato()
        {
            return Movimentacoes;
        }
    }
}
