using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISRPPS_lab9
{
    class User
    {

        // Initializers
        public Calculator _calculator = new Calculator();
        private List<Command> _commands = new List<Command>();
        private int _current = 0;
        public void Redo(int levels)
        {
            if (_current < _commands.Count )
                _commands[_current++].Execute();
        }
        public void Undo(int levels)
        {
            if (_current > 0)
                _commands[--_current].UnExecute();
        }
        public void Compute(char @operator, int operand)
        {
            // Создаем команду операции и выполняем её
            Command command = new CalculatorCommand(
            _calculator, @operator, operand);
            command.Execute();
            // Добавляем операцию к списку отмены
            _commands.Add(command);
            _current++;
        }
    }
}
