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
    public class ReservationsService : EntityBaseRepository<Reservation>, IReservationsServices
    {
        private readonly ApplicationDbContext _context;
        public ReservationsService(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddReservationAsync(ReservationVM data)
        {
            var newReservation = new Reservation();
            newReservation.Name = data.Name;
            newReservation.Email = data.Email;
            newReservation.ParticipationHour = data.ParticipationHour;
            newReservation.ParticipationDate = data.ParticipationDate;
            newReservation.TrainingId = data.TrainingId;

            await _context.Reservations.AddAsync(newReservation);
            await _context.SaveChangesAsync();
        }

        public async Task<Reservation> GetReservationByIdAsync(int id)
        {
            var reservationDetails = await _context.Reservations
                .Include(b => b.Training)
                .FirstOrDefaultAsync(m => m.Id == id);

            return reservationDetails;
        }

        public async Task<ReservationDropDownsVM> GetReservationDropDownsData()
        {
            var outcome = new ReservationDropDownsVM();
            outcome.Trainings = await _context.Trainings.OrderBy(m => m.Name).ToListAsync();
            return outcome;
        }

        public async Task UpdateReservationAsync(ReservationVM data)
        {
            var dbReservation = await _context.Reservations.FirstOrDefaultAsync(m => m.Id == data.Id);
            if (dbReservation != null)
            {
                var newReservation = new Reservation();
                dbReservation.Name = data.Name;
                dbReservation.Email = data.Email;
                dbReservation.ParticipationHour = data.ParticipationHour;
                dbReservation.ParticipationDate = data.ParticipationDate;
                dbReservation.TrainingId = data.TrainingId;

                await _context.SaveChangesAsync();
            }

        }
    }
}
