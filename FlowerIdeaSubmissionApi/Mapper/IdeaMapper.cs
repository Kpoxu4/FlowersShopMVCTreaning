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
                AuthorPhone = int.Parse(idea.AuthorPhone),
                Text = idea.Text,
            };
        }
        public List<IdeaModel> CreatedIdeaList(List<Idea> ideas)
        {
            var listIdea = new List<IdeaModel>();

            foreach (var idea in ideas)
            {
                var ideaModel = new IdeaModel
                {
                    AuthorName = idea.AuthorName,
                    AuthorPhone = idea.AuthorPhone.ToString(),
                    Text = idea.Text,
                };
                listIdea.Add(ideaModel);
            }
            return listIdea;
        }
    }
}
