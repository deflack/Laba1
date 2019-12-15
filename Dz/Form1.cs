using System;
using System.Windows.Forms;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Text;

namespace Dz
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
                foreach (string word in words)
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
            if (list.Count == 0)
                MessageBox.Show("Файл не прочитан либо не содержит текст.");
            else if (textBox1.Text.Length == 0)
                MessageBox.Show("Введите слово для поиска.");
            else if (textBox2.Text.Length == 0)
                MessageBox.Show("Введите максимальное расстояние.");
            else if (textBox3.Text.Length == 0)
                MessageBox.Show("Введите число потоков.");
            else
            {
                if (int.TryParse(textBox2.Text, out int max))
                {
                    if (int.TryParse(textBox3.Text, out int ThreadCount))
                    {
                        listBox1.BeginUpdate();
                        listBox1.Items.Clear();
                        sw.Reset();
                        sw.Start();
                        List<ParallelSearchResult> Result = new List<ParallelSearchResult>();
                        List<MinMax> arrayDivList = SubArrays.DivideSubArrays(0, list.Count, ThreadCount);
                        int count = arrayDivList.Count;
                        Task<List<ParallelSearchResult>>[] tasks = new Task<List<ParallelSearchResult>>[count];
                        for (int i = 0; i < count; i++)
                        {
                            List<string> tempTaskList = list.GetRange(arrayDivList[i].Min, arrayDivList[i].Max - arrayDivList[i].Min);
                            tasks[i] = new Task<List<ParallelSearchResult>>(ParallelSearchThreadParam.ArrayThreadTask, new ParallelSearchThreadParam()
                            {
                                tempList = tempTaskList,
                                maxDist = max,
                                ThreadNum = i,
                                wordPattern = textBox1.Text
                            });
                            tasks[i].Start();
                        }
                        Task.WaitAll(tasks);
                        //foreach (string item in list)
                        //{
                        //if (Lab5.Distance.Levenshtein(textBox1.Text, item) <= max)
                        //listBox1.Items.Add(item);
                        //}
                        for (int i = 0; i < count; i++)
                            Result.AddRange(tasks[i].Result);
                        sw.Stop();
                        label2.Text = "Время поиска, мс: " + sw.ElapsedMilliseconds.ToString();
                        label6.Text = "Вычисленное число потоков: " + count.ToString();
                        foreach (var x in Result)
                        {
                            string temp = x.word + "(расстояние=" + x.dist.ToString() + " поток=" + x.ThreadNum.ToString() + ")";
                            listBox1.Items.Add(temp);
                        }
                        listBox1.EndUpdate();
                    }
                    else
                    {
                        MessageBox.Show("Ошибка ввода числа потоков.");
                    }
                }
                else
                {
                    MessageBox.Show("Ошибка ввода максимального расстояния.");
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string TempReportFileName = "Report_" + DateTime.Now.ToString("dd_MM_yyyy_hhmmss");
            SaveFileDialog fd = new SaveFileDialog();
            fd.FileName = TempReportFileName;
            fd.DefaultExt = ".html";
            fd.Filter = "HTML Reports|*.html";
            if (fd.ShowDialog() == DialogResult.OK)
            {
                string ReportFileName = fd.FileName;
                StringBuilder b = new StringBuilder();
                b.AppendLine("<html>");

                b.AppendLine("<head>"); 
                b.AppendLine("<meta http-equiv='Content-Type' content='text/html; charset=UTF-8'/>"); 
                b.AppendLine("<title>" + "Отчет: " + ReportFileName + "</title>"); 
                b.AppendLine("</head>");

                b.AppendLine("<body>");

                b.AppendLine("<h1>" + "Отчет: " + ReportFileName + "</h1>"); 
                b.AppendLine("<table border='1'>");

                b.AppendLine("<tr>"); 
                b.AppendLine("<td>Слово для поиска</td>"); 
                b.AppendLine("<td>" + this.textBox1.Text + "</td>"); 
                b.AppendLine("</tr>");

                b.AppendLine("<tr>"); 
                b.AppendLine("<td>Максимальное расстояние для нечеткого поиска</td>"); 
                b.AppendLine("<td>" + this.textBox2.Text + "</td>"); 
                b.AppendLine("</tr>");

                b.AppendLine("<tr>"); b.AppendLine("<td>Время поиска</td>"); 
                b.AppendLine("<td>" + this.textBox3.Text + "</td>"); 
                b.AppendLine("</tr>");

                b.AppendLine("<tr valign='top'>"); 
                b.AppendLine("<td>Результаты поиска</td>"); 
                b.AppendLine("<td>"); 
                b.AppendLine("<ul>");

                foreach (var x in this.listBox1.Items) 
                    b.AppendLine("<li>" + x.ToString() + "</li>");
                b.AppendLine("</ul>"); 
                b.AppendLine("</td>"); 
                b.AppendLine("</tr>");

                b.AppendLine("</table>");

                b.AppendLine("</body>"); 
                b.AppendLine("</html>");

                File.AppendAllText(ReportFileName, b.ToString());

                MessageBox.Show("Отчет сформирован. Файл: " + ReportFileName);
            }
        }
    }
}
