using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Collections;

namespace ISRPPS_Lab_6
{
    public enum LaunchState
    {
        Start = 0,
        Rise = 1,
        Flight = 2
    }

    public struct Intervals
    {
        double start;
        double rise;
        double flight;
        public Intervals(double start, double rise, double flight)
        {
            this.start = start;
            this.rise = rise;
            this.flight = flight;
        }
        public double Start { get { return start; } }
        public double Rise { get { return rise; } }
        public double Flight { get { return flight; } }
        public bool AreEmpty { get { return start == 0 || rise == 0 || flight == 0; } }
    }

    public class LaunchModel
    {
        private LaunchState state;
        private bool switchedOn;
        private Timer timer;
        private Intervals intervals;

        public LaunchModel()
        {
            state = LaunchState.Start;
            switchedOn = false;
            timer = new Timer();
            timer.AutoReset = false;
            timer.Enabled = false;
            timer.Elapsed += new ElapsedEventHandler(timer_Elapsed);
        }

        public bool SwitchedOn
        {
            get { return switchedOn || state != LaunchState.Start; }
            set
            {
                switchedOn = value;
                if (value)
                {
                    timer.Interval = intervals.Start;
                    timer.Enabled = true;
                    UpdateObservers();
                }
                else
                    if(!value)
                {
                    timer.Enabled = false;

                }
            }
        }

        public LaunchState State { get { return state; } }

        public bool IntervalsEmpty { get { return intervals.AreEmpty; } }



        public void SetIntervals(Intervals intervals)
        {
            this.intervals = intervals;
        }


        void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            state = (LaunchState)(((int)state + 1) % 3);
            switch (state)
            {
                case LaunchState.Start:
                    timer.Interval = intervals.Start;
                    break;
                case LaunchState.Rise:
                    timer.Interval = intervals.Rise;
                    break;
                case LaunchState.Flight:
                    timer.Interval = intervals.Flight;
                    break;

            }
            if (state == LaunchState.Start && !switchedOn) // была получена команда выключения таймера
            {
                timer.Enabled = false;
            }
            //  При изменении состояния модели, она просмотрит список зарегистрированных
            //  объектов (их часто еще называют слушателями, приемниками, приемниками информации (listener),
            //  обработчиками, наблюдателями, а также блоками наблюдения (observer)), и проинформирует
            //  каждый объект об изменении состояния.

            UpdateObservers();
        }
       

        //        MVC
        //      Список наблюдателей 
        private ArrayList listeners = new ArrayList();

        // Наблюдаемый (модель) должен иметь методы, с помощью которых наблюдатели (view) могут за-
        //  регистрировать свою заинтересованность в модели и отменить ее

        public void Register(IObserver o)
        {
            listeners.Add(o);
            o.UpdateState();
        }

        public void Deregister(IObserver o)
        {
            listeners.Remove(o);
        }

        //  метод для обновления всех видов

        // Для создания службы уведомления модель, как
        //  правило, задействует шаблон Observer (наблюдатель, блок наблюдения).
        public void UpdateObservers()
        {
            foreach (IObserver ob in listeners)
            {
                ob.UpdateState();
            }
        }
    }
}
