using System.Linq;

namespace Chess
{
    partial class Validation
    {
        public bool IsCastlingValid(ChessGame game, string move)
        {
            if (!IsEmptySquaresInBetween(game, move))
            {
                return false;
            }

            string src;
            if (game.Moves.Count % 2 == 0)
            {
                //white moving
                for (int i = 0; i < game.Moves.Count; i++)        //look at all previous moves
                {
                    src = game.Moves.ElementAt(i).Substring(0, 2);
                    if (src == "e1")                            //if the king has already been moved then castling is not allowed
                        return false;

                    if (move == "0")                            //king side castle
                    {
                        if (src == "h1")                    //castle on king side has already moved
                            return false;
                    }
                    else                                        //must be queen side castle - 00
                    {
                        if (src == "a1")                    //castle on queen side has already moved
                            return false;
                    }
                }
            }
            else
            {
                //black castling
                for (int i = 0; i < game.Moves.Count; i++)        //look at all previous moves
                {
                    src = game.Moves.ElementAt(i).Substring(0, 2);
                    if (src == "e8")                            //if the king has already been moved then castling is not allowed
                        return false;

                    if (move == "0")                            //king side castle
                    {
                        if (src == "h8")                    //castle on king side has already moved
                            return false;
                    }
                    else                                        //must be queen side castle - 00
                    {
                        if (src == "a8")                    //castle on queen side has already moved
                            return false;
                    }
                }
            }

            return true;
        }
    }
}