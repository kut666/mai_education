using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISRPPS_Lab_6
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
        public void SetIntervals(double start, double rise, double flight)
        {
            if (model.SwitchedOn) throw new Exception("Невозможно изменить интервал в запущенной ракете!");
            Intervals i = new Intervals(start, rise, flight);
            model.SetIntervals(i);
        }
        public void SwithOn()
        {
            if (model.IntervalsEmpty) throw new Exception("Не заданы интервалы запуска!");
            model.SwitchedOn = true;
        }
        public void SwitchOff()
        {
            model.SwitchedOn = false;
        }
    }
}
