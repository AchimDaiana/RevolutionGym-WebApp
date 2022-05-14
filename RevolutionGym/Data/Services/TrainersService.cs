using RevolutionGym.Data.BaseRepository;
using RevolutionGym.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RevolutionGym.Data.Services
{
    public class TrainersService : EntityBaseRepository<Trainer>, ITrainersServices
    {
        public TrainersService(ApplicationDbContext context) : base(context)
        {
        }

    }
}
