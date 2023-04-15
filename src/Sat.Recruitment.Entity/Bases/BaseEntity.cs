using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sat.Recruitment.Entity.Bases
{
	public class BaseEntity<TId> where TId : struct
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public virtual TId Id { get; set; }
	}
}
