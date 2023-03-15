using System;
using System.Collections.Generic;

namespace Arosaje_Api.Entities;

public partial class Botaniste
{
    public int IdBotaniste { get; set; }

    public string NomBotaniste { get; set; } = null!;

    public string PrenomBotaniste { get; set; } = null!;

    public int AgeBotaniste { get; set; }

    public string AdresseBotaniste { get; set; } = null!;

    public string EmailBotaniste { get; set; } = null!;

    public string TelephoneBotaniste { get; set; } = null!;

    public virtual ICollection<Plante> IdPlantes { get; } = new List<Plante>();
}
