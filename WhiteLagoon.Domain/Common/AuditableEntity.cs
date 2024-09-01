using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhiteLagoon.Domain.Common
{
	public class AuditableEntity
	{
		public DateTime? CreateDate { get; set; }
		public string? CreatedBy { get; set; }
		public DateTime? ModifiedDate { get; set; }
		public string? ModifiedBy { get; set; }
	}
}
