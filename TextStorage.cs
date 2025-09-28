namespace CertificateGenerator
{
    internal class TextStorage
    {   
        public static string GenerateBodyText(Student student)
        {
            string certificateBodyText = String.Empty;
            string OOName = String.Empty;
            string subject = String.Empty;
            string result = String.Empty;
            string status = String.Empty;
            string participated = String.Empty;
            string studying = String.Empty;
            string studentsSex = MainForm.studentsSex;
            string participationClass = String.Empty;
            var data = GetData.GetFiles(MainForm._selectedFolderOlimpiads, out OOName, out participationClass, student);
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
            return certificateBodyText;
        }

        private static string GetCorrectFIO(Student student, string studentsSex)
        {
            return $"{GetCorrectLastName(student.LastName, studentsSex)} {GetCorrectFirstName(student.FirstName, studentsSex)} {GetCorrectSecondName(student.SecondName, studentsSex)}";
        }

        private static string GetCorrectLastName(string lastName, string studentsSex)
        {
            string name = "";
            if (studentsSex == "он") name = lastName + 'у';
            else
            {
                switch (lastName[lastName.Length - 1])
                {
                    case 'а': name = lastName.Substring(0, lastName.Length - 1) + "ой"; ; break;
                    default: name = lastName; break;
                }
            }

            return name;
        }

        private static string GetCorrectSecondName(string secondName, string studentsSex)
        {
            string name = "";
            if (studentsSex == "он") name = secondName + 'у';
            else name = secondName.Substring(0, secondName.Length - 1) + 'е';

            return name;
        }

        private static string GetCorrectFirstName(string firstName, string studentsSex)
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
        }

        private static string GetSubject(string v)
        {
            string subject = "Предмет не найден";

            if (v.Contains("Астрономия")) return "Астрономии";
            else if (v.Contains("Английский")) return "Английскому языку";
            else if (v.Contains("Биология")) return "Биологии";
            else if (v.Contains("География")) return "Географии";
            else if (v.Contains("Информатика")) return "Информатике";
            else if (v.Contains("МХК")) return "Искусству (МХК)";
            else if (v.Contains("Испанский")) return "Испанскому языку";
            else if (v.Contains("История")) return "Истории";
            else if (v.Contains("Итальянский")) return "Итальянскому языку";
            else if (v.Contains("Китайский")) return "Китайскому языку";
            else if (v.Contains("Литература")) return "Литературе";
            else if (v.Contains("Математика")) return "Математике";
            else if (v.Contains("Немецкий")) return "Немецкому языку";
            else if (v.Contains("ОБЗР")) return "Основам безопасности и защиты Родины";
            else if (v.Contains("Обществознание")) return "Обществознанию";
            else if (v.Contains("Право")) return "Праву";
            else if (v.Contains("Русский")) return "Русскому языку";
            else if (v.Contains("ТрудИБ")) return "Информационной безопасности";
            else if (v.Contains("ТрудКД")) return "Культуре дома, дизайну и технологии";
            else if (v.Contains("ТрудРБ")) return "Робототехнике";
            else if (v.Contains("ТрудТТ")) return "Технике, технологии и техническому творчеству";
            else if (v.Contains("Физика")) return "Физике";
            else if (v.Contains("Физкультура")) return "Физкультуре";
            else if (v.Contains("Французский")) return "Французскому языку";
            else if (v.Contains("Химия")) return "Химии";
            else if (v.Contains("Экология")) return "Экологии";
            else if (v.Contains("Экономика")) return "Экономике";

            return subject;
        }

        private static string GetScoreText(string score)
        {
            string result = "";
            switch (score[score.Length -1])
            {
                case '1': result = $"{score} балл"; break;
                case '2':
                case '3':
                case '4':
                    result = $"{score} балла"; break;
                default: result = $"{score} баллов"; break;
            }
            return result;
        }
    }
}
