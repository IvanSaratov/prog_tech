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
            textBox1.Text = "0,5";  // Начальное значение X
            textBox2.Text = "2,2"; // Начальное значение Y
        }     

        private void button1_Click(object sender, EventArgs e)
        {
            // Получение исходных данных из TextBox
            double x = Convert.ToDouble(textBox1.Text);
            double b = Convert.ToDouble(textBox2.Text);
            //double z = Convert.ToDouble(textBox3.Text);
            // Ввод исходных данных в окно результатов
            textBox4.Text = Environment.NewLine;
            textBox4.Text += "При X = " + textBox1.Text + Environment.NewLine;
            textBox4.Text += "При B = " + textBox2.Text + Environment.NewLine;
            // Определение номера выбранной функции
            int n = 0;
            if (radioButton2.Checked) n = 1;
            else if (radioButton3.Checked) n = 2;
            // Вычисление U
            double u;
            switch (n)
            {
                case 0:
                    if ((x * b > 0.5) && (x * b < 10)) u = Math.Exp(Math.Sinh(x) - Math.Abs(b));
                    else if ((x * b > 0.1) && (x * b < 0.5)) u = Math.Sqrt(Math.Abs(Math.Pow(x, 2) + b));
                    else u = 2 * Math.Pow(Math.Exp(x), 2);
                    textBox4.Text += "U = " + Convert.ToString(u) + Environment.NewLine;
                    break;
                case 1:
                    if ((x * b > 0.5) && (x * b < 10)) u = Math.Exp(Math.Sinh(x) - Math.Abs(b));
                    else if ((x * b > 0.1) && (x * b < 0.5)) u = Math.Sqrt(Math.Abs(Math.Pow(x, 2) + b));
                    else u = 2 * Math.Pow(Math.Exp(x), 2);
                    textBox4.Text += "U = " + Convert.ToString(u) + Environment.NewLine;
                    break;
                case 2:
                    if ((x * b > 0.5) && (x * b < 10)) u = Math.Exp(Math.Sinh(x) - Math.Abs(b));
                    else if ((x * b > 0.1) && (x * b < 0.5)) u = Math.Sqrt(Math.Abs(Math.Pow(x, 2) + b));
                    else u = 2 * Math.Pow(Math.Exp(x), 2);
                    textBox4.Text += "U = " + Convert.ToString(u) + Environment.NewLine;
                    break;
                default:
                    textBox4.Text += "Решение не найдено" + Environment.NewLine;
                    break;
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

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
