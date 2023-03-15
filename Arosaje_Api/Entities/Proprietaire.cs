using System;
using System.Collections.Generic;

namespace Arosaje_Api.Entities;

/// <summary>
/// Hello
/// </summary>
public partial class Proprietaire
{
    public int IdProprio { get; set; }

    public string NomProprio { get; set; } = null!;

    public string PrenomProprio { get; set; } = null!;

    public string AdresseProprio { get; set; } = null!;

    public string EmailProprio { get; set; } = null!;

    public string TelephoneProprio { get; set; } = null!;

    public bool Absent { get; set; }

    public virtual ICollection<Concerner> Concerners { get; } = new List<Concerner>();
}
