using Ambev.DeveloperEvaluation.Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Services
{
    public class DescontoService : IDescontoService
    {
        public decimal CalcularDesconto(int quantidade)
        {
            if (quantidade >= 10 && quantidade <= 20)
                return 0.2m;
            if (quantidade >= 4)
                return 0.1m;
            return 0m;
        }
    }
}
