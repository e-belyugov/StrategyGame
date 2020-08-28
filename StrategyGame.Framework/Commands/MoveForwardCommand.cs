using System.Collections.Generic;
using StrategyGame.Framework.Behaviour;
using StrategyGame.Framework.Units;

namespace StrategyGame.Framework.Commands
{
    // Команда "Движение вперед"
    public class MoveForwardCommand : ICommand
    {
        // Коллекция юнитов
        private IEnumerable<Unit> _units;

        // Конструктор с одним юнитом
        public MoveForwardCommand(Unit unit)
        {
            _units = new List<Unit>() {unit};
        }

        // Конструктор с коллекцией юнитов
        public MoveForwardCommand(IEnumerable<Unit> units)
        {
            _units = units;
        }

        // Движение вперед
        public void Execute()
        {
            foreach (var unit in _units)
            {
                var mover = unit as IMoveForwardBehaviour;
                mover?.MoveForward();
            }
        }
    }
}
