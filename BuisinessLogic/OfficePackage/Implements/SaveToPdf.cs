using BuisinessLogic.OfficePackage.HelperModels;
using BusinessLogic.OfficePackage.HelperEnums;
using BusinessLogic.OfficePackage.HelperModels;
using MigraDocCore.DocumentObjectModel;
using MigraDocCore.DocumentObjectModel.Tables;
using MigraDocCore.Rendering;

namespace BusinessLogic.OfficePackage.Implements
{
	public class SaveToPdf : AbstractSaveToPdf
	{
		private Document? _document;
		private Section? _section;
		private Table? _table;

		private static ParagraphAlignment GetParagraphAlignment(PdfParagraphAlignmentType type)
		{
			return type switch
			{
				PdfParagraphAlignmentType.Center => ParagraphAlignment.Center,
				PdfParagraphAlignmentType.Left => ParagraphAlignment.Left,
				PdfParagraphAlignmentType.Right => ParagraphAlignment.Right,
				_ => ParagraphAlignment.Justify,
			};
		}

		private static void DefineStyles(Document document)
		{
			var style = document.Styles["Normal"];
			style.Font.Name = "Times New Roman";
			style.Font.Size = 12;

			var title = document.Styles.AddStyle("NormalTitle", "Normal");
			title.Font.Bold = true;
			title.Font.Size = 14;
		}

		public void CreatePdf(PdfInfo info)
		{
			_document = new Document();
			DefineStyles(_document);
			_section = _document.AddSection();
		}

		public void CreateParagraph(PdfParagraph pdfParagraph)
		{
			if (_section == null)
				return;

			var paragraph = _section.AddParagraph(pdfParagraph.Text);
			paragraph.Format.SpaceAfter = "0.5cm";
			paragraph.Format.Alignment = GetParagraphAlignment(pdfParagraph.ParagraphAlignment);
			paragraph.Style = pdfParagraph.Style;
		}

		public void CreateTable(List<string> columns)
		{
			if (_section == null)
				return;

			_table = _section.AddTable();
			foreach (var col in columns)
				_table.AddColumn(col);
		}

		public void CreateRow(PdfRowParameters rowParameters)
		{
			if (_table == null)
				return;

			var row = _table.AddRow();
			for (int i = 0; i < rowParameters.Texts.Count; i++)
			{
				var cell = row.Cells[i];
				cell.AddParagraph(rowParameters.Texts[i]);
				if (!string.IsNullOrEmpty(rowParameters.Style))
					cell.Style = rowParameters.Style;

				cell.Format.Alignment = GetParagraphAlignment(rowParameters.ParagraphAlignment);
				cell.VerticalAlignment = VerticalAlignment.Center;

				Unit borderWidth = 0.5;
				cell.Borders.Left.Width = borderWidth;
				cell.Borders.Right.Width = borderWidth;
				cell.Borders.Top.Width = borderWidth;
				cell.Borders.Bottom.Width = borderWidth;
			}
		}

		public void SavePdf(PdfInfo info)
		{
			if (_document == null)
				return;

			var renderer = new PdfDocumentRenderer(true)
			{
				Document = _document
			};
			renderer.RenderDocument();
			renderer.PdfDocument.Save(info.FileName);
		}
	}
}
