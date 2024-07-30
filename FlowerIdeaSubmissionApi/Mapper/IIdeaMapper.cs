using FlowerIdeaSubmissionApi.Models;
using FlowerIdeaSubmissionApi.Repository.Model;

namespace FlowerIdeaSubmissionApi.Mapper
{
    public interface IIdeaMapper
    {
        Idea CreatedIdeaDb(IdeaModel idea);
    }
}