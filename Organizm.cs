using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationOOP
{
    public abstract class Organizm
    {
      public double X { get; set; }
      public double Y { get; set; }
      public Color Color { get; set; }
      public bool[,] Shape { get; set; }

      public Organizm(double x, double y, Color color, bool[,] shape)
      {
        X = x;
        Y = y;
        Color = color;
        Shape = shape;
      }
    public abstract string GetInfo();

    public void Draw(Graphics g)
      {
        int cellSize = 3;

        for (int i = 0; i < Shape.GetLength(0); i++)
        {
          for (int j = 0; j < Shape.GetLength(1); j++)
          {
            if (Shape[i, j])
            {
              g.FillRectangle(new SolidBrush(Color),
                  (float)(X + j * cellSize),
                  (float) Y + i * cellSize,
                  cellSize,
                  cellSize);
            }
          }
        }
     }
  }
}
