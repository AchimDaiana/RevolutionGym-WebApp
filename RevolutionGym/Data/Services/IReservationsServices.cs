using RevolutionGym.Data.BaseRepository;
using RevolutionGym.Data.ViewModels;
using RevolutionGym.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RevolutionGym.Data.Services
{
    public interface IReservationsServices : IEntityBaseRepository<Reservation>
    {
        Task<Reservation> GetReservationByIdAsync(int id);
        Task<ReservationDropDownsVM> GetReservationDropDownsData();
        Task AddReservationAsync(ReservationVM data);
        Task UpdateReservationAsync(ReservationVM data);
    }
}
