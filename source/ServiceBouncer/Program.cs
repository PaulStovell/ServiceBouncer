using System;
using System.Windows.Forms;

namespace ServiceBouncer
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.ThreadException += (sender, args) => MessageBox.Show(args.Exception.Message, "Unhandled error", MessageBoxButtons.OK);
            Application.Run(new MainForm());
        }
    }
}
