using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

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
            for (int i =0; i <listBox1.Items.Count; i++)
            {
                listBox1.Items[i] = listBox1.Items[i].ToString().Substring(1, listBox1.Items[i].ToString().Length - 1);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            // Получаем количество слов и букв за слово.
            int num_letters = 10;
            int num_words = 10;

            // Создаем массив букв, которые мы будем использовать.
            char[] letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

            // Создаем генератор случайных чисел.
            Random rand = new Random();

            // Делаем слова.
            for (int i = 1; i <= num_words; i++)
            {
                // Сделайте слово.
                string word = "";
                for (int j = 1; j <= num_letters; j++)
                {
                    // Выбор случайного числа от 0 до 25
                    // для выбора буквы из массива букв.
                    int letter_num = rand.Next(0, letters.Length - 1);

                    // Добавить письмо.
                    word += letters[letter_num];
                }

                // Добавьте слово в список.
                listBox1.Items.Add(word);
            }
        }   
    }
}
