using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media.Media3D;

namespace CG_Lab_3
{
    class TruncatedPyramid
    {
        private Point3D[] bottom_points;
        private Point3D[] top_points;

        public TruncatedPyramid(Point3D[] bottom_points, Point3D[] top_points)
        {
            this.bottom_points = bottom_points;
            this.top_points = top_points;
        }

        public void Draw(GeometryModel3D geometry_model_3d)
        {
            MeshGeometry3D mesh = new MeshGeometry3D();

            // Заносим вершины в массивы
            foreach (Point3D point in bottom_points) mesh.Positions.Add(point);
            foreach (Point3D point in top_points) mesh.Positions.Add(point);

            int n = bottom_points.Length;

            // Рисуем основания
            for (int i = 2; i < n; i++)
            {
                AddTriangle(mesh, 0, i, i-1);
                AddTriangle(mesh, i - 1 + n, i + n, n);
            }

            // Рисуем боковые грани
            for (int i = 0; i < n-1; i++)
            {
                AddTriangle(mesh, i, i+1, n+i);
                AddTriangle(mesh, i+1, n+i+1, n+i);
            }
            AddTriangle(mesh, 0, n, 2*n-1);
            AddTriangle(mesh, 0, 2*n-1, n-1);

            geometry_model_3d.Geometry = mesh;
        }

        // прорисовка треугольника по трем точкам
        private void AddTriangle(MeshGeometry3D mesh, int A, int B, int C)
        {
            mesh.TriangleIndices.Add(A);
            mesh.TriangleIndices.Add(B);
            mesh.TriangleIndices.Add(C);
        }
    }
}
