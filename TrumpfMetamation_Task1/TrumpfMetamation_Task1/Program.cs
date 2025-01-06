using FlaUI.Core.AutomationElements;
using FlaUI.Core.Definitions;
using FlaUI.Core.Input;
using FlaUI.Core.Tools;
using FlaUI.Core.WindowsAPI;
using FlaUI.UIA3;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
//using System.Windows.Automation;
using System.Windows.Documents;

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

            var fileExplorerApp = FlaUI.Core.Application.Launch("explorer.exe", @"C:");
            //System.Diagnostics.Process.Start("explorer.exe", @"C:");


            using (var automation = new UIA3Automation())
            {

                var rootElement = automation.GetDesktop();
                var condition = automation.ConditionFactory.ByControlType(FlaUI.Core.Definitions.ControlType.Window).And(automation.ConditionFactory.ByName("OSDisk (C:) - File Explorer"));
                var MainWindow = Retry.WhileNull(() => rootElement.FindFirst((FlaUI.Core.Definitions.TreeScope)TreeScope.Children, condition), timeout: TimeSpan.FromSeconds(10)).Result;
                Thread.Sleep(TimeSpan.FromSeconds(2));
                var newbutton = MainWindow.FindFirstDescendant(cf => cf.ByName("New")).AsButton();
                newbutton.Click();
                Thread.Sleep(TimeSpan.FromMilliseconds(25));
                var folderbutton = MainWindow.FindFirstDescendant(cf => cf.ByName("Folder")).AsButton();
                folderbutton.Click();

                Thread.Sleep(TimeSpan.FromMilliseconds(25));
                Keyboard.Release(VirtualKeyShort.BACK);
                Thread.Sleep(TimeSpan.FromMilliseconds(25));
                Keyboard.Type("Trumpf Metamation");
                Keyboard.Type(VirtualKeyShort.ENTER);
                Thread.Sleep(TimeSpan.FromMilliseconds(250));
                Keyboard.Type(VirtualKeyShort.ENTER);
                Thread.Sleep(TimeSpan.FromSeconds(2));
                Thread.Sleep(TimeSpan.FromMilliseconds(500));
                newbutton.Click();
                Thread.Sleep(TimeSpan.FromSeconds(5));


                for (int i = 0; i < 8; i++)
                {
                    Keyboard.Type(VirtualKeyShort.DOWN);
                }
                Thread.Sleep(TimeSpan.FromSeconds(2));
                Keyboard.Type(VirtualKeyShort.ENTER);
                Thread.Sleep(TimeSpan.FromMilliseconds(25));
                Keyboard.Release(VirtualKeyShort.BACK);
                Keyboard.Type("MetaMation");
                Keyboard.Type(VirtualKeyShort.ENTER);
                // Wait for File Explorer to open
                Thread.Sleep(TimeSpan.FromMilliseconds(500));
                
                Keyboard.Type(VirtualKeyShort.ENTER);
                Thread.Sleep(TimeSpan.FromSeconds(1));
                SendKeys.SendWait("Welcome To Trumpf Metamation!");
                Thread.Sleep(TimeSpan.FromSeconds(5));
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
                

                Assert.IsFalse(Directory.Exists(Folderpath), "The folder was not deleted.");



            }
        }
    }
}