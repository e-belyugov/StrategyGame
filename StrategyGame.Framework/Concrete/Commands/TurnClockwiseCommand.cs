using System.Collections.Generic;
using StrategyGame.Framework.Abstract.Base;
using StrategyGame.Framework.Abstract.Behaviour;

namespace StrategyGame.Framework.Concrete.Commands
{
    // Команда "Поворот"
    public class TurnClockwiseCommand
    {
        // Коллекция юнитов
        private IEnumerable<IUnit> _units;

        // Конструктор с одним юнитом
        public TurnClockwiseCommand(IUnit unit)
        {
            _units = new List<IUnit>() { unit };
        }

        // Конструктор с коллекцией юнитов
        public TurnClockwiseCommand(IEnumerable<IUnit> units)
        {
            _units = units;
        }

        // Поворот
        public void Execute()
        {
            foreach (var unit in _units)
            {
                var turner = unit as IClockwiseTurner;
                turner?.TurnClockwise();
            }
        }
    }
}
