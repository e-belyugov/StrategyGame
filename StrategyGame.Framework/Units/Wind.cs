using StrategyGame.Framework.Behaviour;
using StrategyGame.Framework.Common;
using StrategyGame.Framework.States;

namespace StrategyGame.Framework.Units
{
    // Юнит "Ветер"
    public class Wind : Unit, IOrientationState, ITurnClockwiseBehaviour
    {
        // Направление
        public Orientation UnitOrientation { get; private set; } = Orientation.North;

        // Конструктор
        public Wind(Field field) : base(field)
        {
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
