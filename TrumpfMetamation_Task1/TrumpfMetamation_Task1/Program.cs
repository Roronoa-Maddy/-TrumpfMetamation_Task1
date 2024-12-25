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

            //Entering  text in the text file saving The File
            SendKeys.SendWait("Welcome To Trumpf Metamation");
            Thread.Sleep(1000);
            SendKeys.SendWait("^s");

            Thread.Sleep(1000);
            SendKeys.SendWait("%{F4}");

            string filePath = @"C:\Trumpf Metamation\MetaMation.txt";
            string expectedContent = "Welcome To Trumpf Metamation";

            string actualContent = File.ReadAllText(filePath);
            if (actualContent == expectedContent)
            {
                Console.WriteLine("Validation successful: The text content is correct.");
            }
            else

            {
                Console.WriteLine("Validation failed: The text content is incorrect.");
            }

            //Deleting the Respective File
            SendKeys.SendWait("+{F10}");
            Thread.Sleep(1000);
            SendKeys.SendWait("D");
            Thread.Sleep(500);
            SendKeys.SendWait("{ENTER}");

            if (!File.Exists(filePath))
            {
                Console.WriteLine("File got deleted");
            }

            SendKeys.SendWait("{BACKSPACE}");
            Thread.Sleep(1000);
            SendKeys.SendWait("Trumpf Metamation");
            SendKeys.SendWait("+{F10}");
            Thread.Sleep(1000);
            SendKeys.SendWait("D");
            Thread.Sleep(500);
            SendKeys.SendWait("{ENTER}");
            String Folderpath = "C:\\Trumpf Metamation";
            if (!Directory.Exists(Folderpath))
            {
                Console.WriteLine("Folder Got Deleted");
            }


        }
    }
}