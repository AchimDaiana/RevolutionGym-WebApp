using RevolutionGym.Data.BaseRepository;
using RevolutionGym.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RevolutionGym.Models
{
    public class Training : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Picture { get; set; }

        public DateTime StartHour { get; set; }

        public DateTime FinishHour { get; set; }

        public TrainingCategory Category { get; set; }

        //relatia cu rezervarile
        public List<Reservation> Reservations { get; set; }

        //relatia cu antrenorii
        public int TrainerId { get; set; }
        public Trainer Trainer { get; set; }

        //relatia cu abonamentele
        public int SubscriptionId { get; set; }
        public Subscription Subscription { get; set; }
    }
}
