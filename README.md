# Генератор сертификатов участников олимпиад
Программа для автоматического формирования справок с результатами олимпиад. Сделана в виде Windows Forms приложения, работает с xlsx и docx файлами через OpenXML.

## Описание приложения
### Внешний вид
<img width="661" height="633" alt="image" src="https://github.com/user-attachments/assets/7d95b09b-d349-4853-bbf0-88445d1bb498" />

Внешний вид приложения довольно прост, но лаконичен и интуитивно понятен. В левой части находятся поля необходимые для заполнения, справа нужно выбрать папку где лежат "эксельки" с результатами олимпиад и папку куда сохранить готовую справку.
Внизу окна расположен прогресс бар, позволяющий примернр понять когда программа закончит работу.

### Логика работы
1) Пользователю необходимо заполнить все поля по участнику олимпиад
2) Выбрать ответственного сотрудника, который будет подписывать документ
3) Указать расположение файлов с итоговыми результатами олимпиад
4) Указать папку куда программма сохранит справку по участнику
5) В процессе работы пользователь будет видеть прогресс бар, который будет увеличиваться по мере обработки файлов.
6) Программа проходится по всем файлам и их содержимому, в поиске участника олимпиады и его результатов. Всего 27 файлов, в каждом от 3 до 240 тысяч строк, в зависимости от популярности предметов.
7) После формирования справки пользователь увидит сообщение, о том что справка сформирована и после подтверждения пользователем программа будет закрыта.
8) К сожалению под разные года программу адаптировать не получилось в связи с сильно различающимися файлами результатов олимпиад.

### Результат работы
<img width="724" height="404" alt="image" src="https://github.com/user-attachments/assets/f5b586d8-88fb-4336-a780-77564a6216e1" />

В результате работы программы формируется вордовский файл со справкой содержащей ФИО ученика в дательном падеже, его школу, класс обучения и участия и баллы со статусом по соответствующей олимпиаде.
В итоге программа значительно ускоряет и упрощает формирование справок коллегами, несмотря на то что она заточена только под один учебный год использоваться будет в течении нескольких лет.

### 

## Техническая часть
### Работа с xlsx
Тут в целом все довольно просто, через GetFiles получаем все файлы в папке, далее проходимся по ним foreach'ем и ищем нужные данные, попутно двигая прогрессбар:

`foreach (string file in files)
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
  }`

Все поля выбирались по номерам столбцов в документах заминка случилась только со столбцом статуса, потому что в разных документах он "гуляет" по столбцам и пришлось его искать по названию. Также нужно было название школы отформатировать, добавить определенные кавычки. Данный метод кроме собранных данных, возвращает еще название школы и класс, за который была пройдена олимпиада.


### Обработка данных
Получив данные в прошлом методе, занимаюсь их обработкой, тут надо правильно сформировать итоговый текст в зависимости от пола ребенка и учесть в одной олимпиаде принимал участие ребенок или в нескольких:

`var data = GetData.GetFiles(MainForm._selectedFolderOlimpiads, out OOName, out participationClass, student);
if (studentsSex == "он")
{
    participated = "принял";
    studying = "учащемуся";
}
else
{
    participated = "приняла"; 
    studying = "учащейся";
}
if (data.Count == 1)
{
    foreach (var line in data)
    {
        subject = GetSubject(line[0]);
        result = GetScoreText(line[1]);
        status = line[2].ToString();
    }
    certificateBodyText = $"Дана {GetCorrectFIO(student, studentsSex)}, " +
        $"{studying} {student.StudyClass} класса {OOName} г. Москвы, в том, что в 2024-2025 учебном году {studentsSex} {participated} " +
        $"участие в региональном этапе всероссийской олимпиады школьников по {subject} за {participationClass} " +
        $"класс с результатом {result}, что соответствует статусу «{status}».";
}
else
{
    certificateBodyText = $"Дана {GetCorrectFIO(student, studentsSex)}, " +
        $"{studying} {student.StudyClass} класса {OOName} г. Москвы, в том, что {studentsSex} {participated} участие в школьном этапе " +
        $"всероссийской олимпиады школьников 2024-2025 учебного года за {participationClass} класс:";
    foreach (var line in data)
    {
        subject = GetSubject(line[0]);
        result = GetScoreText(line[1]);
        status = line[2].ToString();
        certificateBodyText += $"\n- по {subject} с результатом {result}, что соответствует статусу «{status}»;";
    }
    certificateBodyText = certificateBodyText.Remove(certificateBodyText.Length - 1, 1) + ".";
}
return certificateBodyText;`

###### Также нужно конвертировать ФИО в дательный падеж, пример конвертации имени, а фамилия и отчество делаются по аналогии:

`private static string GetCorrectFirstName(string firstName, string studentsSex)
{
    string name = "";
    if (studentsSex == "он")
    {
        if (firstName == "Лев") name = "Льву";
        else
        {
            switch (firstName[firstName.Length - 1])
            {
                case 'й': name = firstName.Substring(0, firstName.Length - 1) + 'ю'; break;
                case 'а': name = firstName.Substring(0, firstName.Length - 1) + 'е'; ; break;
                default: name = firstName + 'у'; break;
            }
        }
    }
    else
    {
        if (firstName == "Любовь") name = "Любови";
        else
        {
            switch (firstName[firstName.Length - 1])
            {
                case 'я': name = firstName.Substring(0, firstName.Length - 1) + 'и'; break;
                case 'а': name = firstName.Substring(0, firstName.Length - 1) + 'е'; ; break;
            }
        }
    }
    return name;
}`

### Формирование docx
###### Дальше собираю вордовский документ, разделив задачу на несколько этапов и классов.
Сначала делаю основной класс, в котором формирую структуру будущего документа и подключаю класс WordprocessingDocument.

`using (WordprocessingDocument document = WordprocessingDocument.Create(
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

    ...
    HeaderPart headerPart = mainPart.AddNewPart<HeaderPart>();
    string headerId = mainPart.GetIdOfPart(headerPart);

    headerPart.Header = AddHeader.AddHeaderContent(document, _headerText, _imagePath);

    paragraphHelper.AddTable(document.MainDocumentPart.Document.Body, _headLeftText, _headRightText);
    paragraphHelper.AddEmptyLine(document.MainDocumentPart.Document.Body);
    paragraphHelper.AddCaptionParagraph(document.MainDocumentPart.Document.Body, _certificateCaptionText);
    paragraphHelper.AddEmptyLine(document.MainDocumentPart.Document.Body);
    paragraphHelper.AddMainParagraph(document.MainDocumentPart.Document.Body, TextStorage.GenerateBodyText(student));
    paragraphHelper.AddEmptyLine(document.MainDocumentPart.Document.Body);
    paragraphHelper.AddTable(document.MainDocumentPart.Document.Body, _employeePosition, _employeeFIO);
    document.Save();
}`

###### В отдельных классе и методе добавляю верхний колонтитул:

`public static Header AddHeaderContent(WordprocessingDocument document, string text, string imagePath) 
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
}`

###### И чтобы избежать конфликтов using'ов опять же в отдельных классе и методе добавляю изображение в верхний колонтитул. Это была самая трудная часть по созданию вордовского файла:

`public class AddIMGHeader
{
    public static readonly long widthPixels = 700;
    public static readonly long heightPixels = 70;

    public static Drawing AddLogo(WordprocessingDocument doc, string imagePath)
    {
        HeaderPart headerPart = doc.MainDocumentPart.HeaderParts.First();
        ImagePart imagePart = headerPart.AddImagePart(ImagePartType.Png);
        using (FileStream stream = new FileStream(imagePath, FileMode.Open))
        {
            imagePart.FeedData(stream);
        }
        string imageId = headerPart.GetIdOfPart(imagePart);
        long widthEmu = widthPixels * 9525;
        long heightEmu = heightPixels * 9525;
        return CreateDrawingElement(imageId, widthEmu, heightEmu);
    }
}`

###### С созданием "тела" особо проблем не возникло:

`public void AddCaptionParagraph(Body body, string text)
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
}`

###### Список ответственных лиц храню в обычном словаре:

`public static Dictionary<string, string> GetEmployees()
{
    var employees = new Dictionary<string, string>
    {
        {"Директор А. А.", "Директор ЦПМ"},
        {"Зам Б. Б.", "и.о. директора"},
        {"Зам В. В.", "и.о. директора"},
        {"Зам Г. Г.", "и.о. директора"}
    };
    return employees;
}`
