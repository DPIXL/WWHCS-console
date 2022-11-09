using System;
using Microsoft.Win32;

namespace ChangeHeaderColor
{
    class Program
    {
        public static int mainColor;
        public static int otherColor;

        static void Main(string[] args)
        {
            int looper = 1;

            Console.Title = "WWHCS - Header Modifier";
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Welcome to Windows Window Header Color Selector 3.2! (WWHCS3!)");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nWrite your desired color theme, these are the current options:");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("dark, oldschool, xbox, blood, sky, ebs, default");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("If you want to know more about these Themes, write 'desc'");
            Console.WriteLine("If you're done, type 'quit' or 'exit'");

            while (looper == 1)
            {   
                Console.ForegroundColor = ConsoleColor.DarkGray;
                string chosenTheme = Console.ReadLine();
                
                if(chosenTheme == "dark")
                {
                    SetHeaderColors(0);
                    looper = 1;
                }
                else if(chosenTheme == "xbox")
                {
                    SetHeaderColors(1);
                    looper = 1;
                }
                else if(chosenTheme == "oldschool")
                {
                    SetHeaderColors(2);
                    looper = 1;
                }
                else if(chosenTheme == "default")
                {
                    SetHeaderColors(3);
                    looper = 1;
                }
                else if(chosenTheme == "blood") {
                    SetHeaderColors(4);
                    looper = 1;
                }
                else if(chosenTheme == "sky") {
                    SetHeaderColors(5);
                    looper = 1;
                }
                else if(chosenTheme == "ebs") {
                    SetHeaderColors(6);
                    looper = 1;
                }
                else if(chosenTheme == "custom") {
                    Console.WriteLine("Please write Hex code already converted to Decimal");
                    Console.Write("Input Main color:");
                    mainColor = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Input Unfocused color:");
                    otherColor = Convert.ToInt32(Console.ReadLine());

                    SetHeaderColors(66);
                }
                else if(chosenTheme == "desc" || chosenTheme == "help")
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine("'dark' - headers are black\n'xbox' - headers are Xbox style green\n'oldschool' - dark blue color, looks bluescreen-ish\n'blood' - Bloody red\n'sky' - Sky blue, pretty\n'ebs' - My favourite, red and blue\n'default' - these are just the default headers, mostly white");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Now, choose one of the Themes mentioned above:");
                }
                else if(chosenTheme == "quit" || chosenTheme == "exit") {
                    looper = 0;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid command.");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\nWrite a VALID command, from the options above:");
                    
                }
            }
        }

        static void SetHeaderColors(int _selectedTheme)
        {
            RegistryKey DWM = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\DWM", true);
            RegistryKey windowOutline = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Accent", true);

            int selectedTheme = _selectedTheme;
            int[] color = new int[4];

            if(selectedTheme == 0) //dark
            {
                color[0] = 0x00141414; //Active color
                color[1] = 0x000d0d0d; //Inactive color
                color[2] = 0x00141414; //Outline color (must be same as Active color otherwise broken)
                color[3] = 1; //Be custom or not (0 == be default)
            }
            if(selectedTheme == 1) //Xbox green
            {
                color[0] = 0x00008700;
                color[1] = 0x00004100;
                color[2] = 0x00008700;
                color[3] = 1;
            }
            if(selectedTheme == 2) //oldschool ugly fcking blue
            {
                color[0] = 0x009f0000;
                color[1] = 0x00510000;
                color[2] = 0x009f0000;
                color[3] = 1;
            }
            if(selectedTheme == 3) //default lame
            {
                color[0] = 0;
                color[1] = 0;
                color[2] = 0;
                color[3] = 0;
            }
            if (selectedTheme == 4) //Blood (Red)
            {
                color[0] = 0x00040068;
                color[1] = 0x0002003b;
                color[2] = 0x00040068;
                color[3] = 1;
            }
            if (selectedTheme == 5) //Sky (actually good looking blue)
            {
                color[0] = 0x00ffd799;
                color[1] = 0x007f5d28;
                color[2] = 0x00ffd799;
                color[3] = 1;
            }
            if(selectedTheme == 6) //Red and Blue
            {
                color[0] = 0x00b44900;
                color[1] = 0x002003b;
                color[2] = 0x00b44900;
                color[3] = 1;
            }
            if(selectedTheme == 66) 
            {
                color[0] = mainColor;
                color[1] = otherColor;
                color[2] = mainColor;
                color[3] = 1;
            }

            DWM.SetValue("AccentColor", color[0], RegistryValueKind.DWord);
            DWM.SetValue("AccentColorInactive", color[1], RegistryValueKind.DWord);
            windowOutline.SetValue("AccentColorMenu", color[2], RegistryValueKind.DWord);
            DWM.SetValue("ColorPrevalence", color[3], RegistryValueKind.DWord);
            
        }
    }
}
