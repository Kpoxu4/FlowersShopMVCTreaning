using FlowerIdeaSubmissionApi.Models;
using FlowerIdeaSubmissionApi.Repository.Model;
using FlowerIdeaSubmissionApi.Repository.Repository.Interface;

namespace FlowerIdeaSubmissionApi.Mapper
{
    public class IdeaMapper : IIdeaMapper
    {
        private IIdeaRepository _ideaRepository;
        public IdeaMapper(IIdeaRepository ideaRepository)
        {
            _ideaRepository = ideaRepository;
        }

        public Idea CreatedIdeaDb(IdeaModel idea)
        {
            return new Idea
            {
                AuthorName = idea.AuthorName,
                AuthorPhone = idea.AuthorPhone,
                Text = idea.Text,
            };
        }
    }
}
