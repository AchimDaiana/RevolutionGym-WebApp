using RevolutionGym.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RevolutionGym.Data.ViewModels
{
    public class TrainingVM
    {
        public int Id { get; set; }

        [Display(Name = "Numele antrenamentului")]
        [Required(ErrorMessage = "Caseta 'Numele antrenamentului' trebuie completata!")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Caseta 'Numele antrenamentului' trebuie sa contina intre 3 si 50 de caractere!")]
        public string Name { get; set; }

        [Display(Name = "Descrierea antrenamentului")]
        [Required(ErrorMessage = "Caseta 'Descrierea antrenamentului' trebuie completata!")]
        public string Description { get; set; }

        [Display(Name = "Incarca o imagine")]
        public string Picture { get; set; }

        [Display(Name = "Selecteaza ora inceperii antrenamentului")]
        [Required(ErrorMessage = "Caseta 'Ora inceperii antrenamentului' trebuie completata!")]
        public DateTime StartHour { get; set; }

        [Display(Name = "Selecteaza ora finalizarii antrenamentului")]
        [Required(ErrorMessage = "Caseta 'Ora finalizarii antrenamentului' trebuie completata!")]
        public DateTime FinishHour { get; set; }

        [Display(Name = "Selecteaza categoria antrenamentului")]
        [Required(ErrorMessage = "Caseta 'Categoria antrenamentului' trebuie completata!")]
        public TrainingCategory Category { get; set; }


        public List<int> ReservationsIds { get; set; }

        [Display(Name = "Selecteaza antrenorul")]
        [Required(ErrorMessage = "Caseta 'Antrenor' trebuie completata!")]
        public int TrainerId { get; set; }

        [Display(Name = "Selecteaza abonamentul")]
        [Required(ErrorMessage = "Caseta 'Abonament' trebuie completata!")]
        public int SubscriptionId { get; set; }
    }
}
