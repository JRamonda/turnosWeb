using System;
using System.Collections.Generic;

namespace Data.Models;

public partial class Profile
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<User>? Users { get; } = new List<User>();
}
