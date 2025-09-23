namespace CertificateGenerator
{
    public class Student
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }
        public string LoginOO { get; set; }
        public string StudyClass { get; set; }
        public string StudentID { get; set; }

        public Student(string firstName, string secondName, string lastName, string login, string studyClass, string studentID)
        {
            FirstName = firstName;
            SecondName = secondName;
            LastName = lastName;
            LoginOO = login;
            StudyClass = studyClass;
            StudentID = studentID;
        }
    }
}
