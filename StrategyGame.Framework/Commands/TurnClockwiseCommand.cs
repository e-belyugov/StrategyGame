using System.Collections.Generic;
using StrategyGame.Framework.Behaviour;
using StrategyGame.Framework.Units;

namespace StrategyGame.Framework.Commands
{
    // Команда "Поворот"
    public class TurnClockwiseCommand
    {
        // Коллекция юнитов
        private IEnumerable<Unit> _units;

        // Конструктор с одним юнитом
        public TurnClockwiseCommand(Unit unit)
        {
            _units = new List<Unit>() { unit };
        }

        // Конструктор с коллекцией юнитов
        public TurnClockwiseCommand(IEnumerable<Unit> units)
        {
            _units = units;
        }

        // Поворот
        public void Execute()
        {
            foreach (var unit in _units)
            {
                var turner = unit as ITurnClockwiseBehaviour;
                turner?.TurnClockwise();
            }
        }
    }
}
