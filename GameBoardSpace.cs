using System;
using System.Collections.Generic;
using System.Text;

namespace Puzzle
{
    class GameBoardSpace
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public int Value { get; set; }

        public GameBoardSpace()
        {
            X = 0;
            Y = 0;
            Value = 0;
        }
        public GameBoardSpace(int x, int y)
        {
            X = x;
            Y = y;
            Value = 0;
        }
        public GameBoardSpace(int x, int y, int value)
        {
            X = x;
            Y = y;
            Value = value;
        }
        public override string ToString()
        {
            return "X: " + X + ", Y: " + Y + ", Value: " + Value;
        }
        public override bool Equals(object obj)
        {
            return base.Equals(obj as GameBoardSpace);
        }
        public bool Equals(GameBoardSpace space)
        {
            return this.X == space.X && this.Y == space.Y;
        }
    }
}
