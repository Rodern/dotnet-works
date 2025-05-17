using System;
using System.Collections.Generic;

namespace BridgeMall.Models.DTOs;

public class CategoryDTO
{
    public int CategoryId { get; set; }

    public string Name { get; set; } = null!;

    public string Code { get; set; } = null!;

    public string Icon { get; set; } = null!;
}
