// Махмудов Орхан. 80-305Б Прямой цилиндр, основание – сектор гиперболы
// Анимация. Вращение относительно оси OZ Скорость вращения меняется по синусоиде.

using System;
using Tao.FreeGlut;
using OpenGL;

namespace CG_Lab_6
{
    class Program
    {
        public static int width = 1900, height = 1080;
        public static ShaderProgram program;

        private static int angle_number = 3; // кол-во углов пирамиды
        private static int level_number = 1; // общее кол-во пирамид
        private static double r = 1; // радиус цилиндра
        private static double Height = 1;
        private static double Approx = 0.7;
        private static double r_a = 1;
        private static double r_b = 1;

        private static Point[] bottom_points; // массив вершин нижнего основания
        private static Point[] top_points; // массив вершин верхнего основания

        private static System.Diagnostics.Stopwatch watch; // таймер
        private static float angle; // угол поворота

        // программа шейдера вершин
        public static string VertexShader = @"
        #version 130
        in vec3 vertexPosition;
        in vec3 vertexColor;
        out vec3 color;
        uniform mat4 projection_matrix;
        uniform mat4 view_matrix;
        uniform mat4 model_matrix;
        void main(void)
        {
            color = vertexColor;
            gl_Position = projection_matrix * view_matrix * model_matrix * vec4(vertexPosition, 1);
        }";

        public static string FragmentShader = @"
        #version 130
        in vec3 color;
        out vec4 fragment;
        void main(void)
        {
            fragment = vec4(color, 1);      
        }";

        static void Main(string[] args)
        {
            Console.Write("enter coefficient of approximation (0,6 - 0,99)  ");
            Approx = Convert.ToDouble(Console.ReadLine());
            if (Approx > 0.99)
                Approx = 0.99;
            if (Approx < 0.3)
                Approx = 0.6;

            angle_number = Convert.ToInt32(Math.PI / Math.Acos(Approx));
            if (angle_number < 3)
                angle_number = 3;

            Console.Write("enter radius (0,1 - 5)  ");
            r = Convert.ToDouble(Console.ReadLine());
            if (r > 5)
                r = 5;
            if (r < 0.1)
                r = 0.1;

            Console.Write("enter height (0,1 - 5)  ");
            Height = Convert.ToDouble(Console.ReadLine());
            if (Height > 5)
                Height = 5;
            if (Height < 0.1)
                Height = 0.1;

            Console.Write("enter coefficient a (0,1 - 5)  ");
            r_a = Convert.ToDouble(Console.ReadLine());
            if (r_a > 5)
                r_a = 5;
            if (r_a < 0.1)
                r_a = 0.1;

            Console.Write("enter coefficient a (0,1 - 5)  ");
            r_b = Convert.ToDouble(Console.ReadLine());
            if (r_b > 5)
                r_b = 5;
            if (r_b < 0.1)
                r_b = 0.1;

            watch = System.Diagnostics.Stopwatch.StartNew();
            InitOpenGL(); // инициализация OpenGL
        }

        private static void InitOpenGL()
        {
            Glut.glutInit();
            Glut.glutInitDisplayMode(Glut.GLUT_DOUBLE | Glut.GLUT_DEPTH);

            Glut.glutInitWindowSize(width, height);
            Glut.glutCreateWindow("Махмудов Орхан 80-305Б Прямой цилиндр, основание – сектор гиперболы");

            Glut.glutIdleFunc(OnRenderFrame);
            Glut.glutDisplayFunc(OnDisplay);
            Glut.glutCloseFunc(OnClose);

            Gl.Enable(EnableCap.DepthTest);

            program = new ShaderProgram(VertexShader, FragmentShader);

            // задаем положение изображения в окне
            program.Use();
            program["projection_matrix"].SetValue(Matrix4.CreatePerspectiveFieldOfView(0.45f, (float)width / height, 0.1f, 1000f));
            program["view_matrix"].SetValue(Matrix4.LookAt(new Vector3(0, 0, 10), new Vector3(-1,0,0), new Vector3(0, 1, 0)));
            program["model_matrix"].SetValue(Matrix4.CreateRotationX(180) * Matrix4.CreateTranslation(new Vector3(-1.5f, 0, 0)));

            Glut.glutMainLoop(); // старт
        }

        private static void OnClose()
        {
            program.DisposeChildren = true;
            program.Dispose();
        }

        private static void OnDisplay()
        {
           
        }

        private static void OnRenderFrame()
        {
            // изменяем угол поворота относительно таймера
            watch.Stop();
            float deltaTime = (float)watch.ElapsedTicks / System.Diagnostics.Stopwatch.Frequency;
            watch.Restart();
            angle += deltaTime;

            //// осуществляем поворот
            program["model_matrix"].SetValue(Matrix4.CreateRotationZ(angle) * Matrix4.CreateRotationZ((float)Math.Sin(angle)) * Matrix4.CreateTranslation(new Vector3(-2.5f, -1.0f, 0)));

            // инициализируем Viewport
            Gl.Viewport(0, 0, Program.width, Program.height);
            Gl.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            // Алгоритм аналогичен Лаб№3
            bottom_points = new Point[angle_number];
            top_points = new Point[angle_number];

            CountBottomPoints();

            for (int level = 0; level < level_number; level++)
            {
                CountTopPoints(level);
                TruncatedPyramid pyramid = new TruncatedPyramid(bottom_points, top_points);
                pyramid.Draw();
                for (int i = 0; i < angle_number; i++) bottom_points[i] = top_points[i];
                pyramid.Dispose();
            }

            Glut.glutSwapBuffers();
        }
            
        // Просчитываем координаты точек нижнего основания 
        private static void CountBottomPoints()
        {
            double step = Math.PI / angle_number;
            double alpha = 3.14;
            for (int i = 0; i < angle_number; i++)
            {
                double x = r_a*r * Math.Cos(alpha);
                double y = r_b*r * Math.Sin(alpha);
                bottom_points[i] = new Point((float)x, (float)y, 0);
                
                alpha += step;
            }
        }

        // Просчитываем координаты точек верхнего основания 
        private static void CountTopPoints(int current_level)
        {
            double alpha = Math.PI / (2 * level_number + 1);
            for (int i = 0; i < angle_number; i++)
            {
                Point A = bottom_points[i];

                double z = Height * r * Math.Sin((current_level + 1) * alpha);
                //double k = r * Math.Cos((current_level + 1) * alpha) / Math.Sqrt(A.X * A.X + A.Y * A.Y);
                double x = A.X;
                double y = A.Y;

                top_points[i] = new Point((float)x, (float)y, (float)z);
            }
        }
    }
}
