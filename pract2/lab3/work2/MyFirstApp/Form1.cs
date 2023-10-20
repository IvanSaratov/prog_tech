using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyFirstApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        private void Form1_Load_1(object sender, EventArgs e)
        {
            textBox1.Text = "0,03981";  // Начальное значение X
            textBox2.Text = "-1625"; // Начальное значение Y
            textBox3.Text = "0,512";// Начальное значение Z
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double x = double.Parse(textBox1.Text);
            textBox4.Text += Environment.NewLine +
                "X = " + x.ToString();
            double y = double.Parse(textBox2.Text);
            textBox4.Text += Environment.NewLine +
                "Y = " + y.ToString();
            double z = double.Parse(textBox3.Text);
            textBox4.Text += Environment.NewLine +
                "Z = " + z.ToString();

            // Вычисляем арифметическое выражение
            double a = Math.Pow(2, -x) * Math.Sqrt(x + Math.Pow(1 / 4, Math.Abs(y) * Math.Pow(1 / 3, Math.Pow(Math.E, (x - 1) / Math.Sin(z)))));

            // Выводим результат в окно
            textBox4.Text += Environment.NewLine + "Результат а = " + a.ToString();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
