using System.Collections.Generic;
using StrategyGame.Framework.Abstract.Base;
using StrategyGame.Framework.Abstract.Behaviour;

namespace StrategyGame.Framework.Concrete.Commands
{
    // Команда "Движение вперед"
    public class MoveForwardCommand : ICommand
    {
        // Коллекция юнитов
        private IEnumerable<IUnit> _units;

        // Конструктор с одним юнитом
        public MoveForwardCommand(IUnit unit)
        {
            _units = new List<IUnit>() {unit};
        }

        // Конструктор с коллекцией юнитов
        public MoveForwardCommand(IEnumerable<IUnit> units)
        {
            _units = units;
        }

        // Движение вперед
        public void Execute()
        {
            foreach (var unit in _units)
            {
                var mover = unit as IForwardMover;
                mover?.MoveForward();
            }
        }
    }
}
