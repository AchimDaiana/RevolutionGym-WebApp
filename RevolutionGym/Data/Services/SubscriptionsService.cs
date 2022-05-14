using RevolutionGym.Data.BaseRepository;
using RevolutionGym.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RevolutionGym.Data.Services
{
    public class SubscriptionsService : EntityBaseRepository<Subscription>, ISubscriptionsServices
    {
        public SubscriptionsService(ApplicationDbContext context) : base(context)
        {
        }
    }
}
