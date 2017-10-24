using System.Collections.Generic;
using NUnit.Framework;

namespace GameOfLife.UnitTests
{
    [TestFixture]
    public class GridUpdaterShould
    {
        private UnitTestExtensions _unitTestExtensions;

        [SetUp]
        public void SetUp()
        {
            _unitTestExtensions = new UnitTestExtensions();
        }

        [Test]
        public void UpdateGrid()
        {
            var gridUpdater = new GridUpdater();
            var seeds = new List<Cell>
            {
                new Cell() {PointX = 2, PointY = 2}
            };
            var grid = new Grid(seeds);
            var expectedGrid = new Grid(new List<Cell>());

            gridUpdater.Update(grid);

            _unitTestExtensions.AreInstacesEqual(expectedGrid, grid);
        }
    }
}
