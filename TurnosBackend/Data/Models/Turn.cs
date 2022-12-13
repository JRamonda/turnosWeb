using System;
using System.Collections.Generic;

namespace Data.Models;

public partial class Turn
{
    public int Id { get; set; }

    public TimeSpan StartTime { get; set; }

    public TimeSpan EndTime { get; set; }

    public DateTime Date { get; set; }

    public virtual ICollection<ClientXTurnXUserXService>? ClientsXTurnsXUsersXServices { get; } = new List<ClientXTurnXUserXService>();
}
