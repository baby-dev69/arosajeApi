using System;
using System.Collections.Generic;

namespace Arosaje_Api.Entities;

public partial class Plante
{
    public int id_plante { get; set; }

    public string nom_plante { get; set; } = null!;

    public string espece_plante { get; set; } = null!;

    public string adresse_plante { get; set; } = null!;

    public virtual ICollection<Concerner> Concerners { get; } = new List<Concerner>();

    public virtual ICollection<Botaniste> IdBotanistes { get; } = new List<Botaniste>();

    public virtual ICollection<Gardien> IdGardiens { get; } = new List<Gardien>();
}
