using Parcial2_AriasRoldanNatalia.DAL.Entities;

namespace Parcial2_AriasRoldanNatalia.Models
{
    public class EditViewModel
    {
        public List<Entrance> Entrances { get; set;}
        public Guid IdTicket{ get; set;}
        public DateTime? createDateTickey { get; set;}

        public string selectedEntrance { get; set; }
    }
}
