using System;
using System.Collections.Generic;
using System.Linq;

namespace GameOfLife
{
    public class Grid
    {
        private const int Width = 5;
        private const int Height = 5;

        public List<Cell> Cells { get; set; }

        public Grid()
        {
            Cells = new List<Cell>();
        }

        public void Initialise()
        {
            for (var x = 0; x < Height; x++)
            {
                for (var y = 0; y < Width; y++)
                {
                    var cell = new Cell
                    {
                        PointX = x,
                        PointY = y
                    };
                    Cells.Add(cell);
                }
            }                
        }

        public void SetCellState(int pointX, int pointY, bool isAlive)
        {
            var cell = Cells.First(x => x.PointX == pointX && x.PointY == pointY);
            cell.IsAlive = isAlive;
        }

        public List<Cell> GetNeighbours(int pointX, int pointY)
        {
            var neighbours = new List<Cell>();

            var minX = Math.Max(0, pointX - 1);
            var maxX = Math.Min(Width - 1, pointX + 1);
            var minY = Math.Max(0, pointY - 1);
            var maxY = Math.Min(Height - 1, pointY + 1);

            for (var x = minX; x <= maxX; x++)
            {
                for (var y = minY; y <= maxY; y++)
                {
                    if (x == pointX && y == pointY) continue;
                    neighbours.Add(GetCell(x, y));
                }
            }
            return neighbours;
        }

        public int CountLiveNeighbour(int pointX, int pointY)
        {
            return GetNeighbours(pointX, pointY).Count(cell => cell.IsAlive);
        }

        public Cell GetCell(int pointX, int pointY)
        {
            return Cells.First(cell => cell.PointX == pointX && cell.PointY == pointY);
        }
    }
}
