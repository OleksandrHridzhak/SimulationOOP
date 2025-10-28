using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationOOP
{
  // Клас Медуза який наслідує від класу Creature
  public class Meduza : Creature
  {
    // Статичне поле яке визначає стандартну форму медузи
    public static readonly bool[,] DeafultShape =
    {
      { false,  true,  true,  true,  true,  true,  true,  false },
      { true,  true,  true,  true,  true,  true,  true,  true },
      { true,  true,  true,  true,  true,  true,  true,  true },
      { true,  true,  true,  true,  true,  true,  true,  true },
      { true, true, false, true, false, true, false, true },
      { true, true, false, true, false, true, false, true }

      };
    // Конструктор класу Meduza
    public Meduza(double x, double y, System.Drawing.Color color, double speed, int maxWidth, int maxHeight):
      base(x, y, color, DeafultShape, speed, maxWidth, maxHeight)
    {

    }
  }
}
