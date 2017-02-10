using System;
using System.Collections.Generic;

namespace PreventiceLogo_OnConsole
{
    class Program
    {
        private static List<string> grad_preventice = new List<string>()
        {
             @" ___                     _   _         "
            ,@"| _ \_ _ _____ _____ _ _| |_(_)__ ___  "
            ,@"|  _/ '_/ -_) V / -_) ' \  _| / _/ -_) "
            ,@"|_|_|_| \___|\_/\___|_||_\__|_\__\___| "
        };

        static List<string> art_solutions = new List<string>()
        {
             @"/ __| ___| |_  _| |_(_)___ _ _  ___ "
            ,@"\__ \/ _ \ | || |  _| / _ \ ' \(_-< "
            ,@"|___/\___/_|\_,_|\__|_\___/_||_/__/ "
        };

        static List<string> radio_p = new List<string>()
        {
                @"  $$$$//$$$$$$$$$$$$   "
               ,@" $$//$$$//$_$$$$$$$$$$ "
               ,@"$//$$//$$$//$$$$$$$$$$$"
               ,@"//$//$$//$$$$_____$$$$$"
               ,@"$$||$$//$$$/$$__$$$\$$$"
               ,@"$$$$$$$$$$|$$($$)$$|$$$"
               ,@"$$$$$$$$$$|$$$--$$$/$$$"
               ,@" $$$$$$$$$|$$|----$$$$ "
               ,@"  $$$$$$$$|$$|$$$$$$   "
        };
        
        static void Main(string[] args)
        {
            PrintLogo();
            Console.ReadKey();
        }

        private static void PrintLogo()
        {
            PrintRadio(radio_p[0],true);

            for(var i = 0; i<4; i++)
            {
                PrintRadio(radio_p[i + 1], false);
                PrintGradient(grad_preventice[i]);
            }

            for(var i = 0; i<3; i++)
            {
                PrintRadio(radio_p[i+5],false);
                PrintArt(art_solutions[i]);
            }

            PrintRadio(radio_p[8], true);   
        }

        static void PrintRadio(string line, bool printLine)
        {
            var len = line.Length;
            ConsoleColor color;
            for (var idx = 0; idx < len; idx++)
            {
                if (line[idx] == '$')
                    color = ConsoleColor.Blue;
                else
                    color = ConsoleColor.White;
                PrintColorCharacter(line[idx], color);
            }

            if (printLine)
                Console.WriteLine();
            else
                Console.Write("\t");
       }

        static void PrintGradient(string line)
        {
            var len = line.Length;
            for (var i = 0; i < len; i++)
            {
                var color = GetConsoleColorForStep(i, len);
                PrintColorCharacter(line[i], color);
            }
            Console.WriteLine();
        }

        static void PrintArt(string line)
        {
            var fg = Console.ForegroundColor;

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(line);

            Console.ForegroundColor = ConsoleColor.Gray;
        }

        private static int dev_steps = 4;
        static List<ConsoleColor> Colors = new List<ConsoleColor>() {ConsoleColor.DarkCyan, ConsoleColor.DarkGreen, ConsoleColor.Green,ConsoleColor.Yellow };
        private static ConsoleColor GetConsoleColorForStep(int step, int range)
        {
            var group_size = (int)Math.Ceiling((double)range / dev_steps);
            var group_idx = (int)Math.Floor((double)step / group_size);
            return Colors[group_idx];
        }
        
        private static void PrintColorCharacter(char printee, ConsoleColor color)
        {
            var fg = Console.ForegroundColor;
            Console.ForegroundColor = color;

            Console.Write(printee);

            Console.ForegroundColor = fg;
        }
    }
}
