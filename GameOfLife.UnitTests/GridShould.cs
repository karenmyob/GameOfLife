using System.Linq;
using NUnit.Framework;

namespace GameOfLife.UnitTests
{
    [TestFixture]
    public class GridShould
    {
        private Grid _grid;

        [SetUp]
        public void SetUp()
        {
            _grid = new Grid();
        }

        [Test]
        public void PopulateGridWithCells()
        {
            Assert.AreEqual(25, _grid.Cells.Count);
        }

        [Test]
        public void PopulateGridWithAllDeadCellsAndCoordinates()
        {
            _grid.Initialise();
            var numberOfDeadCellsWithCoord = _grid.Cells.Count(x => x.PointX != -1 && x.PointY != -1 && x.IsAlive == false);
            Assert.AreEqual(25, numberOfDeadCellsWithCoord);
        }

        [Test]
        public void SetAliveCellAtSpecifiedCoordinate()
        {
            _grid.Initialise();
            const int pointX = 1;
            const int pointY = 1;
            const bool alive = true;

            _grid.SetCellState(pointX, pointY, alive);
            var specifiedCell = _grid.Cells.First(x => x.PointX == pointX && x.PointY == pointY);

            Assert.AreEqual(alive, specifiedCell.IsAlive);
        }
    }
}
