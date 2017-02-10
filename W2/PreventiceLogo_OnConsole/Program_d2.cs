using System;
using System.Collections.Generic;
class Prog
{
    static void main_2(string[] args)
    {
        var radio_p = new List<string>()
{
@"  $$$//$$$_$$$$$$$$$   "
,@" $$//$$//$$$_$$$$$$$$$ "
,@"$//$$//$$$//$$$$$$$$$$$"
,@"|$$//$$$//$$$_____$$$$$"
,@"$$||$$//$$$/$$__$$$\$$$"
,@"$$$$$$$$$$|$$($$)$$|$$$"
,@"$$$$$$$$$$|$$$--$$$/$$$"
,@" $$$$$$$$$|$$|----$$$$ "
,@"  $$$$$$$$|$$|$$$$$$   "
};
        var grad_preventice = new List<string>()
{
 @" ___                     _   _        "
,@"| _ \_ _ _____ _____ _ _| |_(_)__ ___ "
,@"|  _/ '_/ -_) V / -_) ' \  _| / _/ -_)"
,@"|_|_|_| \___|\_/\___|_||_\__|_\__\___|"
};
        var art_solutions = new List<string>()
{
 @"/ __| ___| |_  _| |_(_)___ _ _  ___"
,@"\__ \/ _ \ | || |  _| / _ \ ' \(_-<"
,@"|___/\___/_|\_,_|\__|_\___/_||_/__/"
};
        Print(radio_p[0], RadioColor);
        Console.WriteLine();
        for (var i = 0; i < 4; i++)
        {
            Print(radio_p[i + 1], RadioColor);
            Console.Write("\t");
            Print(grad_preventice[i], GetConsoleColorForStep);
            Console.WriteLine();
        }
        for (var i = 0; i < 3; i++)
        {
            Print(radio_p[i + 5], RadioColor);
            Console.Write("\t");
            Print(art_solutions[i], new Func<string, int, int, ConsoleColor>((str, d, l) => { return ConsoleColor.Gray; }));
            Console.WriteLine();
        }
        Print(radio_p[8], RadioColor);
        Console.ReadKey();
    }
    static void Print(string line,Func<string,int,int,ConsoleColor>get_color)
    {
        var l = line.Length;
        for (var i = 0; i < l; i++)
        {
            var color = get_color(line, i, l);
            PrintChar(line[i], color);
        }
    }
    static ConsoleColor GetConsoleColorForStep(string line, int i, int l)
    {
        var Colors = new []{ ConsoleColor.DarkCyan, ConsoleColor.DarkGreen, ConsoleColor.Green, ConsoleColor.Yellow};
        return Colors[(int)Math.Floor(i / Math.Ceiling((double)l / 4))];
    }
    static ConsoleColor RadioColor(string line, int i, int l)
    {
        if (line[i] == '$')
            return ConsoleColor.Blue;
        else
            return ConsoleColor.White;
    }
    static void PrintChar(char printee, ConsoleColor color)
    {
        var fg = Console.ForegroundColor;
        Console.ForegroundColor = color;

        Console.Write(printee);

        Console.ForegroundColor = fg;
    }
}