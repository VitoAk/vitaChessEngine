using System;
using Entities;

namespace vitaChessEngine
{
    static class Engine
    {
        static void Main()
        {
            Board board = new Board();
            board.PrintAlpha();
            board.MakeMove("e2","e4");
            board.PrintAlpha();
        }
    }
}