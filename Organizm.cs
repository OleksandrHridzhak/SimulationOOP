using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationOOP
{
    // Базовий клас для стоврінь та рослин
    public abstract class Organizm
    {
    // Пропертіс (автоматичні) для позиції, кольору та форми організму
    public double X { get; set; }
      public double Y { get; set; }
      public Color Color { get; set; }
      public bool[,] Shape { get; set; }

    // Конструктор для ініціалізації організму
    public Organizm(double x, double y, Color color, bool[,] shape)
      {
        X = x;
        Y = y;
        Color = color;
        Shape = shape;
      }
    // Абстракний клас який потім буде мати різні виводи в дочірніх класах 
    // This is a creature або This is a plant
    public abstract string GetInfo();

    // Метод для малювання організму
    public void Draw(Graphics g)
      {
      // Розмір однієї клітинки форми
      int cellSize = 5;

      // Проходимо по всіх елементах матриці форми і малюєм
      for (int i = 0; i < Shape.GetLength(0); i++)
        {
          for (int j = 0; j < Shape.GetLength(1); j++)
          {
            if (Shape[i, j])
            {
              g.FillRectangle(new SolidBrush(Color),
                  (float)(X + j * cellSize),
                  (float) (Y + i * cellSize),
                  cellSize,
                  cellSize);
            }
          }
        }
     }
  }
}
