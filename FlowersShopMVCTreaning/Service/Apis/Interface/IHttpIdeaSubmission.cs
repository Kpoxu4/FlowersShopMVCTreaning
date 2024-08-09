using FlowersShopMVCTraining.Service.Dtos;

namespace FlowersShopMVCTraining.Service.Apis.Interface
{
    public interface IHttpIdeaSubmission
    {
        Task<List<IdeaDto>> GetIdeasAsync();
    }
}