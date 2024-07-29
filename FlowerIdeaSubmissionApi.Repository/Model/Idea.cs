using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerIdeaSubmissionApi.Repository.Model
{
    public class Idea : BaseModel
    {
        public string AuthorName { get; set; }
        public int AuthorPhone { get; set; }
        public string Text { get; set; }
    }
}
