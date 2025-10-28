using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationOOP
{
  // Базовий клас для рослин (Зробив його абстрактним для того, щоб заборонити стоврення обєктів від  нього напряму)
  public abstract class Plant : Organizm
  {
    // Перевизначений метод для отримання інформації про рослину
    public override string GetInfo()
    {
      return "This is a plant.";
    }
    // Конструктор для ініціалізації рослини 
    public Plant(double x, double y, Color color, bool[,] shape)
      //Передача базовому конструктору
      : base(x, y, color, shape) { }
  }
}
