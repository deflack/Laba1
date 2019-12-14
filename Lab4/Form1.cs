using System;
using System.Windows.Forms;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;

namespace Lab4
{
    public partial class Form1 : Form
    {
        List<string> list = new List<string>();
        Stopwatch sw = new Stopwatch();
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "txt files|*.txt";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                list.Clear();
                string[] words = File.ReadAllText(ofd.FileName).Split('\n', ' ', ',', '.', '?', ';', ':', '(', ')', '"', '!');
                string text = "";
                sw.Reset();
                sw.Start();
                foreach(string word in words)
                {
                    if (!text.Contains(word))
                        list.Add(word);
                    text += word;
                }
                sw.Stop();
                text = "";
                foreach (string item in list)
                    text += " " + item;
                label1.Text = "Время сохранения слов в список, мс: " + sw.ElapsedMilliseconds.ToString();
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            //List<string> searchedWords = new List<string>();
            if (list.Count == 0)
                MessageBox.Show("Файл не прочитан либо не содержит текст.");
            else if (textBox1.Text.Length == 0)
                MessageBox.Show("Введите слово для сравнения.");
            else if (textBox2.Text.Length == 0)
                MessageBox.Show("Введите максимальное расстояние.");
            else
            {
                if (int.TryParse(textBox2.Text, out int max))
                {
                    listBox1.BeginUpdate();
                    listBox1.Items.Clear();
                    sw.Reset();
                    sw.Start();
                    foreach (string item in list)
                    {
                        if (Lab5.Distance.Levenshtein(textBox1.Text, item) <= max)
                            listBox1.Items.Add(item);
                    }
                    sw.Stop();
                    listBox1.EndUpdate();
                    label2.Text = "Время определения слов, мс: " + sw.ElapsedMilliseconds.ToString();
                }
                else
                {
                    MessageBox.Show("Ошибка ввода максимального расстояния.");
                }
            }
        }
    }
}
