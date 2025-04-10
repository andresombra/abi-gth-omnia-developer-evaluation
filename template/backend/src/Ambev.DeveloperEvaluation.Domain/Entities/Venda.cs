using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class Venda : BaseEntity
    {
        public int NumeroVenda { get; set; }
        public DateTime DataVenda { get; set; } = DateTime.UtcNow;
        public Guid ClienteId { get; set; }
        public string ClienteNome { get; set; } = string.Empty;
        public Guid FilialId { get; set; }
        public string FilialNome { get; set; } = string.Empty;
        public bool Cancelada { get; set; }
        public List<ItemVenda> Itens { get; set; } = new();

        public decimal ValorTotal => Itens.Sum(i => i.ValorTotal);

        public Venda()
        {
                
        }
        public Venda(int numeroVenda, Guid clienteId, string clienteNome, Guid filialId, string filialNome)
        {
            NumeroVenda = numeroVenda;
            ClienteId = clienteId;
            ClienteNome = clienteNome;
            FilialId = filialId;
            FilialNome = filialNome;
        }

        public void AdicionarItem(Guid produtoId, string produtoNome, int quantidade, decimal precoUnitario, IDescontoService descontoService)
        {
            var item = new ItemVenda(produtoId, produtoNome, quantidade, precoUnitario, descontoService);
            Itens.Add(item);
        }

        public void Cancelar()
        {
            Cancelada = true;
        }
    }
    
}
