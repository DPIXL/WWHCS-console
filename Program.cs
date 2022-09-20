using System;
using Microsoft.Win32;

namespace ChangeHeaderColor
{
    class Program
    {       
        static void Main(string[] args)
        {
            int looper = 1;

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Welcome to Windows Window Header Color Selector! (WWHCS!)");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nWrite your desired color theme, these are the current options:");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("dark, accent, oldschool, default");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("If you want to know more about these Themes, write 'desc'");

            while(looper == 1)
            {   
                Console.ForegroundColor = ConsoleColor.DarkGray;
                string chosenTheme = Console.ReadLine();
                
                if(chosenTheme == "dark")
                {
                    SetHeaderColors(0);
                    looper = 0;
                }
                else if(chosenTheme == "accent")
                {
                    SetHeaderColors(1);
                    looper = 0;
                }
                else if(chosenTheme == "oldschool")
                {
                    SetHeaderColors(2);
                    looper = 0;
                }
                else if(chosenTheme == "default")
                {
                    SetHeaderColors(3);
                    looper = 0;
                }
                else if(chosenTheme == "desc")
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine("'dark' - headers are black\n'accent' - the color of headers is set to your Windows accent color\n'oldschool' - dark blue color, looks bluescreen-ish\n'default' - these are just the default headers, mostly white");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Now, choose one of the Themes mentioned above:");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid Theme.");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\nWrite a VALID Theme, from the options above:");
                    
                }
            }
        }

        static void SetHeaderColors(int _selectedTheme)
        {
            RegistryKey DWM = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\DWM", true);
            RegistryKey windowOutline = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Accent", true);

            int selectedTheme = _selectedTheme;
            int[] color = new int[4];
            //1 = Active color; 2 = Inactive color; 3 = outline; 4 = use the custom stuff or not(be default)
            //color 2 should be the same as colo 1

            if(selectedTheme == 0)
            {
                color[0] = 0x00141414;
                color[1] = 0x000d0d0d;
                color[2] = 0x00141414;
                color[3] = 1;
            }
            if(selectedTheme == 1)
            {
                color[0] = 0;
                color[1] = 0;
                color[2] = 0;
                color[3] = 1;
            }
            if(selectedTheme == 2)
            {
                color[0] = 0x009f0000;
                color[1] = 0x00510000;
                color[2] = 0x009f0000;
                color[3] = 1;
            }
            if(selectedTheme == 3)
            {
                color[0] = 0;
                color[1] = 0;
                color[2] = 0;
                color[3] = 0;
            }

            DWM.SetValue("AccentColor", color[0], RegistryValueKind.DWord);
            DWM.SetValue("AccentColorInactive", color[1], RegistryValueKind.DWord);
            windowOutline.SetValue("AccentColorMenu", color[2], RegistryValueKind.DWord);
            DWM.SetValue("ColorPrevalence", color[3], RegistryValueKind.DWord);
            
        }
    }
}
