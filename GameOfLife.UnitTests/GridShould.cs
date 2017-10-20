﻿using System.Collections.Generic;
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
            _grid.Initialise();
        }

        [Test]
        public void PopulateGridWithCells()
        {
            Assert.AreEqual(25, _grid.Cells.Count);
        }

        [Test]
        public void PopulateGridWithAllDeadCellsAndCoordinates()
        {
            var numberOfDeadCellsWithCoord = _grid.Cells.Count(x => x.PointX != -1 && x.PointY != -1 && x.IsAlive == false);
            Assert.AreEqual(25, numberOfDeadCellsWithCoord);
        }

        [Test]
        public void SetAliveCellAtSpecifiedCoordinate()
        {
            const int pointX = 1;
            const int pointY = 1;
            const bool alive = true;

            _grid.SetCellState(pointX, pointY, alive);
            var specifiedCell = _grid.Cells.First(x => x.PointX == pointX && x.PointY == pointY);

            Assert.AreEqual(alive, specifiedCell.IsAlive);
        }

        [Test]
        public void GetNeighbourForCornerCell()
        {
            const int pointX = 0;
            const int pointY = 0;

            var neighbourCells = new List<Cell>
            {
                new Cell() {PointX = 0, PointY = 1},
                new Cell() {PointX = 1, PointY = 0},
                new Cell() {PointX = 1, PointY = 1}
            };

            var actual = _grid.GetNeighbours(pointX, pointY);
            Assert.IsTrue(CheckListContainsSameCells(neighbourCells, actual));
        }

        [Test]
        public void GetNeighbourForNonCornerCell()
        {
            const int pointX = 1;
            const int pointY = 1;
            var neighbourCells = new List<Cell>
            {
                new Cell() {PointX = 0, PointY = 0},
                new Cell() {PointX = 0, PointY = 1},
                new Cell() {PointX = 0, PointY = 2},
                new Cell() {PointX = 1, PointY = 0},
                new Cell() {PointX = 1, PointY = 2},
                new Cell() {PointX = 2, PointY = 0},
                new Cell() {PointX = 2, PointY = 1},
                new Cell() {PointX = 2, PointY = 2},
            };

            var actual = _grid.GetNeighbours(pointX, pointY);
            Assert.IsTrue(CheckListContainsSameCells(neighbourCells, actual));
        }

        private bool CheckListContainsSameCells(List<Cell> listA, List<Cell> listB)
        {
            return listA.All(cell => listB.Count(c => c.PointX == cell.PointX && c.PointY == cell.PointY) != 0);
        }

    }
}
