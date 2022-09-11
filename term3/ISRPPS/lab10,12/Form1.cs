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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int RX, RY;
        Graphics context;
        //bool check = false;
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Form form2;
            
            switch (e.Node.Tag)
            {
                case "1":
                    form2 = new Form2("Circle", true);
                    break;
                case "2":
                    form2 = new Form2("Circle", false);
                    break;
                case "3":
                    form2 = new Form2("Rect", true);
                    break;
                case "4":
                    form2 = new Form2("Rect", false);
                    break;
                default:
                    form2 = new Form2("Circle", false);
                    break;
            }
            form2.ShowDialog();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            //if(check)
            {
                context = Graphics.FromHwnd(panel1.Handle);
                RX = panel1.Size.Width;
                RY = panel1.Size.Height;
                PointF[] Arr = new PointF[]
                {
                    new PointF(150, 100),
                    new PointF(150, 50),
                    new PointF(200, 50),
                    new PointF(200, 100),
                };
                PointF[] Arr2 = new PointF[]
                {
                    new PointF(200, 100),
                    new PointF(250, 100),
                    new PointF(250, 150),
                    new PointF(200, 150),
                };
                PointF[] Arr3 = new PointF[]
                {
                    new PointF(150, 150),
                    new PointF(150, 200),
                    new PointF(200, 200),
                    new PointF(200, 150),
                };
                PointF[] Arr4 = new PointF[]
                {
                    new PointF(150, 100),
                    new PointF(100, 100),
                    new PointF(100, 150),
                    new PointF(150, 150),
                };

                context = Graphics.FromHwnd(panel1.Handle);
                Pen pen = new Pen(Color.Red, 10);
                SolidBrush кисть = new SolidBrush(Color.White);
                SolidBrush кисть1 = new SolidBrush(Color.Red);
                context.FillRectangle(кисть, 0, 0, RX, RY);
                context.FillEllipse(кисть1, 150, 100, 50, 50);
                context.DrawEllipse(pen, 150, 100, 50, 50);
                context.DrawBeziers(pen, Arr);
                context.DrawBeziers(pen, Arr2);
                context.DrawBeziers(pen, Arr3);
                context.DrawBeziers(pen, Arr4);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }

        private void Button1_Click_1(object sender, EventArgs e)
        {
            panel1.Visible = true;
        }
    }
}

