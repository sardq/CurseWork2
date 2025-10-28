using BusinessLogic.OfficePackage.HelperEnums;
using BusinessLogic.OfficePackage.HelperModels;
using PdfiumViewer;
using BusinessLogic.OfficePackage.Implements;
using PdfSharpCore.Pdf;
using PdfDocument = PdfiumViewer.PdfDocument;

namespace BusinessLogic.OfficePackage
{
	public abstract class AbstractSaveToPdf
	{
		private readonly SaveToPdf _saveToPdf = new();

		
        public void PrintTempPdf(Action<string> pdfCreator, string? printerName = null)
		{
			string tempFile = Path.Combine(Path.GetTempPath(), $"temp_report_{Guid.NewGuid()}.pdf");

			try
			{
				pdfCreator(tempFile);
				using var pdfDocument = PdfDocument.Load(tempFile);
				using var printDoc = pdfDocument.CreatePrintDocument();

				if (!string.IsNullOrEmpty(printerName))
				{
					printDoc.PrinterSettings.PrinterName = printerName;
				}

				printDoc.Print();
			}
			finally
			{
				if (File.Exists(tempFile))
					File.Delete(tempFile);
			}
		}
	

	public void CreateTeacherReport(ReportTeacherPdfInfo info)
		{
			_saveToPdf.CreatePdf(info);

			_saveToPdf.CreateParagraph(new PdfParagraph
			{
				Text = info.Title,
				Style = "NormalTitle",
				ParagraphAlignment = PdfParagraphAlignmentType.Center
			});

			_saveToPdf.CreateParagraph(new PdfParagraph
			{
				Text = $"Научный состав на {DateTime.Now:d}",
				Style = "Normal",
				ParagraphAlignment = PdfParagraphAlignmentType.Center
			});

			_saveToPdf.CreateTable(new List<string> { "3cm", "6cm", "4cm", "3cm" });
			_saveToPdf.CreateRow(new PdfRowParameters
			{
				Texts = new List<string> { "ID", "ФИО", "Должность", "Ставка" },
				Style = "NormalTitle",
				ParagraphAlignment = PdfParagraphAlignmentType.Center
			});

			foreach (var t in info.Teachers)
			{
				_saveToPdf.CreateRow(new PdfRowParameters
				{
					Texts = new List<string> {
				t.Id.ToString(),
				t.FullName,
				t.Position.ToString(),
				t.Rate.ToString("F2")
			},
					Style = "Normal",
					ParagraphAlignment = PdfParagraphAlignmentType.Left
				});
			}

			_saveToPdf.SavePdf(info);
		}
		public void CreateOrderReport(ReportOrderPdfInfo info)
		{
			_saveToPdf.CreatePdf(info);

			_saveToPdf.CreateParagraph(new PdfParagraph
			{
				Text = info.Title,
				Style = "NormalTitle",
				ParagraphAlignment = PdfParagraphAlignmentType.Center
			});

			_saveToPdf.CreateParagraph(new PdfParagraph
			{
				Text = $"Отчёт на {DateTime.Now:d}",
				Style = "Normal",
				ParagraphAlignment = PdfParagraphAlignmentType.Center
			});

			_saveToPdf.CreateTable(new List<string> { "2cm", "3cm", "3cm", "3cm", "6cm" });
			_saveToPdf.CreateRow(new PdfRowParameters
			{
				Texts = new List<string> { "ID", "Номер", "Дата", "Тип", "Описание" },
				Style = "NormalTitle",
				ParagraphAlignment = PdfParagraphAlignmentType.Center
			});

			foreach (var o in info.Orders)
			{
				_saveToPdf.CreateRow(new PdfRowParameters
				{
					Texts = new List<string> {
				o.Id.ToString(),
				o.OrderNumber,
				o.Date.ToShortDateString(),
				o.Type.ToString(),
				o.Description
			},
					Style = "Normal",
					ParagraphAlignment = PdfParagraphAlignmentType.Left
				});
			}

			_saveToPdf.SavePdf(info);
		}

		public void CreateGrantReport(ReportGrantPdfInfo info)
		{
			_saveToPdf.CreatePdf(info);
			_saveToPdf.CreateParagraph(new PdfParagraph
			{
				Text = info.Title,
				Style = "NormalTitle",
				ParagraphAlignment = PdfParagraphAlignmentType.Center
			});

			_saveToPdf.CreateTable(new List<string> { "2cm", "5cm", "2cm", "3cm", "3cm", "3cm" });
			_saveToPdf.CreateRow(new PdfRowParameters
			{
				Texts = new List<string> { "ID", "Название", "Год", "Тип", "Статус", "Сумма" },
				Style = "NormalTitle",
				ParagraphAlignment = PdfParagraphAlignmentType.Center
			});

			foreach (var g in info.Grants)
			{
				_saveToPdf.CreateRow(new PdfRowParameters
				{
					Texts = new List<string>
					{
						g.Id.ToString(),
						g.Name,
						g.Year.ToString(),
						g.Type.ToString(),
						g.Status.ToString(),
						g.Amount.ToString("F2")
					},
					Style = "Normal",
					ParagraphAlignment = PdfParagraphAlignmentType.Left
				});
			}

			_saveToPdf.SavePdf(info);
		}

		public void CreateScientificWorkReport(ReportScientificWorkPdfInfo info)
		{
			_saveToPdf.CreatePdf(info);
			_saveToPdf.CreateParagraph(new PdfParagraph
			{
				Text = info.Title,
				Style = "NormalTitle",
				ParagraphAlignment = PdfParagraphAlignmentType.Center
			});

			_saveToPdf.CreateTable(new List<string> { "2cm", "7cm", "3cm", "3cm", "3cm" });
			_saveToPdf.CreateRow(new PdfRowParameters
			{
				Texts = new List<string> { "ID", "Название", "Тип", "Статус", "Финансирование" },
				Style = "NormalTitle",
				ParagraphAlignment = PdfParagraphAlignmentType.Center
			});

			foreach (var w in info.ScientificWorks)
			{
				_saveToPdf.CreateRow(new PdfRowParameters
				{
					Texts = new List<string>
					{
						w.Id.ToString(),
						w.Name,
						w.Type.ToString(),
						w.Status.ToString(),
						w.FundingAmount?.ToString("F2") ?? "-"
					},
					Style = "Normal",
					ParagraphAlignment = PdfParagraphAlignmentType.Left
				});
			}

			_saveToPdf.SavePdf(info);
		}
	}
}
