
using System;
using System.Text;

namespace Chess
{
    public class Game
    {
        public static StringBuilder Message = new StringBuilder();

        private static bool PLAYING = true;

        public static void Main(string[] args)
        {
            //testing method
            TestThis();
            //

            string LowerCaseMove;
            Validation validate = new Validation();

            ChessGame Game1 = new ChessGame();
            ChessGame Game2 = new ChessGame();

            while (PLAYING)
            {
                WriteBoard(Game1);
                Message.Clear();
                LowerCaseMove = Console.ReadLine().ToLower();
                
                if (validate.IsFormatValid(LowerCaseMove))
                {
                    if (LowerCaseMove == "q" || LowerCaseMove == "r" || LowerCaseMove == "s")
                    {
                        CommandMove(Game1, LowerCaseMove);
                    }
                    else
                    {
                        ChessMove(Game1, LowerCaseMove, validate);
                    }
                }
                else
                {
                    Message.Append("Invalid move :" + LowerCaseMove + " ");
                }
            }
        }

        private static void TestThis()
        {
            var intBoard = new BoardInternal();
            DisplayBoard(intBoard);
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
                        { Console.Write("║" + intBoard.Board[R, F]); }
                        else
                        { Console.Write("║" + intBoard.Board[7 - R, 7 - F]); }
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





        private static void CommandMove(ChessGame game, string move)
        {
            if (move.StartsWith("q"))   //quit the game
            {
                PLAYING = false;
            }
            else if (move.StartsWith("r"))  //reset
            {
                game.FLIPPED = false;
                game.Board = game.InitialiseGame();
                game.Moves.Clear();
                game.PiecesTaken.Clear();
            }
            else if (move.StartsWith("s"))      //switch the board around (flip)
            {
                game.FLIPPED = !game.FLIPPED;
            }
        }

        private static void ChessMove(ChessGame game, string move, Validation validate)
        {
            if (validate.IsPieceMoveValid(game, move) &&
                            validate.IsClearPath(game, move) &&
                            validate.DoesMovePutSelfInCheck(move))
            {
                if (validate.StorePieceMovePiece(game, move))
                {
                    game.Moves.Add(move);
                }
            }
            else
            {
                Message.Append("Invalid move :" + move + " ");
            }
        }

        private static void WriteBoard(ChessGame game)
        {
            Console.Clear();
            Console.WriteLine("Chess game: " + game.GetHashCode());
            CommonUtils.WriteGameState(game);
            Console.WriteLine();
            Console.WriteLine(Message);
            Console.Write("Enter your move: ");     //e.g. 'e2e4'  'a1h8' 'reset' 'flip' 'quit' ....
        }
    }
}


