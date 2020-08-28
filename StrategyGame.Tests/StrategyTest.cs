using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sbt.Test.Refactoring;
using StrategyGame.Framework.Commands;
using StrategyGame.Framework.Common;
using StrategyGame.Framework.Units;

namespace StrategyGame.Tests
{
    // Тесты для стратегии
    [TestClass]
    public class StrategyTest
    {
        // Внутренние переменные
        private Field _field;
        private Tractor _tractor;
        private Stone _stone;
        private Wind _wind;
        private IEnumerable<Unit> _units;
        private MoveForwardCommand _moveCommand;
        private TurnClockwiseCommand _turnCommand;

        // Инициализация объектов для тестирования
        [TestInitialize]
        public void TestInitialize()
        {
            _field = new Field(5, 5);
            _tractor = new Tractor(_field);
            _stone = new Stone(_field);
            _wind = new Wind(_field);
            _units = new List<Unit> { _tractor, _stone, _wind };
            _moveCommand = new MoveForwardCommand(_units);
            _turnCommand = new TurnClockwiseCommand(_units);
        }

        // Двигаем разнородные юниты
        [TestMethod]
        public void TestMoveDifferentUnits()
        {
            // Движение
            _moveCommand.Execute();
            _moveCommand.Execute();
            _moveCommand.Execute();

            // Трактор продвинулся
            Assert.AreEqual(0, _tractor.UnitPosition.X);
            Assert.AreEqual(3, _tractor.UnitPosition.Y);

            // Камень стоит на месте
            Assert.AreEqual(0, _stone.UnitPosition.X);
            Assert.AreEqual(0, _stone.UnitPosition.Y);

            // Ветер не поменял направление (положения нет)
            Assert.AreEqual(Orientation.North, _wind.UnitOrientation);
        }

        // Поворачиваем разнородные юниты
        [TestMethod]
        public void TestTurnDifferentUnits()
        {
            // Поворот
            _turnCommand.Execute();
            _turnCommand.Execute();
            _turnCommand.Execute();

            // Трактор повернулся
            Assert.AreEqual(Orientation.West, _tractor.UnitOrientation);

            // Камень стоит на месте (направления нет)
            Assert.AreEqual(0, _stone.UnitPosition.X);
            Assert.AreEqual(0, _stone.UnitPosition.Y);

            // Ветер поменял направление
            Assert.AreEqual(Orientation.West, _wind.UnitOrientation);
        }

        // Двигаем и поворачиваем разнородные юниты
        [TestMethod]
        public void TestMoveAndTurnDifferentUnits()
        {
            // Поворот
            _moveCommand.Execute();
            _turnCommand.Execute();

            // Трактор продвинулся и повернулся
            Assert.AreEqual(0, _tractor.UnitPosition.X);
            Assert.AreEqual(1, _tractor.UnitPosition.Y);
            Assert.AreEqual(Orientation.East, _tractor.UnitOrientation);

            // Камень стоит на месте
            Assert.AreEqual(0, _stone.UnitPosition.X);
            Assert.AreEqual(0, _stone.UnitPosition.Y);

            // Ветер поменял направление
            Assert.AreEqual(Orientation.East, _wind.UnitOrientation);
        }
    }
}
