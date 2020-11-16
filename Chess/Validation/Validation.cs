using System;
using System.Linq;
using System.Text;

using Chess.Common;
using Chess.Model;

namespace Chess
{
    public partial class Validation
    {
        public static StringBuilder Message = new StringBuilder();

        public bool IsWhiteOrBlackToMove(ChessGame game, string move)
        {
            MoveModel mm = GetMoveCoordsAndPiece(game, move);

            //blacks turn?
            if (" r n b q k p".Contains(mm.srcval))
            {
                if (game.Moves.Count % 2 == 0)
                {
                    return false;
                }
            }
            //whites turn?
            if (" R N B Q K P".Contains(mm.srcval))
            {
                if (game.Moves.Count % 2 != 0)
                {
                    return false;
                }
            }

            return true;
        }

        public bool IsPieceMoveValid(ChessGame game, string move)
        {
            MoveModel mm = GetMoveCoordsAndPiece(game, move);

            //If castling
            if ((move == "0") || (move == "00"))
            {
                if (IsCastlingValid(game, move))
                {
                    return true;
                }
                return false;
            }

            switch (mm.srcval)
            {
                case " r":
                case " R":
                    if (!IsMovingLikeARook(mm.xsrc, mm.ysrc, mm.xdst, mm.ydst))
                        return false;
                    break;

                case " n":
                case " N":
                    if (!IsMovingLikeAKnight(mm.xsrc, mm.ysrc, mm.xdst, mm.ydst))
                        return false;
                    break;

                case " b":
                case " B":
                    if (!IsMovingLikeABishop(mm.xsrc, mm.ysrc, mm.xdst, mm.ydst))
                        return false;
                    break;

                case " q":
                case " Q":
                    if (!IsMovingLikeAQueen(mm.xsrc, mm.ysrc, mm.xdst, mm.ydst))
                        return false;
                    break;

                case " k":
                case " K":
                    if (!IsMovingLikeAKing(mm.xsrc, mm.ysrc, mm.xdst, mm.ydst))
                        return false;
                    break;

                case " p":
                    if (!IsMovingLikeABlackPawn(mm.dstval, mm.xsrc, mm.ysrc, mm.xdst, mm.ydst))
                        return false;
                    break;

                case " P":
                    if (!IsMovingLikeAWhitePawn(mm.dstval, mm.xsrc, mm.ysrc, mm.xdst, mm.ydst))
                        return false;
                    break;

                default:
                    break;
            }
            return true;
        }

        public MoveModel GetMoveCoordsAndPiece(ChessGame game, string move)
        {
            MoveModel mm = new MoveModel();
            var src = move.Substring(0, 2);
            var dst = move.Substring(2, 2);

            mm.xsrc = (int)Convert.ToChar(src.Substring(0, 1));
            mm.ysrc = (int)Convert.ToChar(src.Substring(1, 1));
            mm.xdst = (int)Convert.ToChar(dst.Substring(0, 1));
            mm.ydst = (int)Convert.ToChar(dst.Substring(1, 1));

            mm.srcval = (GetVal(game.Board, src));
            mm.dstval = (GetVal(game.Board, dst));
            return mm;
        }

        public bool IsValidMove(ChessGame game, string move)
        {
            if ((move == "0") || (move == "00"))
            {
                if (IsCastlingValid(game, move))
                {
                    return true;
                }
            }
            else
            {
                //NOW WE CAN GET THE src AND dst parts safely...
                var src = move.Substring(0, 2);
                var dst = move.Substring(2, 2);
                //XY_SRC_DST = GetXYs(move);                     //e.g. 4,2,4,4 .... ints !!! NOT USED ???
                //do some more fundamental checks !!!
                //make sure the source square is not a blank one !!!
                if (GetVal(game.Board, src) == "  ")
                {
                    return false;
                }
                //make sure its correct turn !!!
                //if (IsItYourTurn(board, src))
                //{
                //    return false;
                //}

                //make sure it is moving somewhere
                if (src == dst)
                {
                    return false;
                }
                //make sure move is not taking own piece
                if ((" R N B Q K P".Contains(GetVal(game.Board, src))) && (" R N B Q K P".Contains(GetVal(game.Board, dst)))
                    ||
                    (" r n b q k p".Contains(GetVal(game.Board, src))) && (" r n b q k p".Contains(GetVal(game.Board, dst))))
                {
                    return false;
                }
            }
            return true;
        }

        public bool DoesMovePutSelfInCheck(string move)  //are you not putting yourself in check
        { return false; }

        public bool DoesMovePutOpponentInCheck(string[,] board, string move)  //are you not putting oppo in check
        { return true; }

        public string GetVal(string[,] board, int x, int y)
        {
            return board[x, y];
        }

        public string GetVal(string[,] board, string pos)
        {
            return board[GetRank(pos), GetFile(pos)];
        }

        private static int GetFile(string pos)
        {
            //'a' ... 'h' ----->  1 ..... 8
            // subtract 1 for 0 index
            char letter = Convert.ToChar(pos.Substring(0, 1));
            int F = (int)letter - 96 - 1;
            return F;
        }

        private static int GetRank(string pos)
        {
            // 1 ..... 8  -----> 0 .... 7  .... because the board is the other way around in the array
            // and we subtract 1 for the 0 index start
            int swap = 8 + 1 - (int.Parse(pos.Substring(1, 1)));
            int R = swap - 1;
            return R;
        }

        public bool StorePieceMovePiece(ChessGame game, string move)
        {
            var src = move.Substring(0, 2);
            var dst = move.Substring(2, 2);
            var srcval = GetVal(game.Board, src);
            var dstval = GetVal(game.Board, dst);
            //write the src val into dst position
            game.Board[GetRank(dst), GetFile(dst)] = srcval;
            //put a blank in the src position
            game.Board[GetRank(src), GetFile(src)] = "  ";
            //store the taken piece
            if (dstval != "  ")
            {
                game.PiecesTaken.Add(dstval.Substring(1, 1) + ":");                 //is this used - TODO
                game.StringOfPiecesTaken.Append(dstval.Substring(1, 1) + ":");
                Message.Clear();
                switch (dstval)
                {
                    case " r":
                    case " R":
                        Message.Append("Takes CASTLE");
                        break;

                    case " n":
                    case " N":
                        Message.Append("Takes KNIGHT");
                        break;

                    case " b":
                    case " B":
                        Message.Append("Takes BISHOP");
                        break;

                    case " q":
                    case " Q":
                        Message.Append("Takes QUEEN");
                        break;

                    case " k":
                    case " K":
                        Message.Append("Takes KING");
                        break;

                    case " p":
                    case " P":
                        Message.Append("Takes PAWN");
                        break;

                    default:
                        Message.Append("Takes " + dstval);
                        break;
                }
            }
            else
            {
                Message.Clear();
            }
            return true;
        }

        //new methods:
        public P PieceOnSquare(P[,] internalboard, int x, int y)
        {
            return internalboard[x, y];
        }

        public P PieceOnSquare(P[,] internalboard, string pos)
        {
            return internalboard[GetRank(pos), GetFile(pos)];
        }
    }
}