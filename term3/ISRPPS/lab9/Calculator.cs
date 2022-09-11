using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISRPPS_lab9
{
    class Calculator
    {
        public int curr = 0;
        public void Operation(char @operator, int operand)
        {

            switch (@operator)
            {
                case '+':
                    curr += operand;
                    break;
                case '-':
                    curr -= operand;
                    break;
                case '*':
                    curr *= operand;
                    break;
                case '/':
                    curr /= operand;
                    break;
            }

            Form1.instance.textBox_1 = Convert.ToString(curr);
        }
    }
}

