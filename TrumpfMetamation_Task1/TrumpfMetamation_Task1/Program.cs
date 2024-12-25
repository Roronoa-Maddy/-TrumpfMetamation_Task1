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
            System.Diagnostics.Process.Start("explorer.exe", @"C:");

            System.Threading.Thread.Sleep(5000); // Wait for File Explorer to open


            SendKeys.SendWait("^+n");
            Thread.Sleep(500);
            // Type the new folder name and press Enter
            SendKeys.SendWait("Trumpf Metamation");
            SendKeys.SendWait("{ENTER}");
            SendKeys.SendWait("{ENTER}");
            Thread.Sleep(5000);

            //Creating New Text File
            SendKeys.SendWait("{F10}");
            SendKeys.SendWait("{ENTER}");
            Thread.Sleep(2000);
            for (int i = 0; i < 8; i++)
            {
                SendKeys.SendWait("{DOWN}");
            }
            SendKeys.SendWait("{ENTER}");
            Thread.Sleep(1000);
            SendKeys.SendWait("MetaMation");
            Thread.Sleep(1000);
            SendKeys.SendWait("{ENTER}");
            SendKeys.SendWait("{ENTER}");
            Thread.Sleep(3000);
        }
    }
}