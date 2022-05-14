using RevolutionGym.Data.BaseRepository;
using RevolutionGym.Data.ViewModels;
using RevolutionGym.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RevolutionGym.Data.Services
{
    public interface ITrainingsServices : IEntityBaseRepository<Training>
    {
        Task<Training> GetTrainingByIdAsync(int id);

        Task<TrainingDropDownsVM> GetTrainingDropDownsData();

        Task AddTrainingAsync(TrainingVM data);

        Task UpdateTrainingAsync(TrainingVM data);
    }
}
