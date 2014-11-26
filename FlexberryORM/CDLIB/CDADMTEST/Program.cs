namespace CDADMTEST
{
    using System;
    using System.IO;
    using System.Windows.Forms;

    /// <summary>
    /// Flexberry ORM Demo application.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            // Set DataDirectory domain property for relative connection string.
            string executable = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string path = Path.GetDirectoryName(executable);
            if (path != null)
            {
                path = Path.GetFullPath(Path.Combine(path, @"..\..\..\..\..\DataBase"));
                AppDomain.CurrentDomain.SetData("DataDirectory", path);
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
