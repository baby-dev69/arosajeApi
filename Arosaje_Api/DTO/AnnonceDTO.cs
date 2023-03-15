using Arosaje_Api.Entities;

namespace Arosaje_Api.DTO
{
    public class AnnonceDTO
    {
        public int id_annonce { get; set; }

        public string titre_annonce { get; set; } = null!;

        public string description_annonce { get; set; } = null!;

        public bool accepter { get; set; }

        public int id_gardien { get; set; }

        public virtual ICollection<Concerner> Concerners { get; } = new List<Concerner>();

        public virtual Gardien IdGardienNavigation { get; set; } = null!;
    }
}
