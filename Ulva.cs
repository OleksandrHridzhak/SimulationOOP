using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationOOP
{
  public class Ulva : Plant
  {
    public static readonly bool[,] DeafultShape =
    {
    { false, false, false, false, true,  false, false, true, false, false },
    { false, false, true,  true,  true,  true,  true,  true,  false, false },
    { false, true,  true,  true,  true,  true,  true,  true,  true,  false },
    { true,  true,  true,  true,  true,  true,  true,  true,  true,  false },
    { true,  true,  true,  true,  true,  true,  true,  true,  true,  false },
    { true,  true,  true,  true,  true,  true,  true,  true,  true,  true  }
};

    public Ulva(double x, double y , System.Drawing.Color color)
      : base(x, y, color, DeafultShape)
    {
    }
  }
}
