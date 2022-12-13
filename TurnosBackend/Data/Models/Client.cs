using System;
using System.Collections.Generic;

namespace Data.Models;

public partial class Client
{
    public int Id { get; set; }

    public string NumDoc { get; set; } = null!;

    public int IdTypeDoc { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string NumPhone { get; set; } = null!;

    public virtual ICollection<ClientXTurnXUserXService>? ClientsXTurnsXUsersXServices { get; } = new List<ClientXTurnXUserXService>();

    public virtual TypeDoc? TypeDoc { get; set; } = null!;
}
