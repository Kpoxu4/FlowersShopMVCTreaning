using FlowerIdeaSubmissionApi.Repository.Model;
using FlowerIdeaSubmissionApi.Repository.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerIdeaSubmissionApi.Repository.Repository
{
    public class IdeaRepository : BaseRepository<Idea>, IIdeaRepository    {

        public IdeaRepository(FlowerIdeaSubmissionApiDbContext dbContext) : base(dbContext) { }
    }
}
