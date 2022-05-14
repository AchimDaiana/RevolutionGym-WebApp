using RevolutionGym.Data.BaseRepository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RevolutionGym.Models
{
    public class Reservation : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Numele si prenume")]
        public string Name { get; set; }

        public string Email { get; set; }

        [Display(Name = "Ora participarii")]
        // [DisplayFormat(DataFormatString = "{hh:mm tt}")]
        public DateTime ParticipationHour { get; set; }

        [Display(Name = "Data participarii")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime ParticipationDate { get; set; }

        //relatia cu clasele
        public int TrainingId { get; set; }
        [Display(Name = "Antrenamentul rezervat")]
        public Training Training { get; set; }
    }
}
