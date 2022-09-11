﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISRPPS_Lab_6
{
    public class Controller
    {
       private LaunchModel model;
        private LaunchView view;
        public Controller(LaunchView view, LaunchModel model)
        {
            this.model = model;
            this.view = view;
        }
        public void SetIntervals(double start, double rise, double flight)
        {
            if (model.SwitchedOn) throw new Exception("Невозможно изменить интервалы в работающей ракете!");
            Intervals i = new Intervals(start, rise, flight);
            model.SetIntervals(i);
        }
        public void SwithOn()
        {
            if (model.IntervalsEmpty) throw new Exception("Не заданы интервалы для ракеты!");
            model.SwitchedOn = true;
        }
        public void SwitchOff()
        {
            model.SwitchedOn = false;
        }
    }
}
