using System.ComponentModel.DataAnnotations;

namespace Parcial2_AriasRoldanNatalia.DAL.Entities
{
    public class Entrance : Entity
    {
        #region
        [Required(ErrorMessage = " El nombre de la entrada es requerido"),
            MaxLength(15),
            Display(Name = "Portería")]
        public string Name { get; set; }
        #endregion
    }
}
