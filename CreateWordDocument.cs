using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;

namespace CertificateGenerator
{
    public class CreateWordDocument
    {
        private static readonly string _imagePath = "imagePath";
        private static readonly string _docFilePath = MainForm._selectedFolderCertificate;
        private static readonly string _certificateCaptionText = "СПРАВКА";        
        private static readonly string _headerText = "headerText";
        private static readonly string _headLeftText = "«____»  _______   202___ года №_______\n\nНа №_______________ от _____________";
        private static readonly string _headRightText = "По месту требования";
        private static readonly string _employeePosition = MainForm.employeePosition;
        private static readonly string _employeeFIO = MainForm.employeeFIO;

        public static void CreateDocx(Student student)
        {
            string certificateName = _docFilePath + $"\\Справка {student.LastName}_{student.FirstName[0]}_{student.SecondName[0]}.docx";
            using (WordprocessingDocument document = WordprocessingDocument.Create(
                certificateName,
                WordprocessingDocumentType.Document))
            {
                var paragraphHelper = new AddBody();
                MainDocumentPart mainPart = document.AddMainDocumentPart();

                mainPart.Document = new Document();
                Body body = new Body();
                mainPart.Document.Append(body);

                SectionProperties sectionProps = new SectionProperties();
                body.Append(sectionProps);

                PageMargin pageMargin = new PageMargin()
                {
                    Top = 500,
                    Left = 850,
                    Right = 850,
                    Bottom = 500,
                    Header = 500
                };

                sectionProps.Append(pageMargin);

                HeaderPart headerPart = mainPart.AddNewPart<HeaderPart>();
                string headerId = mainPart.GetIdOfPart(headerPart);

                headerPart.Header = AddHeader.AddHeaderContent(document, _headerText, _imagePath);

                HeaderReference headerReference = new HeaderReference()
                {
                    Id = headerId,
                    Type = HeaderFooterValues.Default
                };
                sectionProps.Append(headerReference);

                paragraphHelper.AddTable(document.MainDocumentPart.Document.Body, _headLeftText, _headRightText);
                paragraphHelper.AddEmptyLine(document.MainDocumentPart.Document.Body);
                paragraphHelper.AddCaptionParagraph(document.MainDocumentPart.Document.Body, _certificateCaptionText);
                paragraphHelper.AddEmptyLine(document.MainDocumentPart.Document.Body);
                paragraphHelper.AddMainParagraph(document.MainDocumentPart.Document.Body, TextStorage.GenerateBodyText(student));
                paragraphHelper.AddEmptyLine(document.MainDocumentPart.Document.Body);
                paragraphHelper.AddTable(document.MainDocumentPart.Document.Body, _employeePosition, _employeeFIO);
                document.Save();
            }
        }
    }
}