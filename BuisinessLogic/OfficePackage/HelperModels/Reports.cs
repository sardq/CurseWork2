using BuisinessLogic.OfficePackage.HelperModels;
using Contracts.ViewModels;

namespace BusinessLogic.OfficePackage.HelperModels
{
	public class ReportTeacherPdfInfo : PdfInfo
	{
		public List<TeacherViewModel> Teachers { get; set; } = new();
	}

	public class ReportGrantPdfInfo : PdfInfo
	{
		public List<GrantViewModel> Grants { get; set; } = new();
	}

	public class ReportScientificWorkPdfInfo : PdfInfo
	{
		public List<ScientificWorkViewModel> ScientificWorks { get; set; } = new();
	}
	public class ReportOrderPdfInfo : PdfInfo
	{
		public List<OrderViewModel> Orders { get; set; } = new();
	}
}
