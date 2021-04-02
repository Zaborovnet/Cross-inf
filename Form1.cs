using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using MetroFramework;
using System.Diagnostics;
using System.Threading;
using System.Collections;
using System.IO;
using System.Threading;



namespace Cross_inf
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void metroLabel1_Click(object sender, EventArgs e)
        {

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            Test1.GlobalVar = openFileDialog1.FileName;
            // читаем файл в строку
            Test1.GlobalVar = System.IO.File.ReadAllText(Test1.GlobalVar);

            MessageBox.Show("Файл открыт");
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            //Создаем первый поток
            Thread thread1 = new Thread(watch);
            thread1.Start();
            metroLabel1.Text = "";
            //Создаем второй поток
            Thread thread2 = new Thread(osn);
            thread2.Start();
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();


            var groups = SwimParts(Test1.GlobalVar, 3)
                .GroupBy(str1 => str1);
            using (StringWriter stringWriter = new StringWriter())
            {
                Console.SetOut(stringWriter);
                Console.WriteLine(string.Join
               (
                   Environment.NewLine,
                   groups.OrderByDescending(gr => gr.Count()).Take(10).Select(gr => $"\"{gr.Key}\" встретилось {gr.Count()} раз")
               ));
                string allConsoleOutput = stringWriter.ToString();
                metroLabel1.Text += allConsoleOutput;
            }

            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            Test2.GlobalVar = String.Format("{0:00} часов, {1:00} минут, {2:00} секунд, {3:000} миллисекунд",
                        ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds);

            using (StringWriter stringWriter = new StringWriter())
            {
                Console.SetOut(stringWriter);
                Console.WriteLine("Время выполнения программы: " + Test2.GlobalVar);
                string allConsoleOutput = stringWriter.ToString();
                metroLabel2.Text = allConsoleOutput;
            }

        }
        public static IEnumerable<string> SwimParts(string source, int length)
        {
            for (int i = length; i <= source.Length; i++)
                yield return source.Substring(i - length, length);
        }
        static void watch()
        {
            //пока нет идей, что сюда вставить
        }
        public void osn()
        {

            //пока нет идей, что сюда вставить

        }
        static class Test1
        {
            private static string _globalVar;

            public static string GlobalVar
            {
                get { return _globalVar; }
                set { _globalVar = value; }
            }
        }

        static class Test2
        {
            private static string _globalVar;

            public static string GlobalVar
            {
                get { return _globalVar; }
                set { _globalVar = value; }
            }
        }

        static class Test3
        {
            private static string _globalVar;

            public static string GlobalVar
            {
                get { return _globalVar; }
                set { _globalVar = value; }
            }
        }
        private void metroTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void metroTextBox2_Click(object sender, EventArgs e)
        {

        }

        private void metroLabel1_Click_1(object sender, EventArgs e)
        {

        }

        private void metroLabel1_Click_2(object sender, EventArgs e)
        {

        }

        private void metroLabel2_Click(object sender, EventArgs e)
        {

        }
    }
}
