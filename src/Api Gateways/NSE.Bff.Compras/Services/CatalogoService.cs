﻿using Microsoft.Extensions.Options;
using NSE.Bff.Compras.Extensions;
using NSE.Bff.Compras.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace NSE.Bff.Compras.Services
{
    public interface ICatalogoService
    {
        Task<ItemProdutoDTO> ObterPorId(Guid id);
        Task<IEnumerable<ItemProdutoDTO>> ObterItens(IEnumerable<Guid> ids);

    }

    public class CatalogoService : Service, ICatalogoService
    {
        private readonly HttpClient _httpClient;

        public CatalogoService
        (
            HttpClient _httpClient,
            IOptions<AppServicesSettings> settings
        )
        {
            this._httpClient = _httpClient;
            _httpClient.BaseAddress = new Uri(settings.Value.CatalogoUrl);
        }

        public async Task<ItemProdutoDTO> ObterPorId(Guid id)
        {
            var response = await _httpClient.GetAsync($"/catalogo/produtos/{id}");

            TratarErrosResponse(response);

            return await DeserializarObjetoResponse<ItemProdutoDTO>(response);
        }

        public async Task<IEnumerable<ItemProdutoDTO>> ObterItens(IEnumerable<Guid> ids)
        {
            var idsRequest = string.Join(",", ids);

            var response = await _httpClient.GetAsync($"/catalogo/produtos/lista/{idsRequest}/");

            TratarErrosResponse(response);

            return await DeserializarObjetoResponse<IEnumerable<ItemProdutoDTO>>(response);
        }
    }
}
