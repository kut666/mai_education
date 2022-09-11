using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISRPPS_lab9
{
    class CalculatorCommand : Command
    {
        char @operator;
        int operand;
        Calculator calculator;
        // Constructor
        public CalculatorCommand(Calculator calculator,
        char @operator, int operand)
        {
            this.calculator = calculator;
            this.@operator = @operator;
            this.operand = operand;
        }
        public char Operator
        {
            set
            {
                @operator = value;
            }
        }
        public int Operand
        {
            set
            {
                operand = value;
            }
        }
        public override void Execute()
        {
            calculator.Operation(@operator, operand);
        }
        public override void UnExecute()
        {
            calculator.Operation(Undo(@operator), operand);
        }
        // Private helper function : приватные вспомогательные функции
        private char Undo(char @operator)
        {
            char undo;
            switch (@operator)
            {

                case '+':
                    undo = '-';
                    break;
                case '-':
                    undo = '+';
                    break;
                case '*':
                    undo = '/';
                    break;
                case '/':
                    undo = '*';
                    break;
                default:
                    undo = ' ';
                    break;
            }
            return undo;
        }
    }
}
