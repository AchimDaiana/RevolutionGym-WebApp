using RevolutionGym.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RevolutionGym.Data.ViewModels
{
    public class ReservationDropDownsVM
    {
        public ReservationDropDownsVM()
        {
            Trainings = new List<Training>();
        }

        public List<Training> Trainings { get; set; }
    }
}
