using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseImplement.Models
{
	public class DepartmentTeacher
	{
		public int Id { get; set; }

		[Required]
		public int DepartmentId { get; set; }

		[Required]
		public int TeacherId { get; set; }

		public virtual Department Department { get; set; }

		public virtual Teacher Teacher { get; set; }
	}
}
