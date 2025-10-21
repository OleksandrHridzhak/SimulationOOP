using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationOOP
{
  public class Meduza : Creature
  {
    public static readonly bool[,] DeafultShape =
    {
      { false,  true,  true,  true,  true,  true,  true,  false },
      { true,  true,  true,  true,  true,  true,  true,  true },
      { true,  true,  true,  true,  true,  true,  true,  true },
      { true,  true,  true,  true,  true,  true,  true,  true },
      { true, true, false, true, false, true, false, true },
      { true, true, false, true, false, true, false, true }

      };
    public Meduza(double x, double y, System.Drawing.Color color, double speed, int maxWidth, int maxHeight):
      base(x, y, color, DeafultShape, speed, maxWidth, maxHeight)
    {

    }
  }
}
