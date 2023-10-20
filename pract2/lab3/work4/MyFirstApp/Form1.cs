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

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = "-2,05";  // Начальное значение X0
            textBox2.Text = "-3,05"; // Начальное значение Xk
            textBox3.Text = "-0,2"; // Начальное значение Dx
            textBox4.Text = "3,4"; // Начальное значение b
        }     

        private void button1_Click(object sender, EventArgs e)
        {
            // Считывание начальных данных
            double x0 = Convert.ToDouble(textBox1.Text);
            double xk = Convert.ToDouble(textBox2.Text);
            double dx = Convert.ToDouble(textBox3.Text);
            double b = Convert.ToDouble(textBox4.Text);
            textBox5.Text = "Результат первой кнопки" + Environment.NewLine;


            double x = x0;
            while (x >= (xk + dx / 2))
            {
                double y = x * Math.Sin(Math.Sqrt(x + b - 0.0084));
                textBox5.Text += "x=" + Convert.ToString(x) +
                                 "; y=" + Convert.ToString(y) + Environment.NewLine;
                x = x + dx;
            }
        }
   
        private void button2_Click(object sender, EventArgs e)
        {
            // Считывание начальных данных
            double x0 = Convert.ToDouble(textBox1.Text);
            double xk = Convert.ToDouble(textBox2.Text);
            double dx = Convert.ToDouble(textBox3.Text);
            double b = Convert.ToDouble(textBox4.Text);
            textBox6.Text = "Результат второй кнопки" + Environment.NewLine;
            // Цикл для табулирования функции
            double x = x0;
            while (x >= (xk + dx / 2))
            {
                double y = x * Math.Sin(Math.Sqrt(x + b - 0.0084));
                textBox6.Text += "x=" + Convert.ToString(x) +
                                 "; y=" + Convert.ToString(y) + Environment.NewLine;
                x = x + dx / 2;
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }
    }
}