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
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
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
    }
}
