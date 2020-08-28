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
        private Position _position = new Position(0, 0);

        // Направление
        public Orientation UnitOrientation { get; private set; } = Orientation.North;

        // Позиция
        public Position UnitPosition => _position;

        // Конструктор
        public Tractor(Field field) : base(field)
        {
        }

        // Движение вперед
        public void MoveForward()
        {
            switch (UnitOrientation)
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
            if (_position.X > UnitField.Width || _position.Y > UnitField.Height)
            {
                throw new TractorInDitchException();
            }
        }

        // Поворот
        public void TurnClockwise()
        {
            switch (UnitOrientation)
            {
                // Север
                case Orientation.North:
                    UnitOrientation = Orientation.East;
                    break;

                // Восток
                case Orientation.East:
                    UnitOrientation = Orientation.South;
                    break;

                // Юг
                case Orientation.South:
                    UnitOrientation = Orientation.West;
                    break;

                // Запад
                case Orientation.West:
                    UnitOrientation = Orientation.North;
                    break;
            }
        }
    }
}
