﻿using System.Net.Http.Json;
using HotPotato.Domain.Entities;
using HotPotato.Domain.Interfaces;

namespace HotPotato.Communication;

public class Http : ICommunicationProvider
{
    private readonly HttpClient httpClient;
    public Http(string endpoint)
    {
        this.httpClient = new HttpClient
        {
            BaseAddress = new Uri($"http://{endpoint}")
        };
    }

    public async Task<string> Throw(string route, Potato potato)
    {
        return await (await this.httpClient.PostAsJsonAsync(route, potato))
            .Content
            .ReadAsStringAsync();
    }
}