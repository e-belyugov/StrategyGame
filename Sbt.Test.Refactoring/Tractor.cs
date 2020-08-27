using StrategyGame.Framework.Abstract.Base;
using StrategyGame.Framework.Abstract.Behaviour;
using StrategyGame.Framework.Abstract.State;

namespace Sbt.Test.Refactoring
{
    // Юнит "Трактор"
    public class Tractor : IUnit, IPositionState, IOrientationState, IForwardMover, IClockwiseTurner
    {
        // Внутренние переменные
        private readonly int[] _field = new int[] { 5, 5 };
        private Orientation _orientation = Orientation.North;
        private Position _position = new Position(0, 0);

        // Направление
        public Orientation UnitOrientation => _orientation;

        // Позиция
        public Position UnitPosition => _position;

        // Движение вперед
        public void MoveForward()
        {
            var x = _position.X;
            int y = _position.Y;

            switch (_orientation)
            {
                // Север
                case Orientation.North:
                    y++;
                    break;

                // Восток
                case Orientation.East:
                    x++;
                    break;

                // Юг
                case Orientation.South:
                    y--;
                    break;

                // Запад
                case Orientation.West:
                    x--;
                    break;
            }

            // Переход на новую позицию
            if (x != _position.X || y != _position.Y) _position = new Position(x, y);

            // Падение в ров
            if (x > _field[0] || y > _field[1])
            {
                throw new TractorInDitchException();
            }
        }

        // Поворот
        public void TurnClockwise()
        {
            var orientation = _orientation;

            switch (orientation)
            {
                // Север
                case Orientation.North:
                    orientation = Orientation.East;
                    break;

                // Восток
                case Orientation.East:
                    orientation = Orientation.South;
                    break;

                // Юг
                case Orientation.South:
                    orientation = Orientation.West;
                    break;

                // Запад
                case Orientation.West:
                    orientation = Orientation.North;
                    break;
            }

            // Поворот в новом направлении
            _orientation = orientation;
        }
    }
}
