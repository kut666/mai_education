using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Курсовая_работа_по_ООП
{
    public class Form1Controller
    {
        private LaunchModel model;
        private Form1 view;

        public Form1Controller(Form1 view, LaunchModel model)
        {
            this.model = model;
            this.view = view;
        }

        public void PassData(int n1, int n2, int i, int l1, int l2)
        {
            model.Tournament_Selection(n1, n2, i, l1, l2);
        }
    }
}
