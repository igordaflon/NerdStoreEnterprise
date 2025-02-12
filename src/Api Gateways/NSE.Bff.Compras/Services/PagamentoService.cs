﻿using Microsoft.Extensions.Options;
using NSE.Bff.Compras.Extensions;
using System;
using System.Net.Http;

namespace NSE.Bff.Compras.Services
{
    public interface IPagamentoService
    {

    }

    public class PagamentoService : Service, IPagamentoService
    {
        private readonly HttpClient _httpClient;

        public PagamentoService
        (
            HttpClient _httpClient,
            IOptions<AppServicesSettings> settings
        )
        {
            this._httpClient = _httpClient;
            _httpClient.BaseAddress = new Uri(settings.Value.PagamentoUrl);
        }
    }
}
