using StrategyGame.Framework.Common;

namespace StrategyGame.Framework.States
{
    // Интерфейс состояния "Направление"
    public interface IOrientationState
    {
        Orientation UnitOrientation { get; }
    }
}
