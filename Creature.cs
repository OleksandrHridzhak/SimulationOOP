using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationOOP
{
  // Базовий клас для створінь (Зробив його абстрактним для того, щоб заборонити стоврення обєктів від  нього напряму)
  public abstract class Creature : Organizm
  {
    // Реалізація інкапслуції на прикладі швикдкостііі
    // Приватне поле для зберігання швидкості
    private double speed;
    // Публічне властивість для доступу до швидкості з перевіркою
    public double Speed {
      get
      {
        return speed;
      }
      //  сеттер з перевіркою на відємні значення
      set
      {
        if (value < 0)
          speed = 1;
        else
          speed = value;
      }

    }
    // Публічні властивісті для напрямку руху та меж екрану
    public double Direction { get; set; }
    public int maxWidth { get; set; }
    public int maxHeight { get; set; }

    // Статичне поле для генерації випадкових чисел
    public static Random rnd = new Random();
    // Конструктор класу Creature
    public Creature(double x, double y, Color color, bool[,] shape, double initSpeed, int maxWidth, int maxHeight)
      : base(x, y, color, shape)
    {
      Speed = initSpeed;
      Direction = rnd.Next(0, 360);
      this.maxWidth = maxWidth;
      this.maxHeight = maxHeight;
    }
    // Реалізація абстрактного методу з батьківського класу
    public override string GetInfo()
    {
      return "This is a creature";
    }





    // Метод для руху створіння
    //==================================================================
    //===================================================================
    // !!ALARM!! (Прошу не задавати питання як це працює, бо я не розумію)
    //===================================================================
    //==================================================================
    public void Move(int maxWidth, int maxHeight)
    {
      Direction += rnd.NextDouble() * 6 ;

      X += Math.Cos(Direction * Math.PI / 180) * Speed;
      Y += Math.Sin(Direction * Math.PI / 180) * Speed;

      if (X < 0)
      {
        X = 0;
        Direction = rnd.NextDouble() * 6;
      }

      if (Y < 0)
      {
        Y = 2;
        Direction = rnd.NextDouble() * 6;
      }

      if (X > maxWidth - Shape.GetLength(1) * 3)
      {
        X = maxWidth - Shape.GetLength(1) * 3;
        Direction = -Direction;
      }

      if (Y > maxHeight - Shape.GetLength(0) * 3)
      {
        Y = maxHeight - Shape.GetLength(0) * 3;
        Direction = -Direction;
      }

    }
  }
}
