using System.Collections.Generic;
using System.Text;

using Chess.Common;

namespace Chess
{
    public class ChessGame
    {
        public string[,] Board = new string[8, 8];
        public List<string> Moves = new List<string>();
        public List<string> PiecesTaken = new List<string>();
        public StringBuilder StringOfPiecesTaken = new StringBuilder();
        public bool FLIPPED;
        public static GameState GAMESTATE;

        public ChessGame()
        {
            Board = this.InitialiseGame();
            FLIPPED = false;
            GAMESTATE = GameState.OK;
        }

        public string[,] InitialiseGame()
        {
            string[,] board = new string[8, 8]              // these are the memory coordnates..
            {
            {" r"," n"," b"," q"," k"," b"," n"," r"},     // [0,0],[0,1],[0,2],[0,3],[0,4],[0,5],[0,6],[0,7]
            {" p"," p"," p"," p"," p"," p"," p"," p"},      // [1,0],[1,1],[1,2],[1,3]
            {"  ","  ","  ","  ","  ","  ","  ","  "},
            {"  ","  ","  ","  ","  ","  ","  ","  "},      // so for example move a1c3 would translate to (7,0,5,2)
            {"  ","  ","  ","  ","  ","  ","  ","  "},
            {"  ","  ","  ","  ","  ","  ","  ","  "},
            {" P"," P"," P"," P"," P"," P"," P"," P"},
            {" R"," N"," B"," Q"," K"," B"," N"," R"},      // 70,71,72,73....
            };
            return board;
        }
    }
}