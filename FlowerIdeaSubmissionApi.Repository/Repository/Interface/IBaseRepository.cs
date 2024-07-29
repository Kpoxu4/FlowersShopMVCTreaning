using FlowerIdeaSubmissionApi.Repository.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerIdeaSubmissionApi.Repository.Repository.Interface
{
    public interface IBaseRepository<DbModel> where DbModel : BaseModel
    {
        bool Any();
        DbModel Create(DbModel model);
        void Delete(DbModel model);
        void Delete(int id);
        DbModel? Get(int id);
        List<DbModel> GetAll();
    }
}
