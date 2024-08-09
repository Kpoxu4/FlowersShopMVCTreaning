using FlowersShopMVCTraining.Service.Apis.Interface;
using FlowersShopMVCTraining.Service.Dtos;
using FlowersShopMVCTraining.Services.Dtos;
using System.Collections.Generic;

namespace FlowersShopMVCTraining.Service.Apis
{
    public class HttpIdeaSubmission : IHttpIdeaSubmission
    {
        private HttpClient _httpClient;

        public HttpIdeaSubmission(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<IdeaDto>> GetIdeasAsync()
        {
            var response = await _httpClient.GetAsync("api/FlowerIdeaSubmissionApi/GetAllIdeas");
            response.EnsureSuccessStatusCode();
            var listIdea = await response.Content.ReadFromJsonAsync<List<IdeaDto>>();

            return listIdea;
        }
    }
}
