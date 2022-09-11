using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Timers;
using System.Threading;

namespace Курсовая_работа_по_ООП
{
    public class LaunchModel
    {
        private bool per;
        private int i;
        private int l1;
        private int l2;

        public bool Per
        {
            get { return per; }
        }

        public int I
        {
            get { return i; }
        }

        public int L1
        {
            get { return l1; }
        }

        public int L2
        {
            get { return l2; }
        }

        public void Tournament_Selection(int n1, int n2, int i, int l1, int l2)
        {
            if (n1 > n2)
            {
                per = true;
                this.i = i;
                this.l1 = l1;
            }
            else
            {
                per = false;
                this.i = i;
                this.l2 = l2;
            }
            UpdateObservers();
        }

        private ArrayList listeners = new ArrayList();

        public void Register(IObserver o)
        {
            listeners.Add(o);
        }

        public void Deregister(IObserver o)
        {
            listeners.Remove(o);
        }

        public void UpdateObservers()
        {
            foreach (IObserver ob in listeners)
            {
                ob.UpdateState();
            }
        }
    }
}
