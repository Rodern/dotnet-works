using System;
using System.Collections.Generic;

namespace BridgeMall.Models.Relational;

public partial class Category
{
    public int CategoryId { get; set; }

    public string Name { get; set; } = null!;

    public string Code { get; set; } = null!;

    public string Icon { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
