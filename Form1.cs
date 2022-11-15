using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ScrollBarProgress
{
    public partial class Form1 : Form
    {
        Point p;
        public Form1()
        {
            InitializeComponent();
            textBox1.ScrollBars = ScrollBars.Vertical;
            textBox1.MouseWheel += MyMouseWheel;
        }
        private void Basic_Window_MouseDown(object sender, MouseEventArgs e)
        {
            p = new Point(e.X, e.Y);
        }
        private void Basic_Window_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Left += e.X - p.X;
                Top += e.Y - p.Y;
            }
        }
        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }
        private void Read_File()
        {
            try
            {
                if (File.Exists("test.txt"))
                    using (StreamReader F = new StreamReader("test.txt"))
                    {
                        textBox1.Text = F.ReadToEnd();
                    }
            }
            catch (Exception E) { MessageBox.Show(E.Message); }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void progressBar1_Click(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            Read_File();
        }
        private void MyMouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                progressBar1.Maximum = textBox1.Lines.Length-1;
                if (progressBar1.Value + e.Delta / 40 * -1 >= progressBar1.Minimum)
                    progressBar1.Value += e.Delta / 40 * -1;
            }
            else if (e.Delta < 0)
            {
                progressBar1.Maximum = textBox1.Lines.Length-1;
                if (progressBar1.Value + e.Delta / 40 * -1 <= progressBar1.Maximum)
                    progressBar1.Value += e.Delta / 40 * -1;
            }
        }
    }
}
