using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using DocumentFormat.OpenXml;

namespace CertificateGenerator
{
    public class DocumentBuilder
    {
        public static void CreateDocument(string filePath)
        {
            using var wordDoc = WordprocessingDocument.Create(filePath, WordprocessingDocumentType.Document);

            MainDocumentPart mainPart = wordDoc.AddMainDocumentPart();
            mainPart.Document = new Document();

            Body body = new Body();
            mainPart.Document.Append(body);

            SectionProperties sectionProps = new SectionProperties();
            body.Append(sectionProps);

            HeaderReference headerRef = new HeaderReference { Type = HeaderFooterValues.Default };
            sectionProps.Append(headerRef);

            HeaderPart headerPart = mainPart.AddNewPart<HeaderPart>();
            headerRef.Id = mainPart.GetIdOfPart(headerPart);
        }
    }
}
