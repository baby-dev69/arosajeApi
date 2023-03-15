using System;
using System.Collections.Generic;

namespace Arosaje_Api.Entities;

public partial class Gardien
{
    public int IdGardien { get; set; }

    public string NomGardien { get; set; } = null!;

    public string PrenomGardien { get; set; } = null!;

    public int AgeGardien { get; set; }

    public string AdresseGardien { get; set; } = null!;

    public string EmailGardien { get; set; } = null!;

    public string TelephoneGardien { get; set; } = null!;

    public virtual ICollection<Annonce> Annonces { get; } = new List<Annonce>();

    public virtual ICollection<Plante> IdPlantes { get; } = new List<Plante>();
}
