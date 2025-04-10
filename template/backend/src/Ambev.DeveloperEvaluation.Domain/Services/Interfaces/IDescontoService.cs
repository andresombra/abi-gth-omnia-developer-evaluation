using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Services.Interfaces
{
    public interface IDescontoService
    {
        decimal CalcularDesconto(int quantidade);
    }
}
