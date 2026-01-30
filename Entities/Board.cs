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

        public void PrintNumeric()
        {
            for(int rank = 7; rank >= 0; rank--)
            {
                for(int file = 0; file < 7; file++)
                {
                    int square = rank * 8 + file;
                    ulong mask = 1UL << square;
                    Console.Write((BoardMask & mask) != 0 ? " 1" : " 0");
                }
                Console.WriteLine("");
            }
        }

        public void PrintAlpha()
        {
            for(int rank = 7; rank >= 0; rank--)
            {
                for(int file = 0; file < 8; file++)
                {
                    int square = rank * 8 + file;
                    Console.Write(GetPieceAtSquare(square) + " ");
                }
                Console.WriteLine("");
            }
        }

        private char GetPieceAtSquare(int square)
        {
            ulong mask = 1UL << square;

            if ((WhitePawns & mask) != 0) return 'P';
            if ((WhiteRooks & mask) != 0) return 'R';
            if ((WhiteKnights & mask) != 0) return 'N';
            if ((WhiteBishops & mask) != 0) return 'B';
            if ((WhiteQueen & mask) != 0) return 'Q';
            if ((WhiteKing & mask) != 0) return 'K';

            if ((BlackPawns & mask) != 0) return 'p';
            if ((BlackRooks & mask) != 0) return 'r';
            if ((BlackKnights & mask) != 0) return 'n';
            if ((BlackBishops & mask) != 0) return 'b';
            if ((BlackQueen & mask) != 0) return 'q';
            if ((BlackKing & mask) != 0) return 'k';

            return '.';
        }

        public void MakeMove(string squareFrom, string squareTo)
        {
            int sqFrom = AlphaToIntSquare(squareFrom);
            int sqTo = AlphaToIntSquare(squareTo);

            ulong maskFrom = 1UL << sqFrom;
            ulong maskTo = 1UL << sqTo;

            if((WhitePawns & maskFrom) != 0)
            {
                WhitePawns ^= maskFrom;
                WhitePawns |= maskTo;
            }
        }

        static int AlphaToIntSquare(string square)
        {
            int rank = Convert.ToInt32(Char.GetNumericValue(square[1])) - 1;

            int file = square[0] - 'a';
            
            return rank * 8 + file;
        }
    }
}