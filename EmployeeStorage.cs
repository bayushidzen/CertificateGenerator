namespace CertificateGenerator
{
    public static class EmployeeStorage
    {        
        public static Dictionary<string, string> GetEmployees()
        {
            var employees = new Dictionary<string, string>
            {
                {"Директор А. А.", "Директор ЦПМ"},
                {"Зам Б. Б.", "и.о. директора"},
                {"Зам В. В.", "и.о. директора"},
                {"Зам Г. Г.", "и.о. директора"}
            };
            return employees;
        }
    }
}
