using FlowersShopMVCTraining.Services.Dtos;

namespace FlowersShopMVCTraining.Service.Apis.Interface
{
    public interface IHttpApiJoke
    {
        Task<JokeDto> GetRandomJokeAsync();
    }
}