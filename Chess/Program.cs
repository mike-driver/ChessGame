﻿using System;
using System.Text;

using Chess.Model;

namespace Chess
{
    public class Game
    {
        public static StringBuilder Message = new StringBuilder();
        private static bool PLAYING = true;

        public static void Main()
        {
            string LowerCaseMove;
            Validation validate = new Validation();

            ChessGame Game1 = new ChessGame();

            BoardInternal Game2 = new BoardInternal();
            //test comment
            while (PLAYING)
            {
                CommonUtils.DisplayBoard(Game2);
                WriteBoard(Game1);
                Message.Clear();

                LowerCaseMove = Console.ReadLine().ToLower();

                if (validate.IsFormatValid(LowerCaseMove))
                {
                    if (LowerCaseMove == "r" || LowerCaseMove == "f" || LowerCaseMove == "s" || LowerCaseMove == "q")
                    {
                        CommandMove(Game1, LowerCaseMove);
                        CommandMove2(Game2, LowerCaseMove);
                    }
                    else
                    {
                        ChessMove(Game1, Game2, LowerCaseMove, validate);
                        ChessMove2(Game2, LowerCaseMove, validate);
                    }
                }
                else
                {
                    Message.Append("Invalid move :" + LowerCaseMove + " ");
                }
            }
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
                game.StringOfPiecesTaken.Clear();
            }
            else if (move.StartsWith("f"))      //flip the board over
            {
                game.FLIPPED = !game.FLIPPED;
            }
            else if (move.StartsWith("s"))      //save
            {
                // save the game - TODO
            }
        }

        private static void CommandMove2(BoardInternal game, string move)
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
            else if (move.StartsWith("f"))      //flip the board over
            {
                game.FLIPPED = !game.FLIPPED;
            }
            else if (move.StartsWith("s"))      //save
            {
                // save the game - TODO
            }
        }

        private static void ChessMove(ChessGame game, BoardInternal game2, string move, Validation validate)
        {
            MoveModel mm = validate.GetMoveCoordsAndPiece(game, move);

            if (mm.srcval == "  ")
            {
                Message.Append("ERROR No piece to move from that square! :" + move + " ");
            }
            else if (!validate.IsWhiteOrBlackToMove(game, move))
            {
                if (game.Moves.Count % 2 == 0)
                {
                    Message.Append("ERROR White's move! :" + move + " ");
                }
                else
                {
                    Message.Append("ERROR Black's move! :" + move + " ");
                }
            }
            else if (validate.IsPieceMoveValid(game, move) && validate.IsClearPath(game, game2, move) && !validate.DoesMovePutSelfInCheck(move))
            {
                if (validate.StorePieceMovePiece(game, move))
                {
                    game.Moves.Add(move);
                }
            }
            else
            {
                Message.Append("ERROR Invalid move :" + move + " ");
            }
        }

        private static void ChessMove2(BoardInternal game, string move, Validation validate)
        {
            //if (validate.IsPieceMoveValid(game, move)
            //    && validate.IsClearPath(game, move)
            //    && validate.DoesMovePutSelfInCheck(move))
            //{
            //    if (validate.StorePieceMovePiece(game, move))
            //    {
            //        game.Moves.Add(move);
            //    }
            //}
            //else
            //{
            //    Message.Append("Invalid move :" + move + " ");
            //}
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