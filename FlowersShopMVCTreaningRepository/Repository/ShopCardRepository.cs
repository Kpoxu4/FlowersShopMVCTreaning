using FlowersShopMVCTraining.Repository.Model;
using FlowersShopMVCTrainingRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowersShopMVCTraining.Repository.Repository
{
    public class ShopCardRepository : BaseRepository<ShopCard>
    {
        public ShopCardRepository(FlowersShopDbContext dbContext) : base(dbContext) { }
    }
}
