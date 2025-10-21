using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationOOP
{
  public class Fish : Creature
  {
    public static readonly bool[,] DeafultShape =
    {
          { false, false, false, true,  false,  false,  false, false, true },
          { false, false, true,  true,  true,  true,  true,  false, true },
          { false, true,  true,  false, true,  false, true,  true,  true },
          { true,  true,  true,  true,  true,  true,  true,  true,  true },
          { false, true,  true,  true,  true,  true,  true,  true,  true },
          { false, false, true,  true,  true,  true,  true,  false, true },
          { false, false, false, true,  false,  false,  false, false, true }
      };
    public Fish(double x, double y, Color color, double speed, int maxWidth, int maxHeight)
      : base(x, y, color, DeafultShape, speed, maxWidth, maxHeight)
    {
    }


  }
}
