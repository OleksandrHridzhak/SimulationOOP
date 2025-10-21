using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationOOP
{
  public class Plant : Organizm
  {
    public static readonly bool[,] DeafultShape =
    {
      { false, false, true,  false, false, false },
      { false, true,  true,  true,  false, false },
      { false, true,  true,  true,  true,  false },
      { true,  true,  false, true,  true,  false },
      { false, true,  true,  true,  true,  false },
      { true,  true,  true,  true,  true,  true } 
    };
    public Plant(double x, double y, Color color, bool[,] shape)
      : base(x, y, color, DeafultShape) { }
  }
}
