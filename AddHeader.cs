using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;

namespace CertificateGenerator
{
    public class AddHeader
    {
        public static Header AddHeaderContent(WordprocessingDocument document, string text, string imagePath) 
        {
            Header header = new Header();
            Paragraph imageParagraph = new Paragraph();
            Run imageRun = new Run();
            Drawing drawing = AddIMGHeader.AddLogo(document, imagePath);
            imageRun.AppendChild(drawing);
            imageParagraph.AppendChild(imageRun);
            header.AppendChild(imageParagraph);
            Paragraph textParagraph = new Paragraph();
            textParagraph.ParagraphProperties = new ParagraphProperties(
                new Justification() { Val = JustificationValues.Center });
            Run textRun = new Run();
            textRun.AppendChild(new Text(text));
            textRun.RunProperties = new RunProperties(
                new FontSize() { Val = "20" });
            textParagraph.AppendChild(textRun);
            header.AppendChild(textParagraph);
            return header;
        }
    }
}
