using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Drawing2D;

namespace WindowsFormsApp4
{
    public partial class Form1 : Form
    {
        // Объявляем объект "g" класса Graphics
        Graphics g;
        string filename = @"Strings.txt";
        string[] sm = {

                        "First line", "Second line", "Third line",
                        "Fourth line", "Fifth line", "Sixth line",
                        "Seventh line", "Eighth line", "Ninth line",
                        "Tenth line", "Eleven line"
        };
        public Form1()
        {
            // Предоставляем объекту "g" класса Graphics возможность
            // рисования на pictureBox1:
            InitializeComponent();
            g = pictureBox1.CreateGraphics();
        }
        private void Save_Click(object sender, EventArgs e)
        {
            StreamWriter f = new StreamWriter(new FileStream(filename,
            FileMode.Create, FileAccess.Write));
            foreach (string s in sm) { f.WriteLine(s); }
            f.Close();
            MessageBox.Show("11 строк записано в файл !");
        }
        private void Clear_Click(object sender, EventArgs e)
        {
            g.Clear(Color.FromArgb(255, 255, 255));
            File.Delete(filename);
            MessageBox.Show("Файл Strings.txt удалён !");
        }
        private void Open_Click(object sender, EventArgs e)
        {
            int k = 0;
            // Чтение строк из файла
            try
            {
                StreamReader f = new StreamReader(new FileStream(filename,
                FileMode.Open, FileAccess.Read));
                for (int i = 0; i < 11; i++) { sm[i] = f.ReadLine(); }
                f.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            // **** Отображение строк разными шрифтами и выравниванием **
            pictureBox1.BackColor = Color.FromName("Azure");
            pictureBox1.Refresh();
            for (int i = 0; i < 12; i++)
            {
                // Отображение первой группы строк
                if ((i >= 0) && (i < 8))
                {
                    Font fn = new Font("Magneto", 18, FontStyle.Bold);
                    StringFormat sf =
                    (StringFormat)StringFormat.GenericTypographic.Clone();
                    sf.Alignment = StringAlignment.Center;
                    sf.LineAlignment = StringAlignment.Far;
                    g.DrawString(sm[i], fn, Brushes.Navy,
                    new RectangleF(0, 0 + i * 40, pictureBox1.Size.Width - 10, pictureBox1.Size.Height - 650), sf);
                    fn.Dispose();
                }
                // Отображение второй группы строк
                if ((i >= 8) && (i < 10))
                {
                    //k = i - 9;
                    Font fn = new Font("Perpetua", 24, FontStyle.Italic);
                    StringFormat sf =
                    (StringFormat)StringFormat.GenericTypographic.Clone();
                    sf.FormatFlags = StringFormatFlags.DirectionVertical;
                    sf.Alignment = StringAlignment.Far;
                    sf.LineAlignment = StringAlignment.Near;
                    g.DrawString(sm[i], fn, Brushes.Magenta,
                    new RectangleF(10 + i * 35, 150, pictureBox1.Size.Width - 1000, pictureBox1.Size.Height- 500), sf);
                    fn.Dispose();
                }
                // Отображение третьей группы строк
                if (i == 10)
                {
                    Font fn = new Font("Cambria", 40, FontStyle.Regular);
                    StringFormat sf =
                    (StringFormat)StringFormat.GenericTypographic.Clone();
                    sf.Alignment = StringAlignment.Near;
                    sf.LineAlignment = StringAlignment.Center;
                    g.DrawString(sm[i], fn, Brushes.Red,
                    new RectangleF(500, 450 + i * 1, pictureBox1.Size.Width - 1000, pictureBox1.Size.Height - 700), sf);
                    fn.Dispose();
                }
            }
        }
    }
}