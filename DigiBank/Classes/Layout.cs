using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiBank.Classes
{
    public class Layout
    {
        private static List<Pessoa> pessoas = new List<Pessoa>();
        private static int opcao = 0;

        public static void TelaPrincipal()
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.White;

            Console.Clear();

            Console.WriteLine("                                                                           ");
            Console.WriteLine("                            Digite a Opção Desejada:                       ");
            Console.WriteLine("                            ========================                       ");
            Console.WriteLine("                            1 - Criar Conta                                ");
            Console.WriteLine("                            ========================                       ");
            Console.WriteLine("                            2 - Entrar com CPF e Senha                     ");
            Console.WriteLine("                            ========================                       ");

            opcao = int.Parse(Console.ReadLine());

            switch (opcao)
            {
                case 1:
                    TelaCriarConta();
                    break;
                case 2:
                    TelaLogin();
                    break;
                default:
                    Console.WriteLine("                                    Opção Inválida                            ");
                    Console.WriteLine("                            ==============================                    ");
                    break;
            }
        }

        private static void TelaCriarConta()
        {
            Console.Clear();

            Console.WriteLine("                                                                           ");
            Console.WriteLine("                            Digite seu Nome:                               ");
            string nome = Console.ReadLine();
            Console.WriteLine("                            ========================                       ");
            Console.WriteLine("                            Digite seu CPF:                                ");
            string cpf = Console.ReadLine();
            Console.WriteLine("                            ========================                       ");
            Console.WriteLine("                            Digite sua Senha:                              ");
            string senha = Console.ReadLine();
            Console.WriteLine("                            ========================                       ");

            // Criar conta
            ContaCorrente contaCorrente = new();
            Pessoa pessoa = new();

            pessoa.SetNome(nome);
            pessoa.SetCPF(cpf);
            pessoa.SetSenha(senha);
            pessoa.Conta = contaCorrente;

            pessoas.Add(pessoa);

            Console.Clear();

            Console.WriteLine("                             Conta cadastrada com sucesso                     ");
            Console.WriteLine("                            ==============================                    ");

            Thread.Sleep(1000); // Aguarda 1s ates de seguir para a proxima linha, no caso ir para TelaLogada()

            TelaContaLogada(pessoa);
        }

        private static void TelaLogin()
        {
            Console.Clear();

            Console.WriteLine("                                                                           ");
            Console.WriteLine("                            Digite seu CPF:                                ");
            string cpf = Console.ReadLine();
            Console.WriteLine("                            ========================                       ");
            Console.WriteLine("                            Digite sua Senha:                              ");
            string senha = Console.ReadLine();
            Console.WriteLine("                            ========================                       ");

            // Logar no sistema
            Pessoa pessoa = pessoas.FirstOrDefault(pessoa => pessoa.CPF == cpf && pessoa.Senha == senha);

            if(pessoa != null)
            {
                TelaBoasVindas(pessoa);
                TelaContaLogada(pessoa);
            }
            else
            {
                Console.Clear();

                Console.WriteLine("                                Pessoa não Cadastrada                        ");
                Console.WriteLine("                            ==============================                    ");
            
                Console.WriteLine();
                Console.WriteLine();
            }
        }

        private static void TelaBoasVindas(Pessoa pessoa)
        {
            string msgTelaBemVindo =
                $"{pessoa.Nome} | Banco: {pessoa.Conta.GetCodigoDoBanco()} " +
                $"| Agência: {pessoa.Conta.GetNumeroDaAgencia()} | Conta: {pessoa.Conta.GetNumeroDaConta()} ";

            Console.WriteLine("");
            Console.WriteLine($"          Seja bem vindo, {msgTelaBemVindo} ");
            Console.WriteLine("");
        }

        private static void TelaContaLogada(Pessoa pessoa)
        {
            Console.Clear();

            TelaBoasVindas(pessoa);

            Console.WriteLine("                            Digite a Opção Desejada:                      ");
            Console.WriteLine("                            ==============================                ");
            Console.WriteLine("                            1 - Realizar um Deposiito                     ");
            Console.WriteLine("                            ==============================                ");
            Console.WriteLine("                            2 - Realizar um Saque                         ");
            Console.WriteLine("                            ==============================                ");
            Console.WriteLine("                            3 - Consultar o Saldo                         ");
            Console.WriteLine("                            ==============================                ");
            Console.WriteLine("                            4 - Extrato                                   ");
            Console.WriteLine("                            ==============================                ");
            Console.WriteLine("                            5 - Sair                                      ");
            Console.WriteLine("                            ==============================                ");

            opcao = int.Parse(Console.ReadLine());

            switch (opcao)
            {
                case 1:
                    TelaDeposito(pessoa);
                    break;
                case 2:
                    TelaSaque(pessoa);
                    break;
                case 3:
                    TelaSaldo(pessoa);
                    break;
                case 4:
                    TelaExtrato(pessoa);
                    break;
                case 5:
                    TelaPrincipal();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("                                    Opção Inválida                            ");
                    Console.WriteLine("                            ==============================                    ");
                    break;
            }
        }

        private static void TelaDeposito(Pessoa pessoa)
        {
            Console.Clear();

            TelaBoasVindas(pessoa);

            Console.WriteLine("                            Digite o Valor do Deposito:                       ");
            double valor = double.Parse(Console.ReadLine());
            Console.WriteLine("                          ==============================                      ");

            pessoa.Conta.Deposita(valor);

            Console.Clear();

            TelaBoasVindas(pessoa);

            Console.WriteLine("                                                                              ");
            Console.WriteLine("                                                                              ");
            Console.WriteLine("                   Deposito Realizado com Sucesso                             ");
            Console.WriteLine("                  ================================                            ");
            Console.WriteLine("                                                                              ");
            Console.WriteLine("                                                                              ");

            OpcaoVoltarLogado(pessoa);
        }

        private static void TelaSaque(Pessoa pessoa)
        {
            Console.Clear();

            TelaBoasVindas(pessoa);

            Console.WriteLine("                            Digite o Valor do Saque   :                       ");
            double valor = double.Parse(Console.ReadLine());
            Console.WriteLine("                          ==============================                      ");

            bool okSaque = pessoa.Conta.Saca(valor);

            Console.Clear();

            TelaBoasVindas(pessoa);

            Console.WriteLine("                                                                              ");
            Console.WriteLine("                                                                              ");

            if (okSaque)
            {
                Console.WriteLine("                   Saque Realizado com Sucesso                            ");
                Console.WriteLine("                  ================================                        ");
            }
            else
            {
                Console.WriteLine("                         Saldo Insuficiente                               ");
                Console.WriteLine("                  ================================                        ");
            }

            Console.WriteLine("                                                                              ");
            Console.WriteLine("                                                                              ");

            OpcaoVoltarLogado(pessoa);
        }

        private static void TelaSaldo(Pessoa pessoa)
        {
            Console.Clear();

            TelaBoasVindas(pessoa);

            Console.WriteLine($"                            Seu Saldo é: R$ {pessoa.Conta.ConsultaSaldo()}                         ");
            Console.WriteLine("                          ============================                                              ");

            OpcaoVoltarLogado(pessoa);

        }

        private static void TelaExtrato(Pessoa pessoa)
        {
            Console.Clear();

            TelaBoasVindas(pessoa);

            // Any() verifica se há algo na lista de extrato
            if (pessoa.Conta.Extrato().Any())
            {
                double total = pessoa.Conta.Extrato().Sum(x => x.Valor);

                foreach (Extrato extrato in pessoa.Conta.Extrato())
                {
                    Console.WriteLine("                                                                                               ");
                    Console.WriteLine($"                             Data: {extrato.Data.ToString("dd/MM/yyyy HH:mm:ss")}             ");
                    Console.WriteLine($"                             Tipo de Movimentação: {extrato.Descricao}                        ");
                    Console.WriteLine($"                             Valor: {extrato.Valor}                                           ");
                    Console.WriteLine("                            =====================================                              ");
                }

                Console.WriteLine("                                                                                                   ");
                Console.WriteLine("                                                                                                   ");
                Console.WriteLine($"                             SUB TOTAL: R$ {total}                                                ");
                Console.WriteLine("                            ==============================                                         ");

            }
            else
            {
                Console.WriteLine("                                                                                                   ");
                Console.WriteLine("                             Não Há Extrato a Ser Exibido                                          ");
                Console.WriteLine("                            ==============================                                         ");
            }

            OpcaoVoltarLogado(pessoa);

        }

        private static void OpcaoVoltarLogado(Pessoa pessoa)
        {
            Console.WriteLine("                                                                                                   ");
            Console.WriteLine("                              Entre com uma Opção Abaixo:                                          ");
            Console.WriteLine("                            ==============================                                         ");
            Console.WriteLine("                            1 - Voltar para Minha Conta                                            ");
            Console.WriteLine("                            ==============================                                         ");
            Console.WriteLine("                            2 - Sair                                                               ");
            Console.WriteLine("                            ==============================                                         ");

            opcao = int.Parse(Console.ReadLine());

            if(opcao == 1)
            {
                TelaContaLogada(pessoa);
            }
            else
            {
                TelaPrincipal();
            }
        }

        private static void OpcaoDeslogado()
        {
            Console.WriteLine("                    Entre com uma Opção Abaixo:                             ");
            Console.WriteLine("                  ==============================                            ");
            Console.WriteLine("                  1 - Voltar para o Menu Principal                          ");
            Console.WriteLine("                  =================================                         ");
            Console.WriteLine("                  2 - Sair                                                  ");
            Console.WriteLine("                  =================================                         ");

            opcao = int.Parse(Console.ReadLine());

            if (opcao == 1)
            {
                TelaPrincipal();  
            }
            else
            {
                Console.WriteLine("                                    Opção Inválida                            ");
                Console.WriteLine("                            ==============================                    ");
            }
        }

    }
}
