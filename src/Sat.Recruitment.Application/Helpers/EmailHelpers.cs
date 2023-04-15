namespace Sat.Recruitment.Application.Helpers
{
	public class EmailHelpers
	{
		public static string NormalizeEmail(string email)
		{
			var emailParts = email.Split(new [] { '@' }, StringSplitOptions.RemoveEmptyEntries);

			var invalidCharIndex = emailParts[0].IndexOf("+", StringComparison.Ordinal);

			emailParts[0] = invalidCharIndex < 0 ? 
				emailParts[0].Replace(".", "") : 
				emailParts[0].Replace(".", "").Remove(invalidCharIndex);

			return string.Join("@", emailParts[0], emailParts[1]);
		}
	}
}
