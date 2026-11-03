using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Net.Http.Headers;

namespace RestAPI
{
    public class API
    {
        readonly HttpClient _httpClient;

        public API(string base_url)
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(base_url);
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public record JokeResponse(string setup, string delivery, JokeFlags flags, int id);
        public record JokeFlags
        (
            bool nsfw,
            bool religious,
            bool political,
            bool racist,
            bool sexist,
            bool @explicit
        );

        public async Task<JokeResponse?> GetJokeAsync(string path, CancellationToken cancellationToken)
        {
            JokeResponse? response = null;

            HttpResponseMessage httpResponse = await _httpClient.GetAsync(path);
            if (httpResponse.IsSuccessStatusCode)
            {
                string str = await httpResponse.Content.ReadAsStringAsync(cancellationToken);

                if (!cancellationToken.IsCancellationRequested)
                    response = JsonSerializer.Deserialize<JokeResponse>(str);
            }

            return response;
        }
    }
}
