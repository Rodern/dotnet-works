using Microsoft.EntityFrameworkCore;

namespace BridgeMall.Models.DTOs;

[PrimaryKey("PasswordId")]
public class PasswordDTO
{
	public int PasswordId { get; set; }

	public int UserId { get; set; }

	public string Hashed { get; set; } = null!;

	public byte[] Salt { get; set; } = null!;

	public DateTime LastChanged { get; set; }

	/// <summary>
	/// This field, takes a an object like 
	/// 
	/// [{
	///  &quot;hashed&quot; &quot;string&quot;,
	///  &quot;salt&quot; : byte[]
	/// }
	/// ]
	/// </summary>
	public string PastPasswords { get; set; } = null!;
}
