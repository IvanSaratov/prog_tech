using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        // Наши массивы
        private int[] D = new int[16];
        private int[] E = new int[16];


        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox3.Clear();

            Random rand = new Random();

            for (int i = 0; i < 16; i++)
            {
                D[i] = rand.Next(-10, 10);
                textBox1.Text += "Mas[" + Convert.ToString(i + 1) + "] = "
                    + Convert.ToString(D[i]) + Environment.NewLine;
                E[i] = rand.Next(-10, 10);
                textBox3.Text += "Mas[" + Convert.ToString(i + 1) + "] = "
                    + Convert.ToString(E[i]) + Environment.NewLine;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < D.Length; i++)
            {
                double fi = (2 * D[i] + Math.Sin(E[i])) / D[i];

                if (1 < fi && fi < 3)
                {
                    textBox2.Text += "Mas[" + Convert.ToString(i + 1) + "] = "
                    + Math.Round(fi, 0) + Environment.NewLine;
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
