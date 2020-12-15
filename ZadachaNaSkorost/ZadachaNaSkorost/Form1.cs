using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZadachaNaSkorost
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public double x, y, V0, V0x, V0y, Hmax, Lmax, Tmax, h0, alpha, t, n, n0x, n0y;
        public int W, H, fullW, fullH;


        private void button3_Click(object sender, EventArgs e)
        {
            Graphics cl = pictureBox1.CreateGraphics();
            Pen Pent;
            Pent = new Pen(Color.Black);
            Pent.Width = 0.2F;
            fullW = pictureBox1.Width;
            fullH = pictureBox1.Height;
            while (x0 < fullW)
            {
                Point TX1, TX2;
                TX1 = new Point(x0 + 15, fullH);
                TX2 = new Point(x0 + 15, 0);
                cl.DrawLine(Pent, TX1, TX2);
                x0 += 15;
            }
            while (y0 < fullH)
            {
                Point TY1, TY2;
                TY1 = new Point(0, fullH - y0);
                TY2 = new Point(fullW, fullH - y0);
                cl.DrawLine(Pent, TY1, TY2);
                y0 += 15;
            }
            cl.Dispose();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            x = 0; y = 0; t = 0;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Input();
            Calc();
            Output();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            fullW = pictureBox1.Width;
            fullH = pictureBox1.Height;
            Graphics spot3 = Form1.ActiveForm.CreateGraphics();
            Brush Pen3 = new SolidBrush(Color.White);
            spot3.FillRectangle(Pen3, 0, 0, fullW, fullH);
            x0 = 0; y0 = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Graphics osi = pictureBox1.CreateGraphics();
            Pen Pen;
            Pen = new Pen(Color.Green);
            Pen.Width = 3;
            fullW = pictureBox1.Width;
            fullH = pictureBox1.Height;
            Point KX1, KX2;
            KX1 = new Point(0, 0);
            KX2 = new Point(fullH, 0);
            osi.DrawLine(Pen, KX1, KX2);
            Point KY1, KY2;
            KY1 = new Point(0, 0);
            KY2 = new Point(0, fullW);
            osi.DrawLine(Pen, KY1, KY2);
            osi.Dispose();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Graph();
            t += 0.01;
            x = Math.Round(n0x * t);
            y = Math.Round(h0 + (n0y * t) - (9.81 * t * t) / 2);
        }


        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        public void Input()
        {

            try
            {
                V0 = Convert.ToDouble(textBox1.Text);
                alpha = Convert.ToDouble(textBox2.Text);
                h0 = Convert.ToDouble(textBox3.Text);
            }

            finally { button7.Enabled = true; }
            n = V0;
            while (n > 100)
            {
                n /= 2;
                n0x /= 2;
                n0y /= 2;
            }
        }
        public void Calc()
        {
            V0x = V0 * Math.Cos(alpha * Math.PI / 180);
            V0y = V0 * Math.Sin(alpha * Math.PI / 180);
            n0x = n * Math.Cos(alpha * Math.PI / 180);
            n0y = n * Math.Sin(alpha * Math.PI / 180);
            Hmax = h0 + (V0y * V0y) / (2 * 9.81);
            Tmax = (V0y + Math.Sqrt(V0y * V0y + 2 * 9.81 * h0)) / 9.81;
            Lmax = V0x * Tmax;
        }
        public void Output()
        {
            textBox4.Text = Convert.ToString(Hmax);
            textBox5.Text = Convert.ToString(Lmax);
            textBox6.Text = Convert.ToString(Tmax);
        }




        public void Graph()
        {
            Graphics spot = Form1.ActiveForm.CreateGraphics();
            Pen Pen2; Pen2 = new Pen(Color.Red);
            Pen2.Width = 2;
            spot.DrawLine(Pen2, Convert.ToInt32(x - 1), Convert.ToInt32(fullH - y - 1), Convert.ToInt32(x + 1), Convert.ToInt32(fullH - y + 1));
        }
        public int x0, y0;
       
    }
}
