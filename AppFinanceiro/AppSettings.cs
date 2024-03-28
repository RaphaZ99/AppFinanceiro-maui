namespace AppFinanceiro
{
    public static class AppSettings
    {

        private static string DatabaseName = "finance.db";
        private static string DatabaseDirectory = FileSystem.AppDataDirectory;
        public static string DatabasePath = Path.Combine(DatabaseDirectory, DatabaseName);
    }
}
