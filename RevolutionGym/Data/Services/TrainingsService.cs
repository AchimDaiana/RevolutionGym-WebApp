using Microsoft.EntityFrameworkCore;
using RevolutionGym.Data.BaseRepository;
using RevolutionGym.Data.ViewModels;
using RevolutionGym.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RevolutionGym.Data.Services
{
    public class TrainingsService : EntityBaseRepository<Training>, ITrainingsServices
    {
        private readonly ApplicationDbContext _context;

        public TrainingsService(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddTrainingAsync(TrainingVM data)
        {
            var newTraining = new Training();
            newTraining.Name = data.Name;
            newTraining.Description = data.Description;
            newTraining.Picture = data.Picture;
            newTraining.StartHour = data.StartHour;
            newTraining.FinishHour = data.FinishHour;
            newTraining.Category = data.Category;
            newTraining.TrainerId = data.TrainerId;
            newTraining.SubscriptionId = data.SubscriptionId;

            await _context.Trainings.AddAsync(newTraining);
            await _context.SaveChangesAsync();


        }

        public async Task<Training> GetTrainingByIdAsync(int id)
        {
            var trainingDetails = await _context.Trainings
                .Include(b => b.Trainer)
                .Include(c => c.Subscription)
                .FirstOrDefaultAsync(m => m.Id == id);

            return trainingDetails;
        }

        public async Task<TrainingDropDownsVM> GetTrainingDropDownsData()
        {
            var outcome = new TrainingDropDownsVM();
            outcome.Trainers = await _context.Trainers.OrderBy(m => m.FirstName).ToListAsync();
            outcome.Subscriptions = await _context.Subscriptions.OrderBy(m => m.Name).ToListAsync();
            return outcome;
        }

        public async Task UpdateTrainingAsync(TrainingVM data)
        {
            var dbTraining = await _context.Trainings.FirstOrDefaultAsync(m => m.Id == data.Id);

            if (dbTraining != null)
            {
                dbTraining.Name = data.Name;
                dbTraining.Description = data.Description;
                dbTraining.Picture = data.Picture;
                dbTraining.StartHour = data.StartHour;
                dbTraining.FinishHour = data.FinishHour;
                dbTraining.Category = data.Category;
                dbTraining.TrainerId = data.TrainerId;
                dbTraining.SubscriptionId = data.SubscriptionId;


                await _context.SaveChangesAsync();
            }


        }
    }
}
