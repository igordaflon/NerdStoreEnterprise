﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NSE.Catalogo.API.Models;
using NSE.WebApi.Core.Controllers;
using NSE.WebApi.Core.Identidade;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NSE.Catalogo.API.Controllers
{
    [Authorize]
    public class CatalogoController : MainController
    {
        private readonly IProdutoRepository _produtoRepository;

        public CatalogoController(IProdutoRepository _produtoRepository)
        {
            this._produtoRepository = _produtoRepository;
        }

        [AllowAnonymous]
        [HttpGet("catalogo/produtos")]
        public async Task<IEnumerable<Produto>> Index()
        {
            return await _produtoRepository.ObterTodos();
        }

        [ClaimsAuthorize("Catalogo", "Ler")]
        [HttpGet("catalogo/produtos/{id}")]
        public async Task<Produto> ProdutoDetalhe(Guid id)
        {
            return await _produtoRepository.ObterPorId(id);
        }

        [HttpGet("catalogo/produtos/lista/{ids}")]
        public async Task<IEnumerable<Produto>> ObterProdutosPorId(string ids)
        {
            return await _produtoRepository.ObterProdutosPorId(ids);
        }
    }
}
