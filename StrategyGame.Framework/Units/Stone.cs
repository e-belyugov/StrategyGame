using StrategyGame.Framework.Common;
using StrategyGame.Framework.States;

namespace StrategyGame.Framework.Units
{
    // Юнит "Камень"
    public class Stone : Unit, IPositionState
    {
        // Позиция
        public Position UnitPosition { get; } = new Position(0, 0);

        // Конструктор
        public Stone(Field field) : base(field)
        {
        }
    }
}
