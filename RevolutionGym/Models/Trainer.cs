using RevolutionGym.Data.BaseRepository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RevolutionGym.Models
{
    public class Trainer : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Prenume")]
        [Required(ErrorMessage = "Caseta 'Prenume' trebuie completata!")]
        [StringLength(10, MinimumLength = 3, ErrorMessage = "Caseta 'Prenumele' trebuie sa contina intre 3 si 10 caractere!")]
        public string FirstName { get; set; }

        [Display(Name = "Nume")]
        [Required(ErrorMessage = "Caseta 'Nume' trebuie completata!")]
        [StringLength(10, MinimumLength = 3, ErrorMessage = "Caseta 'Nume' trebuie sa contina intre 3 si 10 caractere!")]
        public string LastName { get; set; }

        [Display(Name = "Poza de profil")]
        public string ProfilePicture { get; set; }

        [Display(Name = "Biografie")]
        [Required(ErrorMessage = "Caseta 'Biografie' trebuie completata!")]
        public string Biography { get; set; }
    }
}
