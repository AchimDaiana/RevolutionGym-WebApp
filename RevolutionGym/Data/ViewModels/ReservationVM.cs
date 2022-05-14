using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RevolutionGym.Data.ViewModels
{
    public class ReservationVM
    {
        public int Id { get; set; }

        [Display(Name = "Numele si prenume")]
        [Required(ErrorMessage = "Caseta 'Numele si prenume' trebuie completata!")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Caseta 'Numele si prenume' trebuie sa contina intre 3 si 20 de caractere!")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Caseta 'Email' trebuie completata!")]
        public string Email { get; set; }

        [Display(Name = "Selecteaza ora participarii")]
        [Required(ErrorMessage = "Caseta 'Ora participarii' trebuie completata!")]
        public DateTime ParticipationHour { get; set; }

        [Display(Name = "Data participarii")]
        [Required(ErrorMessage = "Caseta 'Data participarii' trebuie completata!")]
        public DateTime ParticipationDate { get; set; }

        [Display(Name = "Selecteaza antrenamentul")]
        [Required(ErrorMessage = "Caseta 'Antrenament' trebuie completata!")]
        public int TrainingId { get; set; }
    }
}
