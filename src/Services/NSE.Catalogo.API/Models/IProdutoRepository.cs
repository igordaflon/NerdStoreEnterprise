﻿using NSE.Core.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NSE.Catalogo.API.Models
{
    public interface IProdutoRepository : IRepository<Produto>
    {
        Task<IEnumerable<Produto>> ObterTodos();
        Task<Produto> ObterPorId(Guid id);
        Task<List<Produto>> ObterProdutosPorId(string ids);

        void Adicionar(Produto produto);
        void Atualizar(Produto produto);
    }
}
