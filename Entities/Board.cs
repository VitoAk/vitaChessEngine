namespace Entities
{
    class Board
    {
        // White
        private ulong WhitePawns;
        private ulong WhiteRooks;
        private ulong WhiteKnights;
        private ulong WhiteBishops;
        private ulong WhiteQueen;
        private ulong WhiteKing;

        // Black
        private ulong BlackPawns;
        private ulong BlackRooks;
        private ulong BlackKnights;
        private ulong BlackBishops;
        private ulong BlackQueen;
        private ulong BlackKing;

        private ulong WhitePieces;
        private ulong BlackPieces;
        private ulong BoardMask;

        public Board()
        {
            // !!! 1UL explecitely tells the compiler that were are shifting type UL var, (1 << 0) would shift and int (4 bytes) => wrong from init
            WhitePawns   = Bitboards.Rank2;
            WhiteRooks  = (1UL << 0) | (1UL << 7);
            WhiteKnights= (1UL << 1) | (1UL << 6);
            WhiteBishops= (1UL << 2) | (1UL << 5);
            WhiteQueen  = (1UL << 4);
            WhiteKing   = (1UL << 3);

            BlackPawns   = Bitboards.Rank7;
            BlackRooks  = (1UL << 56) | (1UL << 63);
            BlackKnights= (1UL << 57) | (1UL << 62);
            BlackBishops= (1UL << 58) | (1UL << 61);
            BlackQueen  = (1UL << 59);
            BlackKing   = (1UL << 60);

            WhitePieces = WhitePawns | WhiteRooks | WhiteKnights | WhiteBishops | WhiteQueen | WhiteKing;
            BlackPieces = BlackPawns | BlackRooks | BlackKnights | BlackBishops | BlackQueen | BlackKing;

            BoardMask = WhitePieces | BlackPieces;
        }

        public void Print()
        {
            Console.WriteLine(BoardMask);
        }
    }
}