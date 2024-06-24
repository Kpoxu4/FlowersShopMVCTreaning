using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowersShopMVCTraining.Repository.Enum
{
    [Flags]
    public enum ProductFeatures
    {
        None = 0,
        Bestseller = 2,
        NewArrival = 4,
        DealOfDay = 8
    }
}
