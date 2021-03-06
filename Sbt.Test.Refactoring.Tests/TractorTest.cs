﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using StrategyGame.Framework.Commands;
using StrategyGame.Framework.Common;

namespace Sbt.Test.Refactoring.Tests
{
    [TestClass]
    public class TractorTest
    {
        [TestMethod]
        public void TestShouldMoveForward()
        {
            Tractor tractor = new Tractor(new Field() {Height = 5, Width = 5});
            var moveCommand = new MoveForwardCommand(tractor);
            
            moveCommand.Execute();

            Assert.AreEqual(0, tractor.UnitPosition.X);
            Assert.AreEqual(1, tractor.UnitPosition.Y);
        }

        [TestMethod]
        public void TestShouldTurn()
        {
            Tractor tractor = new Tractor(new Field() { Height = 5, Width = 5 });
            var turnCommand = new TurnClockwiseCommand(tractor);

            turnCommand.Execute();
            Assert.AreEqual(Orientation.East, tractor.UnitOrientation);

            turnCommand.Execute();
            Assert.AreEqual(Orientation.South, tractor.UnitOrientation);

            turnCommand.Execute();
            Assert.AreEqual(Orientation.West, tractor.UnitOrientation);

            turnCommand.Execute();
            Assert.AreEqual(Orientation.North, tractor.UnitOrientation);
        }

        [TestMethod]
        public void TestShouldTurnAndMoveInTheRightDirection()
        {
            Tractor tractor = new Tractor(new Field() { Height = 5, Width = 5 });
            var moveCommand = new MoveForwardCommand(tractor);
            var turnCommand = new TurnClockwiseCommand(tractor);

            turnCommand.Execute();
            moveCommand.Execute();
            Assert.AreEqual(1, tractor.UnitPosition.X);
            Assert.AreEqual(0, tractor.UnitPosition.Y);

            turnCommand.Execute();
            moveCommand.Execute();
            Assert.AreEqual(1, tractor.UnitPosition.X);
            Assert.AreEqual(-1, tractor.UnitPosition.Y);

            turnCommand.Execute();
            moveCommand.Execute();
            Assert.AreEqual(0, tractor.UnitPosition.X);
            Assert.AreEqual(-1, tractor.UnitPosition.Y);

            turnCommand.Execute();
            moveCommand.Execute();
            Assert.AreEqual(0, tractor.UnitPosition.X);
            Assert.AreEqual(0, tractor.UnitPosition.Y);
        }

        [TestMethod]
        public void TestShouldThrowExceptionIfFallsOffPlateau()
        {
            Tractor tractor = new Tractor(new Field() { Height = 5, Width = 5 });
            var moveCommand = new MoveForwardCommand(tractor);

            moveCommand.Execute();
            moveCommand.Execute();
            moveCommand.Execute();
            moveCommand.Execute();
            moveCommand.Execute();

            try
            {
                moveCommand.Execute();
                Assert.Fail("Tractor was expected to fall off the plateau");
            }
            catch (TractorInDitchException)
            {
            }
        }
    }
}
