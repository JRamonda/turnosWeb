using System;
using System.Collections.Generic;

namespace Data.Models;

public partial class Service
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<User>? Users { get; } = new List<User>();

    public virtual ICollection<ClientXTurnXUserXService>? ClientsXTurnsXUsersXServices { get; } = new List<ClientXTurnXUserXService>();
}
