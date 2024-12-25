**Project Overview
# File Handling Automation Task (C# Implementation)

This project automates a sequence of file handling tasks using C# and Visual Studio. The tasks include folder creation, file manipulation, content verification, and cleanup.

## Steps Automated

1. Open File Explorer.
2. Navigate to `C:\`.
3. Create a folder named `TrumpfMetamation` 
4. Create a file named `Metamation.txt` inside the folder.
5. Write the text `Welcome to Trumpf Metamation!` inside `Metamation.txt`.
6. Verify that the file contains the correct content.
7. Delete both the file and the folder.
8. Confirm that the file and folder have been deleted successfully.

### Tools and Frameworks

1. Visual Studio (2022).
2. .NET Framework or .NET Core/8.0.

### Libraries
- `System.Diagnostics`

### Setting up the Project

1. Open Visual Studio.
2. Create a new Windows Forms App project.
3. Name the project `FileHandlingAutomation`.
4. Add the following code to your `Program.cs` file.



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
            Thread.Sleep(4000);

            //Entering  text in the text file saving The File
            SendKeys.SendWait("Welcome To Trumpf Metamation!");
            Thread.Sleep(1000);
            SendKeys.SendWait("^s");

            Thread.Sleep(1000);
            SendKeys.SendWait("%{F4}");

            string filePath = @"C:\Trumpf Metamation\MetaMation.txt";
            string expectedContent = "Welcome To Trumpf Metamation!";

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


### Running the Project

1. Build and run the project in Visual Studio.
2. Observe the FileExplore widnows for the status of each step.
