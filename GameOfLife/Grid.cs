using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;

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
            List<Cell> neighbours = new List<Cell>();
            neighbours.Add(new Cell {PointX = pointX + 1, PointY = pointY + 1});
            neighbours.Add(new Cell {PointX = pointX + 1, PointY = pointY});
            neighbours.Add(new Cell {PointX = pointX, PointY = pointY + 1});
            return neighbours;
        }
    }
}
