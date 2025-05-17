using System;
using System.Collections.Generic;

namespace BridgeMall.Models.Relational;

public partial class User
{
    public int UserId { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Role { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual ICollection<Password> Passwords { get; set; } = new List<Password>();

    public virtual UserToken? UserToken { get; set; }
}
