using FlowersShopMVCTraining.Service.Apis.Interface;
using FlowersShopMVCTraining.Services.Dtos;
using Microsoft.AspNetCore.Mvc;


namespace FlowersShopMVCTraining.Services.Apis
{
    public class HttpApiJoke : IHttpApiJoke
    {
        private HttpClient _httpClient;

        public HttpApiJoke(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        [HttpGet]
        public async Task<JokeDto> GetRandomJokeAsync()
        {
            var response = await _httpClient.GetAsync("/jokes/random");
            response.EnsureSuccessStatusCode();
            var joke = await response.Content.ReadFromJsonAsync<JokeDto>();
            return joke;
        }

        
    }
}
