using System;
using System.Collections.Generic;
using System.Text;

namespace Chess
{
    public class ChessGame
    {
        public ChessGame()
        {
            Board = this.InitialiseNewGame();
        }

        public string[,] Board = new string[8,8];
        
        public List<string> Moves = new List<string>();
        public List<string> PiecesTaken = new List<string>();
        public bool FLIPD = false;

        public string[,] InitialiseNewGame()
        {
            string[,] board = new string[8, 8]              // these are the memory coordnates..
            {{" r"," n"," b"," q"," k"," b"," n"," r"},     // 00,01,02,03,04,05,06,07
            {" p"," p"," p"," p"," p"," p"," p"," p"},      // 10,11,12,13
            {"  ","  ","  ","  ","  ","  ","  ","  "},
            {"  ","  ","  ","  ","  ","  ","  ","  "},      // so for example move a1c3 would translate to 7,0,5,2
            {"  ","  ","  ","  ","  ","  ","  ","  "},
            {"  ","  ","  ","  ","  ","  ","  ","  "},
            {" P"," P"," P"," P"," P"," P"," P"," P"},
            {" R"," N"," B"," Q"," K"," B"," N"," R"},      // 70,71,72,73....
            };
            return board;
        }
    }
}
