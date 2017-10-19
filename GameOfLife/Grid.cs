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
            Cells = Enumerable.Repeat(new Cell(), Width * Height).ToList();
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
    }
}
