using Newtonsoft.Json;

namespace BridgeMall.Models.DbValueTypes
{
	public class PastPassword
	{
		public string Hashed {  get; set; } = string.Empty;
		public byte[] Salt { get; set; } = null!;
		public DateTime DateRemoved { get; set; }

		public override string ToString()
		{
			return JsonConvert.SerializeObject(this);
		}
	}
}
