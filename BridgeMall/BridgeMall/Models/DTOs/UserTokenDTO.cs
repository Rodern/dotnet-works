using Microsoft.EntityFrameworkCore;

namespace BridgeMall.Models.DTOs;

[PrimaryKey("UserTokenId")]
public class UserTokenDTO
{
	public int UserTokenId { get; set; }

	public int UserId { get; set; }

	public string Token { get; set; } = null!;

	public DateTime ExpiryDate { get; set; }

	public DateTime DateCreated { get; set; }

	public DateTime LastModified { get; set; }
}
