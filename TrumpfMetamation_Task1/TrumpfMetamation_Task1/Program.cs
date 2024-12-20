using System.Diagnostics;

namespace TrumpfMetamation_Task1
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            //ApplicationConfiguration.Initialize();
            //Application.Run(new Form1());

            string folderPath = @"D:\TrumpfMetamation";

            if (!System.IO.Directory.Exists(folderPath))
            {
                // Open File Explorer to the specified drive
                System.Diagnostics.Process.Start("explorer.exe", @"D:\");
                System.Threading.Thread.Sleep(10000); // Wait for File Explorer to open
              

                
            }
            else
            {
                Console.WriteLine("Folder already exists.");
            }
            Thread.Sleep(TimeSpan.FromSeconds(10));
        }
    }
}