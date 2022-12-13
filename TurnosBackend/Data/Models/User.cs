using System;
using System.Collections.Generic;

namespace Data.Models;

public partial class User
{
    public int Id { get; set; }

    public int IdProfile { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public virtual ICollection<ClientXTurnXUserXService>? ClientsXTurnsXUsersXServices { get; } = new List<ClientXTurnXUserXService>();

    public virtual Profile? Profile { get; set; } = null!;

    public virtual ICollection<Service>? Services { get; } = new List<Service>();
}
