using Grpc.Core;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrpcServer.Services
{
    public class CalculadoraService : Calculadora.CalculadoraBase
    {
        private readonly ILogger<CalculadoraService> _logger;
        public CalculadoraService(ILogger<CalculadoraService> logger)
        {
            _logger = logger;
        }

        public override Task<CalculadoraModel> GetCalculadoraInfo(CalculadoraLookupModel request, ServerCallContext context)
        {
            CalculadoraModel output = new CalculadoraModel();

            output.N1 = request.N1;
            output.N2 = request.N2;
            output.Soma = output.N1 + output.N2;
            output.Subtracao = output.N1 - output.N2;
            output.Multiplicacao = output.N1 * output.N2;
            output.Divisao = output.N1 / output.N2;

            return Task.FromResult(output);
        }
    }
}
