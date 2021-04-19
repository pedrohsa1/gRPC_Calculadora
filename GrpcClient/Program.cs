using Grpc.Core;
using Grpc.Net.Client;
using GrpcServer;
using System;
using System.Threading.Tasks;

namespace GrpcClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var calculadoaClient = new Calculadora.CalculadoraClient(channel);

            Console.Write("Digite o N1: ");
            int n1 = Int32.Parse(Console.ReadLine());

            Console.Write("Digite o N2: ");
            int n2 = Int32.Parse(Console.ReadLine());

            Console.WriteLine($"Termo 1: { n1 }"); 
            Console.WriteLine($"Termo 2: { n2 }");

            var clientRequested = new CalculadoraLookupModel { 
                N1 = n1, 
                N2 = n2
            };

            var calculadora = await calculadoaClient.GetCalculadoraInfoAsync(clientRequested);

            Console.WriteLine("");
            Console.WriteLine("");

            Console.WriteLine("### Servidor ###");
            Console.WriteLine("Soma: ");
            Console.WriteLine($"{ calculadora.N1 } + { calculadora.N2 } = {calculadora.Soma}");
            Console.WriteLine("Subtração: ");
            Console.WriteLine($"{ calculadora.N1 } - { calculadora.N2 } = {calculadora.Subtracao}");
            Console.WriteLine("Multiplicação: ");
            Console.WriteLine($"{ calculadora.N1 } * { calculadora.N2 } = {calculadora.Multiplicacao}");
            Console.WriteLine("Divisão: ");
            Console.WriteLine($"{ calculadora.N1 } / { calculadora.N2 } = {calculadora.Divisao}");

            Console.WriteLine();
            Console.WriteLine("Novo Calculo");
            Console.WriteLine();

            Console.ReadLine();
        }
    }
}
