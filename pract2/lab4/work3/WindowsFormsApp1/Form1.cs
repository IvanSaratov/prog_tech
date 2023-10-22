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
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.RowCount = dataGridView2.RowCount = 10;
            dataGridView1.ColumnCount = dataGridView2.ColumnCount = 10;
            
            int[,] mass = new int[dataGridView1.RowCount, dataGridView1.ColumnCount];

            Random rand = new Random();
            for (int i = 0; i < dataGridView1.RowCount; i++)
                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                    mass[i, j] = rand.Next(-10, 10);


            for (int i = 0; i < dataGridView1.RowCount; i++)
                for (int j = 0; j < dataGridView1.ColumnCount; j++) {
                    dataGridView1.Rows[i].Cells[j].Value = dataGridView2.Rows[i].Cells[j].Value = Convert.ToString(mass[i, j]);

                }

            double sum = 0.0;
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                {
                    if (i == j)
                    {
                        sum += Convert.ToDouble(dataGridView1.Rows[i].Cells[j].Value);
                    }
                }
            }

            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                if (sum > 10)
                {
                    dataGridView2.Rows[i].Cells[i].Value = Convert.ToString(mass[i, i] + 13.5);
                } else
                {
                    dataGridView2.Rows[i].Cells[i].Value = Convert.ToString(Math.Pow(mass[i, i], 2) - 1.5);
                }
            }


            textBox1.Text = sum.ToString();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
