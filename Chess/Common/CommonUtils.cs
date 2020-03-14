using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Chess
{
    public static class CommonUtils
    {
        public static bool CheckRegEx(string check, string expression)
        {
            if (Regex.Match(check, expression).Success)
            {
                return true;
            }
            return false;
        }

        //write the current state of the board with a grid drawn around it and axes labelled and pieces taken
        //if FLIPPED it will draw it FLIPPED
        public static void WriteGameState(string[,] board, List<string> allmoves, StringBuilder piecesTaken, bool FLIPPED)
        {
            if (allmoves.Count % 2 == 0)   //then its even or zero
            {
                Console.WriteLine("╔══╦══╦══╦══╦══╦══╦══╦══╗  WHITE to move...");
            }
            else
            {
                Console.WriteLine("╔══╦══╦══╦══╦══╦══╦══╦══╗  BLACK to move...");
            }
            for (int R = 0; R < 8; R++)
            {
                for (int F = 0; F < 8; F++)
                {
                    if (!FLIPPED)
                    { Console.Write("║" + board[R, F]); }
                    else
                    { Console.Write("║" + board[7 - R, 7 - F]); }
                    if (F == 7)
                    {
                        if (!FLIPPED)
                        { Console.Write("║ " + (8 - R).ToString()); }
                        else
                        { Console.Write("║ " + (R + 1).ToString()); }
                        Console.Write("\n");
                    }
                }
                if (R < 7)
                    Console.WriteLine("╠══╬══╬══╬══╬══╬══╬══╬══╣");
            }
            Console.WriteLine("╚══╩══╩══╩══╩══╩══╩══╩══╝");
            if (!FLIPPED)
            { Console.WriteLine(" a  b  c  d  e  f  g  h    Pieces taken: " + piecesTaken); }
            else
            { Console.WriteLine(" h  g  f  e  d  c  b  a    Pieces taken: " + piecesTaken); }
            Console.WriteLine();
        }
    }
}
