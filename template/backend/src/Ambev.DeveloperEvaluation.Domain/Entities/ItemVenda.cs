using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class ItemVenda : BaseEntity
    {
        public Guid ProdutoId { get; private set; }
        public string ProdutoNome { get; private set; } = string.Empty;
        public int Quantidade { get; private set; }
        public decimal PrecoUnitario { get; private set; }
        public decimal Desconto { get; private set; }
        public decimal ValorTotal => CalcularValorTotal();
        public Guid VendaId { get; set; } // FK explícita
        public Venda Venda { get; private set; } = null!;

        public ItemVenda(Guid produtoId, string produtoNome, int quantidade, decimal precoUnitario, IDescontoService descontoService)
        {
            if (quantidade > 20)
                throw new ArgumentException("Não é permitido vender mais de 20 itens idênticos.");

            ProdutoId = produtoId;
            ProdutoNome = produtoNome;
            Quantidade = quantidade;
            PrecoUnitario = precoUnitario;
            Desconto = descontoService.CalcularDesconto(quantidade);
        }

        private decimal CalcularValorTotal()
        {
            var valorSemDesconto = Quantidade * PrecoUnitario;
            var valorComDesconto = valorSemDesconto * (1 - Desconto);
            return valorComDesconto;
        }
    }
}
