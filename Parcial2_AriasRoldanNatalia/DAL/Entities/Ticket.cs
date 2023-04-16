using System.ComponentModel.DataAnnotations;

namespace Parcial2_AriasRoldanNatalia.DAL.Entities
{
    public class Ticket : Entity
    {
        [Display(Name = "Usada")]
        public bool IsUsed { get; set; }

        [Display(Name = "Fecha de uso")]
        public DateTime? UseDate { get; set; }

        [Display(Name = "Portería")]
        public Entrance? EntranceGate { get; set; }
    }
}
