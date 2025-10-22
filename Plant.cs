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
    public override string GetInfo()
    {
      return "This is a plant.";
    }
    public Plant(double x, double y, Color color, bool[,] shape)
      : base(x, y, color, shape) { }
  }
}
