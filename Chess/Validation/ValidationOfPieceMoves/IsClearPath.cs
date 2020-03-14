using System;

namespace Chess
{
    partial class Validation
    {
        public bool IsClearPath(ChessGame game, string move) //is the path clear?
        {
            var src = move.Substring(0, 2);
            var dst = move.Substring(2, 2);
            //real in memory coordinates..
            int srank = GetRank(src);           //source rank
            int sfile = GetFile(src);           //source file
            int drank = GetRank(dst);           //dest rank
            int dfile = GetFile(dst);           //dest file

            //if its any piece moving just one square then no spaces in between to check
            if ((Math.Abs(srank - drank) <= 1) && (Math.Abs(sfile - dfile) <= 1))
                return true;
            //if a knight is moving return true as they just jump over things so dont need to check spaces
            if (" N n".Contains(GetVal(game.Board, move.Substring(0, 2))))
                return true;

            //check spaces in between all other moves
            ///////// horizontal?
            if (Math.Abs(srank - drank) == 0) // y(rank) coordinate of src to dst not varying so moving horizontally
            {
                if (sfile < dfile)        //x(file) moving right
                {
                    for (int i = sfile + 1; i < dfile; i++) //so move along to the rank to the right by incrementing i
                    {
                        if (GetVal(game.Board, srank, i) != "  ")            //checking each square for blank
                            return false;                                   //if its not blank then something is in the way
                    }
                    return true;
                }
                else      //moving to left
                {
                    for (int i = sfile - 1; i > dfile; i--)   //so move along to the rank to the left by decrementing i
                    {
                        if (GetVal(game.Board, srank, i) != "  ")            //checking each square for blank
                            return false;                                   //if its not blank then something is in the way
                    }
                    return true;
                }
            }
            //////////////////////
            ///////// vertical?
            if (Math.Abs(sfile - dfile) == 0) // x(file) coordinate of src to dst not varying so moving vertically
            {
                if (srank > drank)        //y(rank) moving down
                {
                    for (int i = srank - 1; i > drank; i--) //so move up the file by decrementing i
                    {
                        if (GetVal(game.Board, i, sfile) != "  ")            //checking each square for blank
                            return false;                                   //if its not blank then something is in the way
                    }
                    return true;
                }
                else                  //moving up the file
                {
                    for (int i = srank + 1; i < drank; i++)   //so move down the file by decrementing i
                    {
                        if (GetVal(game.Board, i, sfile) != "  ")            //checking each square for blank
                            return false;                                   //if its not blank then something is in the way
                    }
                    return true;
                }
            }

            //diagonal ? if the absolute difference between the source rank and the destination rank is the same
            //           as the file source and destination difference then it is diagonal movement
            int j = 0;
            if (Math.Abs(srank - drank) == Math.Abs(sfile - dfile)) //this means it is diagonal movement
            {
                if (srank < drank)          //moving down the board (from the black side to the white side - source rank < destination rank)
                {
                    if (sfile < dfile)      //so, moving generally from 0,0 towards 7,7 (in memory coordinates) top left to bottom right
                    {
                        j = sfile + 1;        //start checks on the second square as the start square is where the piece is coming from
                        for (int i = srank + 1; i < drank; i++) //move along the diagonal with increasing rank, dont need to check the last square.. that has already been done in a previous method
                        {
                            if (GetVal(game.Board, i, j) != "  ")        //checking for non blank square
                                return false;
                            j++;                                    //increment the file coordinate
                        }
                    }
                    else
                    {                       //so, moving generally from 0,7 towards 7,0 (in memory coordinates) top right to bottom left
                        j = sfile - 1;
                        for (int i = srank + 1; i < drank; i++) //move along the diagonal with increasing rank
                        {
                            if (GetVal(game.Board, i, j) != "  ")        //checking for non blank square
                                return false;
                            j--;                                    //decrement the file coordinate
                        }
                    }
                    return true;
                }
                if (srank > drank)          //moving up the board (from the white side to the black side - source rank > destination rank)
                {
                    if (sfile < dfile)      //so, moving generally from 7,0 towards 0,7 (in memory coordinates) bottom left to top right
                    {
                        j = sfile + 1;
                        for (int i = srank - 1; i > drank; i--) //move along the diagonal with decreasing rank
                        {
                            if (GetVal(game.Board, i, j) != "  ")        //checking for non blank square
                                return false;
                            j++;                                    //increment the file coordinate
                        }
                    }
                    else
                    {                       //so, moving generally from 7,7 towards 0,0 (in memory coordinates) bottom right to top left
                        j = sfile - 1;
                        for (int i = srank - 1; i > drank; i--) //move down along the diagonal with decreasing rank
                        {
                            if (GetVal(game.Board, i, j) != "  ")        //checking for non blank square
                                return false;
                            j--;                                    //decrement the file coordinate
                        }
                    }
                    return true;
                }
            }
            return true;
        }
    }
}