using System;
using System.Collections.Generic;

namespace Arosaje_Api.Entities;

public partial class Concerner
{
    public int IdPlante { get; set; }

    public int IdAnnonce { get; set; }

    public int IdProprio { get; set; }

    public virtual Annonce IdAnnonceNavigation { get; set; } = null!;

    public virtual Plante IdPlanteNavigation { get; set; } = null!;

    public virtual Proprietaire IdProprioNavigation { get; set; } = null!;
}
