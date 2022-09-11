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
    public partial class Form1 : Form, IObserver

    {
        public string Pl = "D:\\Sprite\\", exp = ".png";
        public Form1()
        {
            InitializeComponent();

        }

        private Form1Controller controller;
        private LaunchModel model;
        //Timer t = new Timer();
        public int k;
        public Form1(LaunchModel model)
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
            textBox3.BackColor = Color.Red;
            textBox1.BackColor = Color.Red;
            textBox2.BackColor = Color.Red;
            if (model.SwitchedOn)

                //  Получение информации от о состоянии модели от самой модели
                switch (model.State)
                {
                    case LaunchState.Start:
                        textBox3.BackColor = Color.Green;
                        break;
                    case LaunchState.Rise:
                        textBox1.BackColor = Color.Green;
                        break;
                    case LaunchState.Flight:
                        textBox2.BackColor = Color.Green;
                        break;
                }
            else
                if (model.SwitchedOn != true)
            {

                textBox3.BackColor = Color.Red;
                textBox1.BackColor = Color.Red;
                textBox2.BackColor = Color.Red;
            }
        }

        //          Подключение контроллера к виду

        //  Этот метод связывает данный контроллер с видом

        public void AttachController(Form1Controller controller)
        {
            this.controller = controller;
        }

        protected Form1Controller MakeController()
        {
            //          Передача контроллеру ссылок на вид и модель

            return new Form1Controller(this, model);
        }
        private void ControlLaunch_Load(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            double start = 0, rise = 0, flight = 0;
            try
            {
                start = double.Parse(textBox4.Text) * 1000;
                rise = double.Parse(textBox5.Text) * 1000;
                flight = double.Parse(textBox6.Text) * 1000;
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

        private void button3_Click(object sender, EventArgs e)
        {
            controller.SwitchOff();
        }
        /*
        private void t_Tick(object sendet, EventArgs e)
        {
           
            string pls = this.Pl + this.k.ToString() + exp;
            pictureBox1.Image = Image.FromFile(pls);
            this.k++;
            if (this.k >= 3)
                this.k = 0;
        }
    */
    }
}
