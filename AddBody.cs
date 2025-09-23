using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Wordprocessing;

namespace CertificateGenerator
{
    public class AddBody
    {
        public void AddCaptionParagraph(Body body, string text)
        {
            Paragraph para = body.AppendChild(new Paragraph(new ParagraphProperties(new Justification { Val = JustificationValues.Center})));
            Run run = para.AppendChild(new Run(new RunProperties(new RunFonts(){HighAnsi = "Times New Roman"}, new Bold(), new FontSize { Val = "28" }), new Text(text)));
        }

        public void AddMainParagraph(Body body, string text)
        {
            string multiLineText = text;
            Paragraph para = body.AppendChild(new Paragraph(new TabStop { Val = TabStopValues.Left, Position = 3600, Leader = TabStopLeaderCharValues.Dot }, new ParagraphProperties(new Justification { Val = JustificationValues.Start })));
            Run run = para.AppendChild(new Run(new RunProperties(new RunFonts() { HighAnsi = "Times New Roman" }, new FontSize { Val = "28" })));
            foreach (var line in multiLineText.Split('\n'))
            {
                run.AppendChild(new TabChar());
                run.AppendChild(new Text(line));
                run.AppendChild(new Break());
            }
        }

        public void AddEmptyLine(Body body)
        {
            Paragraph para = body.AppendChild(new Paragraph());
            Run run = para.AppendChild(new Run());
            run.AppendChild(new Text(" "));
        }

        public void AddTable(Body body, string textLeft, string textRight)
        {
            Table table = new Table();

            TableProperties props = new TableProperties(
                new TableStyle() { Val = "TableGrid" },
                new TableWidth() { Width = "100%", Type = TableWidthUnitValues.Dxa }
                );
            table.AppendChild(props);

            TableRow row = new TableRow();
            row.Append(new TableRowProperties(
                new TableRowHeight()
                {
                    Val = 900,
                    HeightType = HeightRuleValues.Exact
                }
                ));

            TableCell leftCell = new TableCell(
                new TableCellProperties(
                    new TableCellWidth()
                    {
                        Width = "4550",
                        Type = TableWidthUnitValues.Dxa
                    }
                ),
                new Paragraph(
                    new ParagraphProperties(new Justification() { Val = JustificationValues.Left }),
                    new Run(new RunProperties(
                        new RunFonts() { ComplexScript = "Times New Roman" },
                        new FontSize() { Val = "24" }
                        ), 
                        new Text(textLeft) { Space = SpaceProcessingModeValues.Preserve })
                )
            );

            TableCell rightCell = new TableCell(
                new Paragraph(
                    new ParagraphProperties(new Justification() { Val = JustificationValues.Right }),
                    new Run(new RunProperties(
                        new RunFonts() { HighAnsi = "Times New Roman" },
                        new Bold(),
                        new FontSize() { Val = "28" }
                        ), 
                        new Text(textRight))
                )
            );

            row.Append(leftCell, rightCell);
            table.AppendChild(row);
            body.AppendChild(table);
        }
    }
}
