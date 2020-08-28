using StrategyGame.Framework.Behaviour;
using StrategyGame.Framework.Common;
using StrategyGame.Framework.States;
using StrategyGame.Framework.Units;

namespace Sbt.Test.Refactoring
{
    // Юнит "Трактор"
    public class Tractor : Unit, IPositionState, IOrientationState, IMoveForwardBehaviour, ITurnClockwiseBehaviour
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
            switch (_orientation)
            {
                // Север
                case Orientation.North:
                    _position.Y++;
                    break;

                // Восток
                case Orientation.East:
                    _position.X++;
                    break;

                // Юг
                case Orientation.South:
                    _position.Y--;
                    break;

                // Запад
                case Orientation.West:
                    _position.X--;
                    break;
            }

            // Падение в ров
            if (_position.X > _field[0] || _position.Y > _field[1])
            {
                throw new TractorInDitchException();
            }
        }

        // Поворот
        public void TurnClockwise()
        {
            switch (_orientation)
            {
                // Север
                case Orientation.North:
                    _orientation = Orientation.East;
                    break;

                // Восток
                case Orientation.East:
                    _orientation = Orientation.South;
                    break;

                // Юг
                case Orientation.South:
                    _orientation = Orientation.West;
                    break;

                // Запад
                case Orientation.West:
                    _orientation = Orientation.North;
                    break;
            }
        }
    }
}
