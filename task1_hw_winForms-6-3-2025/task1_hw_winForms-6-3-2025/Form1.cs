using System;
using System.IO;
using System.Windows.Forms;

namespace task1_hw_winForms_6_3_2025
{
    public partial class Form1 : Form
    {
        private ProgressBar progressBar1;
        private ListBox listBox1;
        private Button button1;

        public Form1()
        {
            this.Text = "Прогрес Читання Файлу";
            this.Size = new System.Drawing.Size(600, 400);

            progressBar1 = new ProgressBar
            {
                Location = new System.Drawing.Point(20, 20),
                Size = new System.Drawing.Size(540, 30)
            };

            listBox1 = new ListBox
            {
                Location = new System.Drawing.Point(20, 60),
                Size = new System.Drawing.Size(540, 250)
            };

            button1 = new Button
            {
                Text = "Читати файл",
                Location = new System.Drawing.Point(20, 320),
                Size = new System.Drawing.Size(100, 30)
            };
            button1.Click += Button1_Click;

            this.Controls.Add(progressBar1);
            this.Controls.Add(listBox1);
            this.Controls.Add(button1);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string filePath = "test_file.txt";

            if (File.Exists(filePath))
            {
                var lines = File.ReadAllLines(filePath);
                progressBar1.Maximum = lines.Length;
                progressBar1.Value = 0;
                listBox1.Items.Clear();

                foreach (var line in lines)
                {
                    listBox1.Items.Add(line);
                    progressBar1.Value++;
                    Application.DoEvents();
                }

                MessageBox.Show("Файл успішно прочитаний!");
            }
            else
            {
                MessageBox.Show("Файл не знайдено!");
            }
        }
    }
}
