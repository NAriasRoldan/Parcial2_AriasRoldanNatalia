using System.ComponentModel.DataAnnotations;

namespace Parcial2_AriasRoldanNatalia.DAL
{
    public class Entity
    {
        #region
        [Key]
        public virtual Guid id { get; set; }
        public virtual string CreatedDate { get; set; }
        public virtual string ModifiedDate { get; set; }
        #endregion
    }
}
