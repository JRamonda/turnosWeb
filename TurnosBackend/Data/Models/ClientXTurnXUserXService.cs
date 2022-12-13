using System;
using System.Collections.Generic;

namespace Data.Models;

public partial class ClientXTurnXUserXService
{
    public int IdClient { get; set; }

    public int IdTurn { get; set; }

    public int IdUser { get; set; }

    public int IdService { get; set; }

    public virtual Client? Client { get; set; } = null!;

    public virtual Turn? Turn { get; set; } = null!;

    public virtual User? User { get; set; } = null!;

    public virtual Service? Service { get; set; } = null!;
}
