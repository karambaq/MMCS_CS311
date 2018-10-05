﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using SimpleLangLexer;

namespace SimpleLangLexerTest
{
    class Program
    {
        public static void Main()
        {
            string fileContents = @"begin 
id23 := 24;
cycle ; 2 id258 id29 ;
asd123;
id23 := 10; -7 :1
cycle; 12
id12345 id12;
- -=
and not or
div mod
+= -= *= /=
> < >= <= = <>
id23 := 10; -7 :1
//> < >= <= = <>
{+= -= *= /=123}
+-/+=
<<=
>>=
--=
end";
            TextReader inputReader = new StringReader(fileContents);
            Lexer l = new Lexer(inputReader);
            try
            {
                do
                {
                    Console.WriteLine(l.TokToString(l.LexKind));
                    l.NextLexem();
                } while (l.LexKind != Tok.EOF);
            }
            catch (LexerException e)
            {
                Console.WriteLine("lexer error: " + e.Message);
            }
        }
    }
}