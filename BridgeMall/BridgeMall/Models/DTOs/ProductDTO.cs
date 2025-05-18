using System;
using System.Collections.Generic;

namespace BridgeMall.Models.DTOs;

public class ProductDTO
{
    public int ProductId { get; set; }

    public int? CategoryId { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public float Weight { get; set; }

    public int Price { get; set; }

    public int InStock { get; set; }

	public string Image { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public int Code { get; set; }
}
