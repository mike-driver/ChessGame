using Chess.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chess
{
    public class Game
    {
        public static StringBuilder PiecesTaken = new StringBuilder();
        public static StringBuilder Message = new StringBuilder();
        public static List<String> AllMoves = new List<string>();

        private static bool PLAYING = true;
        public static bool FLIPPED;

        public static GameState GAMESTATE;

        

        public static void Main(string[] args)
        {
            string LowerCaseMove;

            ChessGame Game1 = new ChessGame();
            ChessGame Game2 = new ChessGame();

            while (PLAYING)
            {
                WriteBoard(Game1.Board);
                Message.Clear();
                LowerCaseMove = Console.ReadLine().ToLower();
                
                Validation validate = new Validation();

                if (validate.IsFormatValid(LowerCaseMove))
                {
                    if (LowerCaseMove.StartsWith("q"))   //quit the game
                    {
                        PLAYING = false;
                    }
                    else if (LowerCaseMove.StartsWith("r"))  //reset
                    {
                        FLIPPED = false;
                        //ChessGame = Board.CreateNewGame();    //reset this board
                        //PiecesTaken.Clear();
                        //AllMoves.Clear();
                        Game1.Moves.Clear();
                        Game1.PiecesTaken.Clear();
                    }
                    else if (LowerCaseMove.StartsWith("s"))      //switch the board around (flip)
                    {
                        //FLIPPED = !FLIPPED;
                        Game1.FLIPD = !Game1.FLIPD;
                    }
                    else
                    {
                        if (//validate.IsValidMove(Game1, LowerCaseMove) && 
                            validate.IsPieceMoveValid(Game1, LowerCaseMove) && 
                            validate.IsClearPath(Game1, LowerCaseMove) && 
                            validate.DoesMovePutSelfInCheck(LowerCaseMove))
                        {
                            if (validate.StorePieceMovePiece(Game1, LowerCaseMove))
                            {
                                Game1.Moves.Add(LowerCaseMove);
                            }
                        }
                        else
                        {
                            Message.Append("Invalid move :" + LowerCaseMove + " ");
                        }
                    }
                }
                else
                {
                    Message.Append("Invalid move :" + LowerCaseMove + " ");
                }
            }
        }

        private static void WriteBoard(string[,] Board)
        {
            Console.Clear();
            Console.WriteLine("Chess game: " + Board.GetHashCode());
            CommonUtils.WriteGameState(Board, AllMoves, PiecesTaken, FLIPPED);
            Console.WriteLine();
            Console.WriteLine(Message);
            Console.Write("Enter your move: ");     //e.g. 'e2e4'  'a1h8' 'reset' 'flip' 'quit' ....
        }
    }
}


