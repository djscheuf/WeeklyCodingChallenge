﻿using System;
using static System.Console; using static System.ConsoleColor;
class Prog2
{
    static void min()
    {
        var r = @"2 3$2/3$1_9$3 .1 2$2/2$2/3$1_9$1 .1$2/2$2/3$2/9$2$.1|2$2/3$2/3$5_5$.2$2|2$2/3$1/2$2_3$1\3$.9$1$1|2$1(2$1)2$1|3$.9$1$1|3$2-3$1/3$.1 9$1|2$1|4-4$1 .2 8$1|2$1|6$3 ".Split('.');
        var g = @"1 3_9 9 3 1_3 1_8 1.1|1 1_1 1\1_1 1_1 5_1 5_1 1_1 1_1|1 1|1_1(1_1)2_1 3_1 .1|2 1_1/1 1'1_1/1 1-1_1)1 1V1 1/1 1-1_1)1 1'1 1\2 1_1|1 1/1 1_1/1 1-1_1).1|1_1|1_1|1_1|1 1\3_1|1\1_1/1\1 3_1|1_2|1_1\2_1|1_1\2_1\3_|".Split('.');
        var a = @"1/1 1_1|1 3_1|1 1|1_2 1_1|1 1|1_1(1_1)3_1 1_1 1_2 3_.1\2_1 1\1/1 1_1 1\1 1|1 2|1 1|2 1_1|1 1/1 1_1 1\1 1'1 1\1(1_1-1<.1|3_1/1\3_1/1_1|1\1_1,1_1|1\2_1|1_1\3_1/1_2|1_1/2_1/".Split('.');

        pe(r[0], rc);
        WriteLine();
        for (var i = 0; i < 4; i++)
        {
            pe(r[i + 1], rc);
            Write("\t");
            Print(g[i], g_c_s);
            WriteLine();
        }
        for (var i = 0; i < 3; i++)
        {
            pe(r[i + 5], rc);
            Write("\t");
            Print(a[i], new Func<int,int, ConsoleColor>((j,l) => { return Gray; }));
            WriteLine();
        }
        pe(r[8], rc);
        ReadKey();
    }
    static void Print(string ln,Func<int,int,ConsoleColor>g_c){ var l=ln.Length; for(var i=0;i<l;i++){ var c = g_c(i,l); pc(ln[i], c); }}
    static void pe(string ln, Func<char,ConsoleColor>g_c){ for(var i=0;i< ln.Length; i+=2){ var c=ln[i + 1]; for (var j=0;j<(int)ln[i];j++){ pc(c, g_c(c));}}}

    static ConsoleColor g_c_s(int i, int l){var cs = new []{ DarkCyan, DarkGreen, Green, Yellow};
        return cs[(int)Math.Floor(i / Math.Ceiling((double)l / 4))];
    }
    static ConsoleColor rc(char c)
    {
        if (c == '$')
            return Blue;
        else
            return White;
    }
    static void pc(char p, ConsoleColor c)
    {
        var fg = ForegroundColor;
        ForegroundColor = c;

        Write(p);

        ForegroundColor = fg;
    }
}