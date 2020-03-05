using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Timers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using System.Windows.Media;

namespace WindowsFormsApp3
{
    //int sz = 1000;
    public partial class Form1 : Form
    {
        Bitmap screen;
        public Form1()
        {
            InitializeComponent();
            this.KeyDown += Form1_KeyDown;
            //this.WindowState = FormWindowState.Maximized;
            this.Size = new Size(1000, 700);
            pictureBox1.Size =
                new Size(this.Size.Width, this.Size.Height);
            pictureBox1.MouseClick += PictureBox1_MouseClick;
            screen = new Bitmap(this.Size.Width, this.Size.Height);
            label1.Hide();
            paint();
        }

        private void PictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            k /= 1.3;
            int cx = Cursor.Position.X;
            cx -= 110;
            int cy = Cursor.Position.Y;
            cy -= 10;
            sx = ((cx - 500) * k + sx) * 1.0;
            sy = ((cy - 350) * k + sy) * 1.0;
            paint();
        }

        Random random = new Random();
        //int[,] A = new int[20, 2];
        //bool[] F = new bool[20];
        int sz = 1000, szy = 700;
        double sx = 0, sy = 0, k = 0.8;
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyValue)
            {
                /*case ((int)Keys.Space):
                    pink();
                    break;
                */
                case ((int)Keys.P):
                    paint();
                    break;
                case ((int)Keys.Space):
                    k /= 1.3;
                    //sx *= 1.1;
                    //sy *= 1.1;
                    //paint();
                    //painting();
                    break;
                case ((int)Keys.Enter):
                    k *= 1.3;
                    //sx /= 1.1;
                    //sy /= 1.1;
                    //paint();
                    break;
                case ((int)Keys.Left):
                    sx += -100 * k;
                    //paint();
                    break;
                case ((int)Keys.Right):
                    sx += 100 * k;
                    //paint();
                    break;
                case ((int)Keys.Up):
                    sy += -100 * k;
                    //paint();
                    break;
                case ((int)Keys.Down):
                    sy -= -100 * k;
                    //paint();
                    break;
            }
        }
        public class vec
        {
            public double a, b;
            public vec(double a1, double a2)
            {
                a = a1;
                b = a2;
            }
            public vec Umn(vec a1, vec b1)
            {
                return new vec(a1.a * b1.a - a1.b * b1.b, a1.a * b1.b + b1.a * a1.b);
            }
            public double abs(vec a1)
            {
                return Math.Sqrt(a1.a * a1.a + a1.b * a1.b);
            }
        };
        vec con = new vec(-0.8, 0.16);
        /*public vec Umn(vec a, vec b)
        {
            return new vec(a.a * b.b, b.a * a.b);
        }*/
        public vec plus(vec a, vec b)
        {
            return new vec(a.a + b.a, a.b + b.b);
        }
        private double Abs(double a)
        {
            if (a < 0)
            {
                a = -a;
            }
            return a;
        }
        public int norm(int x)
        {
            if (x > 255)
            {
                return 255;
            }
            if (x < 0)
            {
                return 0;
            }
            return x;
        }
        public Color getcolor(double x, double y)
        {
            vec z = new vec(x, y);
            z = plus(z.Umn(z, z), con);
            int q;
            for (q = 0; q < 160; q++)
            {
                double asb = z.abs(z);
                //if (q > )
                if (asb > 2)
                {
                    if (q > 80)
                    {
                        return Color.FromArgb(255 - norm(100 - q * 4), 255 - norm(100 + q * 4), 255 - norm(100 + q * 6));
                    }
                    return Color.FromArgb(norm(100 - q * 4), norm(100 + q * 4), norm(100 + q * 6)); 
                }
                z = plus(z.Umn(z, z), con);
            }
            return Color.FromArgb(180, 15, 120);
        }

        public void paint()
        {
            int q, w;
            for (q = 0; q < sz; q++)
            {
                for (w = 0; w < szy; w++)
                {
                    Color color = getcolor(((q - 500) * k + sx) * 1.0/ 250, ((w - 350)* k + sy) * 1.0/ 175);
                    //if (color != Color.)
                    screen.SetPixel(q, w, color);
                }
            }
            pictureBox1.Image = (Image)screen;
        }
        private void Form1_Load(object sender, EventArgs e)
        { }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
