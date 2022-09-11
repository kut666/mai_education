using System;
using Tao.FreeGlut;
using OpenGL;

namespace CG_Lab_4_5
{
    class TruncatedPyramid
    {
        public VBO<Vector3> vertices;
        public VBO<Vector3> color;
        public VBO<int> elements;

        Vector3[] vector_vertices;
        Vector3[] vector_color;
        int[] array_elements;

        public TruncatedPyramid(Point[] bottom_points, Point[] top_points)
        {
            int n = top_points.Length;
            vector_vertices = new Vector3[4 * n];
            vector_color = new Vector3[6 * n * n];
            array_elements = new int[6 * n*n];

            // рисуем основания
            int j = 0;
            for(int i=2; i<n; i++)
            {
                array_elements[j] = 0;
                array_elements[j + 1] = i;
                array_elements[j + 2] = i - 1;
                array_elements[j + 3] = n;
                array_elements[j + 4] = i + n;
                array_elements[j + 5] = i - 1 + n;
                j += 6;
            }

            // рисуем боковые стороны
            for(int i=0; i<n;i++)
            {
                vector_vertices[i] = new Vector3(bottom_points[i].X, bottom_points[i].Y, bottom_points[i].Z);
                vector_color[i] = new Vector3(2.0f, 0.1f, 0.0f);

                vector_vertices[i + n] = new Vector3(top_points[i].X, top_points[i].Y, top_points[i].Z);
                vector_color[i+n] = new Vector3(1.0f, 0.5f, 0.0f);

                array_elements[j] = i + n;
                array_elements[j + 1] = i;
                array_elements[j + 2] = i+1 ;
                array_elements[j + 3] = i+n;
                array_elements[j + 4] = i+1;
                array_elements[j + 5] = i+1+n;
                j += 6;
            }
            j -= 6;

            array_elements[j] = 2*n-1;
            array_elements[j + 1] = n-1;
            array_elements[j + 2] = 0;
            array_elements[j + 3] = 2 * n - 1;
            array_elements[j + 4] = 0;
            array_elements[j + 5] = n;

            // создаем объекты из массивов
            vertices = new VBO<Vector3>(vector_vertices);
            color = new VBO<Vector3>(vector_color);
            elements = new VBO<int>(array_elements, BufferTarget.ElementArrayBuffer);
        }

        public void Draw()
        {
            Gl.UseProgram(Program.program);

            Gl.BindBufferToShaderAttribute(vertices, Program.program, "vertexPosition");
            Gl.BindBufferToShaderAttribute(color, Program.program, "vertexColor");
            Gl.BindBuffer(elements);

            // непосредственная прорисовка
            Gl.DrawElements(BeginMode.Triangles, elements.Count, DrawElementsType.UnsignedInt, IntPtr.Zero);
        }

        // освобождаем память
        public void Dispose()
        {
            vertices.Dispose();
            elements.Dispose();
            color.Dispose();

            Array.Clear(vector_vertices, 0, vector_vertices.Length);
            Array.Clear(vector_color, 0, vector_color.Length);
            Array.Clear(array_elements, 0, array_elements.Length);
        }
    }
}
