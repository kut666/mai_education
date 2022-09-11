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
    public partial class LaunchView : Form,IObserver
    {
        private Controller controller;
        private LaunchModel model;
        public LaunchView(LaunchModel model)
        {
            InitializeComponent();
            this.model = model;
            //  наблюдатели (view) регистрируют свою заинтересованность в модели
            this.model.Register(this);
            AttachController(MakeController());


        }
        //    Обновление вида
        //    Все наблюдатели (view), которые хотят зарегистрироваться у наблюдаемого объекта,
        //    должны реализовать интерфейс Observer

        public void UpdateState()
        {
            panel1.BackColor = Color.Red;
            panel2.BackColor = Color.Red;
            panel3.BackColor = Color.Red;
            if (model.SwitchedOn)

                //  Получение информации от о состоянии модели от самой модели
                switch (model.State)
                {
                    case LaunchState.Start:
                        panel1.BackColor = Color.Green;
                        break;
                    case LaunchState.Rise:
                        panel2.BackColor = Color.Green;
                        break;
                    case LaunchState.Flight:
                        panel3.BackColor = Color.Green;
                        break;
                }
        }

        //          Подключение контроллера к виду

        //  Этот метод связывает данный контроллер с видом

        public void AttachController(Controller controller)
        {
            this.controller = controller;
        }

        protected Controller MakeController()
        {
            //          Передача контроллеру ссылок на вид и модель

            return new Controller(this, model);
        }
        private void LaunchView_Load(object sender, EventArgs e)
        {

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
            try
            {
                controller.SwithOn();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            controller.SwitchOff();
        }
    }
}
