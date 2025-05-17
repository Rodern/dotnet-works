using System;
using System.Collections.Generic;

namespace BridgeMall.Models.Relational;

public partial class UserToken
{
    public int UserTokenId { get; set; }

    public int UserId { get; set; }

    public string Token { get; set; } = null!;

    public DateTime ExpiryDate { get; set; }

    public DateTime DateCreated { get; set; }

    public DateTime LastModified { get; set; }

    public virtual User User { get; set; } = null!;
}
