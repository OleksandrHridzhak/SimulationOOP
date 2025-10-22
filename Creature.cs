using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationOOP
{
  public abstract class Creature : Organizm
  {
    private double speed;
    public double Speed {
      get
      {
        return speed;
      }
      
      private set
      {
        if (value < 0)
          speed = 1;
        else
          speed = value;
      }

    }
    public void setSpeed(double newSpeed)
    {
      Speed = newSpeed;
    }
    public double Direction { get; set; }
    public int maxWidth { get; set; }
    public int maxHeight { get; set; }
    public static Random rnd = new Random();
    public Creature(double x, double y, Color color, bool[,] shape, double initSpeed, int maxWidth, int maxHeight)
      : base(x, y, color, shape)
    {
      Speed = initSpeed;
      Direction = rnd.Next(0, 360);
      this.maxWidth = maxWidth;
      this.maxHeight = maxHeight;
    }
    public override string GetInfo()
    {
      return "This is a creature";
    }
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
