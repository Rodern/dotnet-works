namespace BridgeMall.Models.ClientModels
{
	public class ResetModel
	{
		public string UserId { get; set; } = string.Empty;
		public long OtpId { get; set; }
		public int Code { get; set; }
		public string Password { get; set; } = string.Empty;
		public string Guid { get; set; } = string.Empty;
	}
}
