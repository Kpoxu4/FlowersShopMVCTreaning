using FlowersShopMVCTraining.Repository.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowersShopMVCTraining.Repository.Model
{
    public class User : BaseModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public UserRole UserRole { get; set; }
    }
}
