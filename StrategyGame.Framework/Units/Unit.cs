using StrategyGame.Framework.Common;

namespace StrategyGame.Framework.Units
{
    // Базовый класс для юнитов
    public class Unit
    {
        // Поле
        public Field UnitField { get; }

        // Конструктор
        public Unit(Field field)
        {
            UnitField = field;
        }
    }
}
