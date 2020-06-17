using System;
using System.Collections.Generic;
using Chess.Common;

namespace Chess.Testing
{
    class Test1
    {
        public static void TestThis()
        {
            var intBoard = new BoardInternal();
            intBoard.InitialiseGame();
            DisplayBoard(intBoard);

            
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

            //string piece = " ";
            dict.TryGetValue(ps, out string piece);

            return piece;
        }

        private static void DisplayBoard(BoardInternal intBoard)
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

        
        
        


    }
}
