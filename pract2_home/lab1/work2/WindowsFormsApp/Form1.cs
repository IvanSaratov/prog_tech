using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;


namespace WindowsFormsApp
{
    public partial class Form1 : Form
    {
        private List<Star> stars; // список звезд

        public Form1()
        {
            InitializeComponent();
            InitializeStars();
        }

        private void InitializeStars()
        {
            stars = new List<Star>();

            Random random = new Random();

            // создаем несколько звезд с разными координатами и скоростью падения
            for (int i = 0; i < 10; i++)
            {
                int x = random.Next(0, this.ClientSize.Width);
                int y = random.Next(0, this.ClientSize.Height);
                int speed = random.Next(1, 5);

                Star star = new Star(x, y, speed);
                stars.Add(star);
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            foreach (Star star in stars)
            {
                star.Draw(e.Graphics);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            foreach (Star star in stars)
            {
                star.UpdatePosition();
            }

            // перерисовываем форму
            this.Invalidate();
        }
    }

    public class Star
    {
        private int x; // координата x
        private int y; // координата y
        private int speed; // скорость падения

        public Star(int x, int y, int speed)
        {
            this.x = x;
            this.y = y;
            this.speed = speed;
        }

        public void UpdatePosition()
        {
            // обновляем позицию звезды, увеличивая координату y на скорость падения
            this.y += speed;
        }

        public void Draw(Graphics g)
        {
            // рисуем звезду на указанных координатах
            g.FillEllipse(Brushes.Blue, x, y, 5, 5);
        }
    }
}
