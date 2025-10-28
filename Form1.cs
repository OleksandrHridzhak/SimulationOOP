using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace SimulationOOP
{
  public partial class Form1 : Form
  {
    //Обєкт таймера для оновлення положення обєктів
    Timer timer = new Timer();

    public Form1()
    {
      InitializeComponent();
    }
    private void pictureBox1_Click(object sender, EventArgs e)
    {

    }

    // Списоски створених обєктів
    List<Creature> creatures = new List<Creature>();
    List<Plant> plants = new List<Plant>();

    // Обєкт гереування випадкових чисел
    Random rnd = new Random();

    // Обробник створення форми
    private void Form1_Load(object sender, EventArgs e)
    {
      // Масиви кольорів для створення обєктів
      Color[] colors = { Color.Orange, Color.Green, Color.Yellow, Color.Red, Color.Blue, Color.Purple };
      Color[] plantColors = { Color.Green, Color.DarkGreen, Color.LightGreen, Color.Lime };
      Color[] meduzaColors = { Color.Pink, Color.Violet, Color.Cyan, Color.LightBlue };

      // Цикл створення обєктів
      for (int i = 0; i < 30; i++)
      {
        // Випадкові координати для обєктів
        double x = rnd.Next(0, pictureBox1.Width);
        double y = rnd.Next(0, pictureBox1.Height);

        //Випадковий колір який отримується за індексом з масиву кольорів
        Color color = colors[rnd.Next(colors.Length)];

        // Отримуємо швидкість шляхом геренації випадковго числа від 0 до 1, помноження на 3 та додавання 1
        double speed = rnd.NextDouble() * 3 + 1;

        //Додамо новий обєкт до списку створених обєктів
        creatures.Add(new Fish(x, y, color, speed, pictureBox1.Width, pictureBox1.Height));

        // Створюю нові координати , колір та швидкість для медуз
        x = rnd.Next(0, pictureBox1.Width);
        y = rnd.Next(0, pictureBox1.Height);
        color = meduzaColors[rnd.Next(meduzaColors.Length)];
        speed = rnd.NextDouble() * 3 + 1;

        // Додаємо нову медузу до списку створених обєктів
        creatures.Add(new Meduza(x, y, color, speed, pictureBox1.Width, pictureBox1.Height));

        // Створюємо новий обєкт рослини з випадковим кольором алу з фіксованим розташуванням по Y
        color = plantColors[rnd.Next(plantColors.Length)];
        plants.Add(new Ulva(rnd.Next(0, pictureBox1.Width), pictureBox1.Height - 20,color));
      }

      // Налаштування таймера для оновлення положення обєктів
      timer.Interval = 60;
      // Обробник події Tick таймера
      timer.Tick += (s, ev) =>
      {
        foreach (var creature in creatures)
        {
          creature.Move(pictureBox1.Width, pictureBox1.Height);
        }
        // Перемальовуємо PictureBox
        pictureBox1.Invalidate();
      };
      // Після налаштування запускаємо таймер
      timer.Start();

      // Обробник події Paint для PictureBox
      pictureBox1.Paint += (s, ev) =>
      {
        // Малюємо всі створені обєкти
        foreach (var creature in creatures)
        {
          creature.Draw(ev.Graphics);
        }
        foreach (var plant in plants)
        {
          plant.Draw(ev.Graphics);
        }
      };

    }

    private void label1_Click(object sender, EventArgs e)
    {

    }

    private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
    {
      // Отримуємо координати кліку миші
      int mouseX = e.X;
      int mouseY = e.Y;

      // Перевіряємо чи клікнули ми по якомусь створінню
      foreach (var creature in creatures)
      {
        // Обчислюємо ширину та висоту створіння 
        int width = creature.Shape.GetLength(1) * 5;
        int height = creature.Shape.GetLength(0) * 5;
        // Перевіряємо чи знаходяться координати кліку в межах створіння
        if (mouseX >= creature.X && mouseX <= creature.X + width &&
            mouseY >= creature.Y && mouseY <= creature.Y + height)
        {
          // Збільшуємо швидкість створіння на 10 одиниць
          creature.Speed += 10;
          MessageBox.Show(creature.GetInfo());
          break;
        }
      }
      // Перевіряємо чи клікнули ми по якійсь рослині
      foreach (var plant in plants)
      {
        int wight = plant.Shape.GetLength(1) * 5;
        int height = plant.Shape.GetLength(0) * 5;

        if (mouseX >= plant.X && mouseX <= plant.X + wight &&
            mouseY >= plant.Y && mouseY <= plant.Y + height)
        {
          MessageBox.Show(plant.GetInfo());
          break;
        }


      }
    }
  }
}
