namespace Chess
{
    partial class Validation
    {
        public bool IsEmptySquaresInBetween(ChessGame game, string move)
        {
            //make sure there are empty squares in between on the relevent side
            if (game.Moves.Count % 2 == 0)
            {
                //white moving
                if (move == "0")                            //king side castle
                {
                    if ((game.Board[7, 5] != "  ") || (game.Board[7, 6] != "  "))
                        return false;
                }
                else                                        //must be queen side castle - 00
                {
                    if ((game.Board[7, 1] != "  ") || (game.Board[7, 2] != "  ") || (game.Board[7, 3] != "  "))
                        return false;
                }
            }
            else
            {
                //black castling
                if (move == "0")                            //king side castle
                {
                    if ((game.Board[0, 5] != "  ") || (game.Board[0, 6] != "  "))
                        return false;
                }
                else                                        //must be queen side castle - 00
                {
                    if ((game.Board[0, 1] != "  ") || (game.Board[0, 2] != "  ") || (game.Board[0, 3] != "  "))
                        return false;
                }
            }
            return true;
        }
    }
}