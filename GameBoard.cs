using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Puzzle
{
    class GameBoard
    {
        public string Name { get; protected set; }
        public int Length { get; protected set; }
        public int Width { get; protected set; }
        protected List<GameBoardSpace> Spaces;

        public GameBoard()
        {
            Name = "";
            Length = 0;
            Width = 0;
            Spaces = new List<GameBoardSpace>();
        }
        public GameBoard(string name, int length, int width)
        {
            Name = name;
            Length = length;
            Width = width;
            InitializeBoard(length, width);
        }
        protected void InitializeBoard(int length, int width)
        {
            if (length <= 0 || width <= 0)
            {
                Spaces = new List<GameBoardSpace>();
                Console.WriteLine("InitializeBoard(): Length or width cannot be 0.");
                return;
            }

            List<GameBoardSpace> newSpaces = new List<GameBoardSpace>();

            for (int l = 0; l < length; l++)
            {
                for (int w = 0; w < width; w++)
                {
                    GameBoardSpace space = new GameBoardSpace(l, w);
                    newSpaces.Add(space);
                }
            }

            Spaces = newSpaces;
            Console.WriteLine("InitializeBoard(): Created board with " + length * width + " spaces.");
        }
        public override string ToString()
        {
            return "Name: " + Name + "\nLength: " + Length + "\nWidth: " + Width;
        }
        public void PrintSpaces()
        {
            foreach (GameBoardSpace space in Spaces)
            {
                Console.WriteLine(space);
            }
        }
        public void UpdateSpace(int x, int y, int value)
        {
            if (x < 0 || y < 0)
            {
                Console.WriteLine("GameBoard: UpdateSpace(): x and y cannot be less than 0.");
                return;
            }
            else if (x > Length - 1 || y > Width - 1)
            {
                Console.WriteLine("GameBoard: UpdateSpace(): x and y cannot be outside the board dimensions.");
                return;
            }

            GameBoardSpace space = GetSpaceAt(x, y);
            space.Value = value;
        }
        protected bool IsInBounds(int length, int width)
        {
            if (length >= 0 && length <= Length - 1 && width >= 0 && width <= Width - 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        protected List<GameBoardSpace> GetSurroundingSpaces (GameBoardSpace space)
        {
            List<GameBoardSpace> spaces = new List<GameBoardSpace>();

            GameBoardSpace neighbor;

            neighbor = GetSpaceUpper(space);
            if (neighbor != null)
                spaces.Add(neighbor);

            neighbor = GetSpaceLower(space);
            if (neighbor != null)
                spaces.Add(neighbor);

            neighbor = GetSpaceLeft(space);
            if (neighbor != null)
                spaces.Add(neighbor);

            neighbor = GetSpaceRight(space);
            if (neighbor != null)
                spaces.Add(neighbor);

            neighbor = GetSpaceUpperLeft(space);
            if (neighbor != null)
                spaces.Add(neighbor);

            neighbor = GetSpaceUpperRight(space);
            if (neighbor != null)
                spaces.Add(neighbor);

            neighbor = GetSpaceLowerLeft(space);
            if (neighbor != null)
                spaces.Add(neighbor);

            neighbor = GetSpaceLowerRight(space);
            if (neighbor != null)
                spaces.Add(neighbor);

            return spaces;
        }
        protected GameBoardSpace GetSpaceUpper(GameBoardSpace space)
        {
            return GetSpaceAt(space.X, space.Y + 1);
        }
        protected GameBoardSpace GetSpaceLower(GameBoardSpace space)
        {
            return GetSpaceAt(space.X, space.Y - 1);
        }
        protected GameBoardSpace GetSpaceLeft(GameBoardSpace space)
        {
            return GetSpaceAt(space.X - 1, space.Y);
        }
        protected GameBoardSpace GetSpaceRight(GameBoardSpace space)
        {
            return GetSpaceAt(space.X + 1, space.Y);
        }
        protected GameBoardSpace GetSpaceUpperLeft(GameBoardSpace space)
        {
            return GetSpaceAt(space.X - 1, space.Y + 1);
        }
        protected GameBoardSpace GetSpaceUpperRight(GameBoardSpace space)
        {
            return GetSpaceAt(space.X + 1, space.Y + 1);
        }
        protected GameBoardSpace GetSpaceLowerLeft(GameBoardSpace space)
        {
            return GetSpaceAt(space.X - 1, space.Y - 1);
        }
        protected GameBoardSpace GetSpaceLowerRight(GameBoardSpace space)
        {
            return GetSpaceAt(space.X + 1, space.Y - 1);
        }
        /// <summary>
        /// Get the board space at the specified X and Y coordinates.
        /// </summary>
        /// <param name="x">X coordinate of the board space.</param>
        /// <param name="y">Y coordinate of the board space.</param>
        /// <returns>The board space at the specified X and Y coordinates.</returns>
        protected GameBoardSpace GetSpaceAt(int x, int y)
        {
            if (IsInBounds(x, y))
            {
                return Spaces.Find(s => s.X == x && s.Y == y);
            }
            else
            {
                return null;
            }
        }
    }
}
