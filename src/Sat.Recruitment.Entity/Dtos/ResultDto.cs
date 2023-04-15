namespace Sat.Recruitment.Entity.Dtos
{
	public class ResultDto<TResult>
	where TResult : new()
	{
		public bool IsSuccess { get; set; }
		public string[] Errors { get; set; } = Array.Empty<string>();
		public TResult Results { get; set; } = new TResult();
	}
}
