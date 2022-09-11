// Махмудов Орхан М80-305Б-18

using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace CG_Lab_3
{
    /// <summary>Логика взаимодействия для MainWindow.xaml</summary>
    public partial class MainWindow : Window
    {
        private int angle_number=3;       // кол-во углов пирамиды
        private int level_number = 1;   // общее кол-во пирамид
        private double r = 1;           // радиус цилиндра
        private double Approx = 0.6;    // Число аппорксимации, r/R
        private double Height = 1;      // Высота цилиндра
        private double tmpApprox;
        private double r_a = 1;
        private double r_b = 1;

        /// <summary> массив вершин нижнего основания</summary>
        private Point3D[] bottom_points;
        /// <summary> массив вершин верхнего основания</summary>
        private Point3D[] top_points;

        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary> Основная функция, осуществляющая аппроксимацию </summary>
        public void Approximate()
        {
            bottom_points = new Point3D[angle_number];
            top_points = new Point3D[angle_number];
            group.Children.Clear();

            SolidColorBrush brush = new SolidColorBrush(Color.FromRgb(120, 30, 60));
            DiffuseMaterial material = new DiffuseMaterial(brush);

            CountBottomPoints();
            GeometryModel3D geonetry_model_3d = new GeometryModel3D();
            geonetry_model_3d.Material = material;
                
            CountTopPoints(level_number);

            // Создание и отрисовка одной пирамиды
            TruncatedPyramid pyramid = new TruncatedPyramid(bottom_points, top_points);
            pyramid.Draw(geonetry_model_3d);

            group.Children.Add(geonetry_model_3d); // присоединение пирамиды к многограннику
                
            for (int i = 0; i < angle_number; i++) bottom_points[i] = top_points[i];
        }

        /// <summary>Просчитывание координат точек нижнего основания </summary>
        private void CountBottomPoints()
        {
            double step = Math.PI / (angle_number + 1); // точно
            double alpha = Math.PI ; // начало, пофиг
            for (int i = 0; i < angle_number; i++)
            {
                double x = r*r_a * Math.Cos(alpha);
                double y = r*r_b * Math.Sin(alpha);
                bottom_points[i] = new Point3D(x, y, 0);
                alpha += step;
            }
        }
 
        /// <summary>Просчитывание координат точек верхнего основания</summary>
        private void CountTopPoints(int current_level)
        {
            double alpha = Math.PI / (4 * level_number + 1);
            for (int i = 0; i < angle_number; i++)
            {
                Point3D A = bottom_points[i];

                double z = Height *r  * Math.Sin((current_level + 1) * alpha);
                double x = A.X;
                double y = A.Y;

                top_points[i] = new Point3D(x, y, z);
            }
        }

        /// <summary>считывание параметров</summary>
        private void ReadParams()
        {
            try 
            {
                if (Slider_Height != null && TextBlock_Height != null)
                {
                    Height = Math.Round(Convert.ToDouble(Slider_Height.Value), 3);
                    TextBlock_Height.Text = Convert.ToString(Height);
                }
            }
            catch { }
            try 
            {
                Approx = Convert.ToDouble(slider_Approx.Value);
                tmpApprox = Approx;
                angle_number = Convert.ToInt32(Math.PI / Math.Acos(Approx));
                if (angle_number < 3)
                    angle_number = 3;
                if (textBlock_Approx != null)
                    textBlock_Approx.Text = Convert.ToString(Approx);
            }
            catch { }

            try
            {
                if (Slider_Radius != null && TextBlock_Radius != null)
                {
                    r = Math.Round(Convert.ToDouble(Slider_Radius.Value), 3);
                    TextBlock_Radius.Text = Convert.ToString(r);
                }
            }
            catch { }

            try
            {
                if (slider_a != null && TextBlock_a!= null)
                {
                    r_a = Math.Round(Convert.ToDouble(slider_a.Value), 3);
                    TextBlock_a.Text = Convert.ToString(r_a);
                }
            }
            catch { }

            try
            {
                if (slider_b != null && TextBlock_b != null)
                {
                    r_b = Math.Round(Convert.ToDouble(slider_b.Value), 3);
                    TextBlock_b.Text = Convert.ToString(r_b);
                }
            }
            catch { }
        }

        /// <summary>
        /// В случае изменения числа аппроксимации перерисовать фигуру с новыми параметрами
        /// </summary>
        private void slider_Approx_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            ReadParams();
            Approximate();
        }

        /// <summary>
        /// В случае изменения радиуса перерисовать фигуру с новыми параметрами
        /// </summary>
        private void Slider_Radius_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            ReadParams();
            Approximate();
        }

        /// <summary>
        /// В случае изменения высоты перерисовать фигуру с новыми параметрами
        /// </summary>
        private void Slider_Height_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            ReadParams();
            Approximate();
        }

        private void slider_x_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            // try
            // {
            if (slider_Approx != null)
            Approx = Convert.ToDouble(slider_Approx.Value);

            //if (angle_number < 3)
            //    angle_number = 3;
            /*                if (textBlock_Approx != null && slider_Approx != null)
                            {
                                Approx = Convert.ToDouble(slider_Approx.Value);
                                angle_number = Convert.ToInt32(Math.PI / Math.Acos(Approx));
                                textBlock_Approx.Text = Convert.ToString(Approx);
                            }*/
            //}
            //catch { }
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            ReadParams();
            Approximate();
        }

        private void Slider_ValueChanged_1(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            ReadParams();
            Approximate();
        }
    }
}
