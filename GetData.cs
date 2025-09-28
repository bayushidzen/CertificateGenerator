using OfficeOpenXml;

namespace CertificateGenerator
{
    internal class GetData
    {
        public static List<List<string>> GetFiles(string folderPath, out string OONameOut, out string participationClassOut, Student student)
        {
            OONameOut = String.Empty;
            participationClassOut = String.Empty;
            var data = new List<List<string>>();
            string[] files = Directory.GetFiles(folderPath, "*.xlsx");
            int totalFiles = files.Length;
            MainForm._staticProgressBar.Maximum = totalFiles;
            MainForm._staticProgressBar.Value = 0;
            string _statusCaption = "status";
            foreach (string file in files)
            {
                using (var package = new ExcelPackage(new FileInfo(file), false))
                {
                    var worksheet = package.Workbook.Worksheets[0];
                    int rowCount = worksheet.Dimension.Rows;
                    int colCount = worksheet.Dimension.Columns;
                    int statusRowNumber = GetStatusRowNumber(worksheet, colCount, _statusCaption);

                    for (int row = 2; row <= rowCount; row++)
                    {
                        string studentID = worksheet.Cells[row, 3].Text;
                        string firstName = worksheet.Cells[row, 6].Text;
                        string secondName = worksheet.Cells[row, 7].Text;
                        string lastName = worksheet.Cells[row, 5].Text;
                        string OOName = GetCorrectOOName(worksheet.Cells[row, 13].Text);
                        string loginSG = worksheet.Cells[row, 14].Text;
                        string participationClass = worksheet.Cells[row, 33].Text;
                        string studyClass = worksheet.Cells[row, 22].Text;
                        string result = worksheet.Cells[row, 26].Text;
                        string status = worksheet.Cells[row, statusRowNumber].Text;
                        string subject_input = worksheet.Cells[row, 2].Text;

                        if (studentID == student.StudentID && firstName == student.FirstName && secondName == student.SecondName && lastName == student.LastName && loginSG == student.LoginOO && studyClass == student.StudyClass)
                        {
                            OONameOut = OOName;
                            participationClassOut = participationClass;
                            data.Add(new List<string> {subject_input, result, status});
                        }
                    }
                }
                MainForm._staticProgressBar.Value++;
            }
            return data;
        }

        private static string GetCorrectOOName(string text)
        {
            string newString = "";
            if (text.Contains('"')) text = RemoveQuotation(text);
            var newData = text.Split();
            newString = $"{newData[0]} «";
            for (int i = 1; i < newData.Length; i++)
            {
                newString += $"{newData[i]} ";
            }
            return newString.Remove(newString.Length -1, 1) + "»";
        }

        private static string RemoveQuotation(string text)
        {
            string newString = "";
            foreach (char c in text)
            {
                if (c != '"') newString += c;
            }
            return newString;
        }

        private static int GetStatusRowNumber(ExcelWorksheet worksheet, int colCount, string statusCaption)
        {
            int number = 0;
            for (int i = 1; i <= colCount; i++)
            {
                if (worksheet.Cells[1, i].Text == statusCaption) return i;
            }
            return number;
        }
    }
}
