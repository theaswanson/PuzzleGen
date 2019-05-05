using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Puzzle
{
    class PrimeGameBoard : GameBoard
    {
        public GameBoardSpace StartSpace { get; protected set; }
        public GameBoardSpace EndSpace { get; protected set; }

        /// <summary>
        /// Initialize new prime puzzle game board with only 2 spaces.
        /// </summary>
        public PrimeGameBoard()
        {
            Name = "";
            Length = 2;
            Width = 1;
            InitializeBoard(2, 1);
            StartSpace = GetSpaceAt(0, 0);
            EndSpace = GetSpaceAt(1, 0);
        }
        /// <summary>
        /// Initialize new prime puzzle game board with specified name, length, and width.
        /// </summary>
        /// <param name="name">Name of the game board.</param>
        /// <param name="length">Length of the game board.</param>
        /// <param name="width">Width of the game board.</param>
        public PrimeGameBoard(string name, int length, int width)
        {
            Name = name;
            Length = length;
            Width = width;
            InitializeBoard(length, width);
            StartSpace = GetSpaceAt(0, 0);
            EndSpace = GetSpaceAt(length - 1, width - 1);
        }
        /// <summary>
        /// Initialize new prime puzzle game board with specified name, length, width, and the coordinates of the start and end spaces.
        /// </summary>
        /// <param name="name">Name of the game board.</param>
        /// <param name="length">Length of the game board.</param>
        /// <param name="width">Width of the game board.</param>
        /// <param name="startX">X coordinate of start space.</param>
        /// <param name="startY">Y coordinate of start space.</param>
        /// <param name="endX">X coordinate of end space.</param>
        /// <param name="endY">Y coordinate of end space.</param>
        public PrimeGameBoard(string name, int length, int width, int startX, int startY, int endX, int endY)
        {
            Name = name;
            Length = length;
            Width = width;
            InitializeBoard(length, width);

            if (IsInBounds(startX, startY) && IsInBounds(endX, endY) && (startX != endX && startY != endY))
            {
                StartSpace = GetSpaceAt(startX, startY);
                EndSpace = GetSpaceAt(endX, endY);
            }
            else
            {
                StartSpace = GetSpaceAt(0, 0);
                EndSpace = GetSpaceAt(length - 1, width - 1);
            }
        }
        public override string ToString()
        {
            return "Name: " + Name + "\nLength: " + Length + "\nWidth: " + Width + "\nStart space: " + StartSpace + "\nEnd space: " + EndSpace;
        }

        public List<GameBoardSpace> path = new List<GameBoardSpace>();
        public bool solved = false;
        public void Solve(GameBoardSpace space, int movesRemaining)
        {
            path.Add(space);

            if (space == EndSpace)
            {
                Console.WriteLine("Solved!");
                foreach (GameBoardSpace node in path)
                {
                    Console.WriteLine(node);
                }
                solved = true;
            }
            else
            {
                Random rng = new Random();

                List<GameBoardSpace> spaces = GetSurroundingSpaces(space);
                List<GameBoardSpace> shuffled = spaces.OrderBy(a => rng.Next()).ToList();

                foreach (GameBoardSpace nextSpace in shuffled)
                {
                    if (solved)
                        break;
                    else if (!path.Contains(nextSpace) && movesRemaining > 0)
                    {
                        Solve(nextSpace, movesRemaining - 1);
                    }
                }

                if (!solved)
                    path.Remove(space);
            }
        }
        public void minSolve()
        {
            solved = false;
            int moves = 0;

            do
            {
                moves++;
                Console.WriteLine("Solving with {0} moves.", moves);
                Solve(StartSpace, moves);
            }
            while (!solved);

            Console.WriteLine("Moves: {0}", moves);
        }
        public void PrintPath()
        {
            for (int w = Width - 1; w >= 0; w--)
            {
                for (int i = 0; i <= Length - 1; i++)
                {
                    if (path.Find(s => s.X == i && s.Y == w) != null)
                    {
                        Console.Write("X ");
                    }
                    else
                    {
                        Console.Write("- ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
