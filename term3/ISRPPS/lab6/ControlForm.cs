using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ISRPPS_Lab_6
{
    public partial class ControlForm : Form, IObserver
    {
        public ControlForm()
        {
            InitializeComponent();
        }
        private ControlFormController controller;
        private LaunchModel model;
        private bool flag = false;

        private int timeElapsed;

        public ControlForm(LaunchModel model)
        {
            InitializeComponent();
            this.model = model;
            //  наблюдатели (view) регистрируют свою заинтересованность в модели
            this.model.Register(this);
            attachController(makeController());
        }

        private void drawLight(Brush a)
        {
            Bitmap bmp = new Bitmap(106, 106);
            Graphics g = Graphics.FromImage(bmp);
            g.FillEllipse(a, new Rectangle(3, 3, 100, 100));
            pictureBox1.Image = bmp;
        }

        public void UpdateState
            ()
        {
            switch (model.State)
            {
                case LaunchState.Start: drawLight(Brushes.Green); break;
                case LaunchState.Rise: drawLight(Brushes.Green); break;
                case LaunchState.Flight: drawLight(Brushes.Green); break;
                default: drawLight(Brushes.Red); break;
            }
            if (flag)
            {
                timeElapsed = 0;
                timer1.Start();
                toolStripLabel2.Text = "Работает";

                timer1.Interval = 1000;

            }
            else
            {
                timeElapsed = 0;
                timer1.Stop();

                toolStripLabel2.Text = "Выключен";
            }
        }
        public void attachController(ControlFormController controller) // контроллер
        {
            this.controller = controller;
        }
        protected ControlFormController makeController()
        {
            return new ControlFormController(this, model);
        }


        private void timer1_Tick(object sender, EventArgs e)
        {

            timeElapsed += 1000;
            DateTime dt = DateTime.Now;
            textBox4.Text = dt.Hour + ":" + dt.Minute + ":" + dt.Second;          //String.Format("{0}",timeElapsed/1000);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            double start = 0, rise = 0, flight = 0;
            try
            {
                start = double.Parse(textBox1.Text) * 1000;
                rise = double.Parse(textBox2.Text) * 1000;
                flight = double.Parse(textBox3.Text) * 1000;
            }
            catch { MessageBox.Show("Задайте корректные интервалы!"); }
            try
            {
                controller.SetIntervals(start, rise, flight);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            flag = true;
            try
            {
                controller.SwithOn();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }

        private void Button3_Click_1(object sender, EventArgs e)
        {
            flag = false;

            controller.SwitchOff();
        }

        
    }
}
