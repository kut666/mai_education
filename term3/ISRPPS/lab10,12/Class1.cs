using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ISRPPS_Lab10
{
    class Class1
    {
        public static void Cross(Graphics g, int RX, int RY, Color Background, Color Line)
        {
            SolidBrush кисть = new SolidBrush(Background);
            Pen pen = new Pen(Line);
            g.FillRectangle(кисть, 0, 0, RX, RY);
            g.DrawLine(pen, RX / 2, RY, RX / 2, 0);
            g.DrawLine(pen, 0, RY / 2, RX, RY / 2);
        }
        public static void Recross(Graphics g, int RX, int RY, Color Background, Color Line)
        {
            SolidBrush кисть = new SolidBrush(Background);
            Pen pen = new Pen(Line);
            g.FillRectangle(кисть, 0, 0, RX, RY);
            g.DrawLine(pen, 0, 0, RX, RY);
            g.DrawLine(pen, 0, RY, RX, 0);
        }
        public static void Circle(Graphics g, int RX, int RY, Color Background, Color Line)
        {
            SolidBrush кисть = new SolidBrush(Background);
            Pen pen = new Pen(Line);
            g.FillRectangle(кисть, 0, 0, RX, RY);
            g.DrawLine(pen, 3 * RX / 8, 5 * RY / 8 - 50, 5 * RX / 8, 5 * RY / 8 - 50);
            g.DrawLine(pen, 5 * RX / 8, 5 * RY / 8 - 50, 4 * RX / 8,  2 * RY / 8 - 50);
            g.DrawLine(pen, 4 * RX / 8, 2* RY / 8 - 50, 3 * RX / 8, 5 * RY / 8 - 50);
        }
        public static void FilledCircle(Graphics g, int RX, int RY, Color Background, Color Line)
        {
            SolidBrush кисть = new SolidBrush(Background);
            SolidBrush pen = new SolidBrush(Color.FromArgb(255, 0, 0));
            g.FillRectangle(кисть, 0, 0, RX, RY);
            
            Point points1 = new Point(3 * RX / 8, 5 * RY / 8 - 50);
            Point points2 = new Point(5 * RX / 8, 5 * RY / 8 - 50);
            Point points3 = new Point(4 * RX / 8, 2 * RY / 8 - 50);
            Point[] curvePoints = { points1, points2, points3 };
            g.FillPolygon(pen,curvePoints);
        }
        public static void Rect(Graphics g, int RX, int RY, Color Background, Color Line)
        {
            SolidBrush кисть = new SolidBrush(Background);
            Pen pen = new Pen(Color.FromArgb(255, 0, 0));
            g.FillRectangle(кисть, 0, 0, RX, RY);
            g.DrawRectangle(pen, 3 * RX / 8, 3 * RY / 8 - 50, RX / 4, RX / 4);
        }
        public static void Filledrect(Graphics g, int RX, int RY, Color Background, Color Line)
        {
            SolidBrush кисть = new SolidBrush(Background);
            SolidBrush pen = new SolidBrush(Color.FromArgb(255, 0, 0));
            g.FillRectangle(кисть, 0, 0, RX, RY);
            g.FillRectangle(pen, 3 * RX / 8, 3 * RY / 8 - 50, RX / 4, RX / 4);
        }
    }
}

