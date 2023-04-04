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
            NumeroDaConta = "0001";
            NumeroDaContaSequencial++;

        }

        // Atributos
        public double Saldo { get; protected set; }
        public string NumeroDaAgencia { get; private set; }
        public string NumeroDaConta { get; protected set; }
        public static int NumeroDaContaSequencial { get; private set; }

        // Métodos
        public double ConsultaSaldo()
        {
            return Saldo;
        }

        public void Deposita(double valor)
        {
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


    }
}
