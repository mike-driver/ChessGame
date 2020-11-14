using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

using Chess.Common;

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
        public static void WriteGameState(ChessGame game)
        {
            if (game.Moves.Count % 2 == 0)   //then its even or zero
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
                    if (!game.FLIPPED)
                    { Console.Write("║" + game.Board[R, F]); }
                    else
                    { Console.Write("║" + game.Board[7 - R, 7 - F]); }
                    if (F == 7)
                    {
                        if (!game.FLIPPED)
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
            if (!game.FLIPPED)
            { Console.WriteLine(" a  b  c  d  e  f  g  h    Pieces taken: " + game.PiecesTaken); }
            else
            { Console.WriteLine(" h  g  f  e  d  c  b  a    Pieces taken: " + game.PiecesTaken); }
            Console.WriteLine();
        }

        //////
        ///

        public static void DisplayBoard(BoardInternal intBoard)
        {
            if (intBoard.Moves.Count % 2 == 0)   //then its even or zero
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
                    if (!intBoard.FLIPPED)
                    { Console.Write("║" + GetPiece(intBoard.Board[R, F])); }
                    else
                    { Console.Write("║" + GetPiece(intBoard.Board[7 - R, 7 - F])); }
                    if (F == 7)
                    {
                        if (!intBoard.FLIPPED)
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
            if (!intBoard.FLIPPED)
            { Console.WriteLine(" a  b  c  d  e  f  g  h    Pieces taken: " + intBoard.PiecesTaken); }
            else
            { Console.WriteLine(" h  g  f  e  d  c  b  a    Pieces taken: " + intBoard.PiecesTaken); }
            Console.WriteLine();
        }

        private static string GetPiece(P ps)
        {
            IDictionary<P, string> dict = new Dictionary<P, string>
            {
                { P.BB, " b" },
                { P.BK, " k" },
                { P.BN, " n" },
                { P.BP, " p" },
                { P.BQ, " q" },
                { P.BR, " r" },
                { P.WB, " B" },
                { P.WK, " K" },
                { P.WN, " N" },
                { P.WP, " P" },
                { P.WQ, " Q" },
                { P.WR, " R" },
                { P.__, "  " }
            };

            dict.TryGetValue(ps, out string piece);
            return piece;
        }
    }
}