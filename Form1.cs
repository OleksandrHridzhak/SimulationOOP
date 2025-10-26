using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace SimulationOOP
{
  public partial class Form1 : Form
  {
    Timer timer;

    public Form1()
    {
      InitializeComponent();
    }
    private void pictureBox1_Click(object sender, EventArgs e)
    {

    }


    List<Creature>creatures = new List<Creature>();
    List<Plant> plants = new List<Plant>();
    Random rnd = new Random();

    private void Form1_Load(object sender, EventArgs e)
    {
      Color[] colors = { Color.Orange, Color.Green, Color.Yellow, Color.Red, Color.Blue, Color.Purple };
      Color[] plantColors = { Color.Green, Color.DarkGreen, Color.LightGreen, Color.Lime };
      Color[] meduzaColors = { Color.Pink, Color.Violet, Color.Cyan, Color.LightBlue };

      for (int i = 0; i < 30; i++)
      {
        double x = rnd.Next(0, pictureBox1.Width);
        double y = rnd.Next(0, pictureBox1.Height);
        Color color = colors[rnd.Next(colors.Length)];
        double speed = rnd.NextDouble() * 3 + 1; 
        creatures.Add(new Fish(x, y, color, speed, pictureBox1.Width, pictureBox1.Height));

        x = rnd.Next(0, pictureBox1.Width);
        y = rnd.Next(0, pictureBox1.Height);
        color = meduzaColors[rnd.Next(meduzaColors.Length)];
        speed = rnd.NextDouble() * 3 + 1;
        creatures.Add(new Meduza(x, y, color, speed, pictureBox1.Width, pictureBox1.Height));

        color  = plantColors[rnd.Next(plantColors.Length)];
        plants.Add(new Ulva(rnd.Next(0, pictureBox1.Width), pictureBox1.Height - 20,color));
      }


      Ulva ulva = new Ulva(120, pictureBox1.Height - 20, Color.Green);
      timer = new Timer();
      timer.Interval = 60;
      timer.Tick += (s, ev) =>
      {
        foreach (var creature in creatures)
        {

          creature.Move(pictureBox1.Width, pictureBox1.Height);
        }
        pictureBox1.Invalidate();
      };
      timer.Start();
      

      pictureBox1.Paint += (s, ev) =>
      {
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
      int mouseX = e.X;
      int mouseY = e.Y;

      foreach (var creature in creatures)
      {
        int width = creature.Shape.GetLength(1) * 5;
        int height = creature.Shape.GetLength(0) * 5;

        if (mouseX >= creature.X && mouseX <= creature.X + width &&
            mouseY >= creature.Y && mouseY <= creature.Y + height)
        {
          creature.setSpeed(creature.Speed + 10);
          MessageBox.Show(creature.GetInfo());
          break;
        }
      }
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
