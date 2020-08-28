using StrategyGame.Framework.Common;

namespace StrategyGame.Framework.States
{
    // Интерфейс состояния "Позиция"
    public interface IPositionState
    {
        // Позиция
        Position UnitPosition { get; }
    }
}
