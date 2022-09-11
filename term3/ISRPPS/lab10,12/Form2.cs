using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ISRPPS_Lab10
{
    public partial class Form2 : Form
    {
        private int RX, RY;
        private Graphics context;
        private String figure;
        private bool isFilled;
        Random rnd = new Random();
        public Form2(String figure, bool isFilled)
        //public PicForm()
        {
            InitializeComponent();
            this.figure = figure;
            this.isFilled = isFilled;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            switch (this.figure)
            {
                case "Rect":
                    if (this.isFilled)
                    {
                        context = Graphics.FromHwnd(this.Handle);
                        RX = this.ClientSize.Width;
                        RY = this.ClientSize.Height;
                        Class1.Filledrect(context, RX, RY, Color.FromArgb(rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255)), Color.FromArgb(rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255)));
                    }
                    else
                    {
                        context = Graphics.FromHwnd(this.Handle);
                        RX = this.ClientSize.Width;
                        RY = this.ClientSize.Height;
                        Class1.Rect(context, RX, RY, Color.FromArgb(rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255)), Color.FromArgb(rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255)));
                    }
                    break;
                case "Circle":
                    if (this.isFilled)
                    {
                        context = Graphics.FromHwnd(this.Handle);
                        RX = this.ClientSize.Width;
                        RY = this.ClientSize.Height;
                        Class1.FilledCircle(context, RX, RY, Color.FromArgb(rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255)), Color.FromArgb(rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255)));
                    }
                    else
                    {
                        context = Graphics.FromHwnd(this.Handle);
                        RX = this.ClientSize.Width;
                        RY = this.ClientSize.Height;
                        Class1.Circle(context, RX, RY, Color.FromArgb(rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255)), Color.FromArgb(rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255)));
                    }
                    break;
            }
        }
    }
}
