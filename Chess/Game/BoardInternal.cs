using Chess.Common;
using System.Collections.Generic;

namespace Chess
{
    public class BoardInternal
    {
        public P[,] Board = new P[8, 8];
        public List<string> Moves = new List<string>();
        public List<string> PiecesTaken = new List<string>();
        public bool FLIPPED;
        public static GameState GAMESTATE;

        public BoardInternal()
        {
            Board = this.InitialiseGame();
            FLIPPED = false;
            GAMESTATE = GameState.OK;
        }

        public P[,] InitialiseGame()
        {
            P[,] board = new P[8, 8]              // these are the memory coordnates..
            {
            {P.BR,P.BN,P.BB,P.BK,P.BQ,P.BB,P.BN,P.BR},     // [0,0],[0,1],[0,2],[0,3],[0,4],[0,5],[0,6],[0,7]
            {P.BP,P.BP,P.BP,P.BP,P.BP,P.BP,P.BP,P.BP},      // [1,0],[1,1],[1,2],[1,3]
            {P.__,P.__,P.__,P.__,P.__,P.__,P.__,P.__},
            {P.__,P.__,P.__,P.__,P.__,P.__,P.__,P.__},      // so for example move a1c3 would translate to (7,0,5,2)
            {P.__,P.__,P.__,P.__,P.__,P.__,P.__,P.__},
            {P.__,P.__,P.__,P.__,P.__,P.__,P.__,P.__},
            {P.WP,P.WP,P.WP,P.WP,P.WP,P.WP,P.WP,P.WP},
            {P.WR,P.WN,P.WB,P.WK,P.WQ,P.WB,P.WN,P.WR},      // 70,71,72,73....
            };
            return board;
        }
    }
}
