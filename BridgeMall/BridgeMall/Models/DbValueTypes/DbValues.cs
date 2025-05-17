namespace BridgeMall.Models.DbValueTypes
{
    public enum AccountStatus
	{
		Banned,
		NotVerified,
		Suspended,
		Verified
	}
	public enum SentMailType
	{
		WelcomeEmail,
		ResetPassword,
		SubjectRegistered,
		SubjectCompleted,
		VerifyEmail,
		NewListing,
		TransactionApproved
	}
	public enum EmailType
	{
		Business,
		Personnal,
		School,
		Work
	}
	public enum Gender
	{
		Male,
		Female,
		NotSet,
		Other,
	}
	public enum InfoType
	{
		Banned,
		FoundOject,
		ResetPassword,
		Suspended,
		VerifiedEmail,
		VerifiedPhone,
		VerifiedWhatsApp,
		VerifyEmail,
		VerifyPhone,
		VerifyWhatsApp,
		Welcome
	}
	public enum LetterStatus
	{
		Cancelled,
		NotSent,
		Sent,
		Pending
	}
	public enum MessageVia
	{
		SMS,
		WhatsApp,
		Both
	}
	public enum NewsLetterType
	{
		Informational,
		Updates,
		Promotional,
		Social
	}
	public enum OtpType
	{
		Other,
		PasswordReset,
		VerifyEmail,
		VerifyPhone
	}
	public enum PhoneType
	{
		Fax,
		Home,
		Mobile,
		Office,
		Work
	}
	public enum RoleType
	{
		User,
		Admin,
		Dev
	}
	public class DbValues
	{
	}
}
