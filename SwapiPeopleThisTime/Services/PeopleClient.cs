
using SwapiPeopleThisTime.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace SwapiPeopleThisTime.Services
{
    public class PeopleClient : IPeopleClient
    {
        private readonly HttpClient _httpClient;

        public PeopleClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<PeopleResponse> GetPeopleInfo()
        {
            var results = await _httpClient.GetAsync("people/?page=1");
            if (results.IsSuccessStatusCode)
            {
                var stringContent = await results.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                };
                var obj = JsonSerializer.Deserialize<PeopleResponse>(stringContent, options);
                return obj;
            }

            else
            {
                throw new HttpRequestException("nobodys home");
            }

        }
        public async Task<PeopleResponse> GetPeopleInfo(string url)
        {
            var results = await _httpClient.GetAsync(url);
            if (results.IsSuccessStatusCode)
            {
                var stringContent = await results.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                };
                var obj = JsonSerializer.Deserialize<PeopleResponse>(stringContent, options);
                return obj;
            }

            else
            {
                throw new HttpRequestException("nobodys home");
            }

        }
    }
}
