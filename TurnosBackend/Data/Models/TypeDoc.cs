using System;
using System.Collections.Generic;

namespace Data.Models;

public partial class TypeDoc
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Client>? Clients { get; } = new List<Client>();
}
