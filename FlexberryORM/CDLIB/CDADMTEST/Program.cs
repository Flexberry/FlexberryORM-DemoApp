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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
