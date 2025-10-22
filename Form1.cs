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


    List<Fish> fishes = new List<Fish>();
    List<Meduza> meduzas = new List<Meduza> ();

    Random rnd = new Random();

    private void Form1_Load(object sender, EventArgs e)
    {
      Color[] colors = { Color.Orange, Color.Green, Color.Yellow, Color.Red, Color.Blue, Color.Purple };
      Color[] plantColors = { Color.Green, Color.DarkGreen, Color.LightGreen, Color.Lime };
      Color[] meduzaColors = { Color.Pink, Color.Violet, Color.Cyan, Color.LightBlue };

      for (int i = 0; i < 30; i++)
      {
        float x = rnd.Next(0, pictureBox1.Width);
        float y = rnd.Next(0, pictureBox1.Height);
        Color color = colors[rnd.Next(colors.Length)];
        float speed = (float)(rnd.NextDouble() * 3 + 1); 
        fishes.Add(new Fish(x, y, color, speed, pictureBox1.Width, pictureBox1.Height));
      }
      for (int i = 0; i < 30; i++)
      {
        float x = rnd.Next(0, pictureBox1.Width);
        float y = rnd.Next(0, pictureBox1.Height);
        Color color = meduzaColors[rnd.Next(meduzaColors.Length)];
        float speed = (float)(rnd.NextDouble() * 3 + 1);
        meduzas.Add(new Meduza(x, y, color, speed, pictureBox1.Width, pictureBox1.Height));
      }

      Ulva ulva = new Ulva(120, pictureBox1.Height - 20, Color.Green);
      timer = new Timer();
      timer.Interval = 60;
      timer.Tick += (s, ev) =>
      {
        foreach (var fish in fishes)
        {

          fish.Move(pictureBox1.Width, pictureBox1.Height);
        }
        foreach (var meduza in meduzas)
        {
          meduza.Move(pictureBox1.Width, pictureBox1.Height);
        }
        pictureBox1.Invalidate();
      };
      timer.Start();
      

      pictureBox1.Paint += (s, ev) =>
      {
        foreach (var fish in fishes)
        {
          fish.Draw(ev.Graphics);
        }
        foreach (var meduza in meduzas)
        {
          meduza.Draw(ev.Graphics);
        }
        ulva.Draw(ev.Graphics);
      };

    }

    private void label1_Click(object sender, EventArgs e)
    {

    }

    private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
    {
      int mouseX = e.X;
      int mouseY = e.Y;

      foreach (var fish in fishes)
      {
        int width = fish.Shape.GetLength(1) * 3;
        int height = fish.Shape.GetLength(0) * 3;

        if (mouseX >= fish.X && mouseX <= fish.X + width &&
            mouseY >= fish.Y && mouseY <= fish.Y + height)
        {
          MessageBox.Show(fish.GetInfo());
          break;
        }
      }

    }
  }
}
