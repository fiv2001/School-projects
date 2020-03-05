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

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        bool f = false;
        Bitmap screen;
        public Form1()
        {
            InitializeComponent();
            this.KeyDown += Form1_KeyDown;
            //this.WindowState = FormWindowState.Maximized;
            this.Size = new Size(500, 500);
            pictureBox1.Size =
                new Size(this.Size.Width, this.Size.Height);
            screen = new Bitmap(this.Size.Width, this.Size.Height);
            label1.Text = "YOU WIN";
            label1.Font = new Font(FontFamily.GenericMonospace, 40);
            label1.Location = new Point(250 - label1.Size.Width / 2, 240 - label1.Height / 2);
            label1.Hide();
        }
        Random random = new Random();
        //int[,] A = new int[20, 2];
        //bool[] F = new bool[20];
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyValue)
            {
                /*case ((int)Keys.Space):
                    pink();
                    break;
                */
                case ((int)Keys.S):
                    init();
                    painting();
                    break;
                case ((int)Keys.Space):
                    expand();
                    //painting();
                    break;
            }
        }
        double pi = 3.1416;
        int cnt = 0;
        private double Abs(double a)
        {
            if (a < 0)
            {
                a = -a;
            }
            return a;
        }
        int inf = 100000;
        private void Form1_Load(object sender, EventArgs e)
        { }
        public struct seg
        {
            public int x1;
            public int y1;
            public int x2;
            public int y2;
            public seg(int xp1, int yp1, int xp2, int yp2)
            {
                x1 = xp1;
                y1 = yp1;
                x2 = xp2;
                y2 = yp2;
            }
        }
        seg[] A = new seg[1000000];
        int i = 3;
        /*int[] X1 = new int[10000];
        int[] Y1 = new int[10000];
        int[] X2 = new int[10000];
        int[] Y2 = new int[10000];
        X1[0] = 5;*/
        private void init()
        {
            seg a = new seg(50, 250, 350, 423);
            seg b = new seg(350, 423, 350, 77);
            seg c = new seg(350, 77, 50, 250);
            A[0] = a;
            A[1] = b;
            A[2] = c;
        }
        private void painting()
        {
            int q, w;
            for (q = 0; q < 500; q++)
            {
                for (w = 0; w < 500; w++)
                {
                    screen.SetPixel(q, w, Color.White);
                }
                pictureBox1.Image = (Image)screen;
            }
            for (q = 0; q < i; q++)
            {
                double k;
                if (A[q].x2 == A[q].x1) {
                    k = 0;
                    for (w = Math.Min(A[q].y1, A[q].y2); w <= Math.Max(A[q].y2, A[q].y1); w++)
                    {
                        screen.SetPixel(A[q].x2, w, Color.HotPink);
                    }
                    continue;
                }
                else {
                    k = (A[q].y2 - A[q].y1) * 1.0 / (A[q].x2 - A[q].x1);
                }
                bool f = false;
                if (A[q].x1 > A[q].x2)
                {
                    f = true;
                    int x = A[q].x1;
                    A[q].x1 = A[q].x2;
                    A[q].x2 = x;
                    x = A[q].y1;
                    A[q].y1 = A[q].y2;
                    A[q].y2 = x;
                }
                for (w = A[q].x1; w <= A[q].x2; w++)
                {
                    int y = (int)((w - A[q].x1) * k + A[q].y1);
                    screen.SetPixel(w, y, Color.HotPink);
                }
                if (A[q].y1 > A[q].y2)
                {
                    f = !f;
                    int x = A[q].x1;
                    A[q].x1 = A[q].x2;
                    A[q].x2 = x;
                    x = A[q].y1;
                    A[q].y1 = A[q].y2;
                    A[q].y2 = x;
                }
                for (w = A[q].y1; w < A[q].y2; w++)
                {
                    int x = (int)((w - A[q].y1) * 1.0 / k + A[q].x1);
                    screen.SetPixel(x, w, Color.HotPink);
                }
                if (f)
                {
                    //f = true;
                    int x = A[q].x1;
                    A[q].x1 = A[q].x2;
                    A[q].x2 = x;
                    x = A[q].y1;
                    A[q].y1 = A[q].y2;
                    A[q].y2 = x;
                }
            }
        }
        private void expand()
        {
            if (cnt > 7)
            {
                return;
            }
            cnt++;
            int q;
            int i2 = i;
            for (q = 0; q < i2; q++)
            {
                double k;
                if (A[q].x1 == A[q].x2)
                {
                    k = -inf;
                }
                else
                {
                    k = (A[q].y2 - A[q].y1) * 1.0/ (A[q].x2 - A[q].x1);
                }
                seg a, b, c, d;
                a.x1 = A[q].x1;
                a.y1 = A[q].y1;
                int x1 = (A[q].x1 + (A[q].x2 - A[q].x1) / 3);
                int y1 = (A[q].y1 + (A[q].y2 - A[q].y1) / 3);
                a.x2 = (A[q].x1 + (A[q].x2 - A[q].x1) / 3);
                a.y2 = (A[q].y1 + (A[q].y2 - A[q].y1) / 3);
                int x2 = (A[q].x1 + 2 * (A[q].x2 - A[q].x1) / 3);
                int y2 = (A[q].y1 + 2 * (A[q].y2 - A[q].y1) / 3);
                /*double ang = Math.Atan2(A[q].x2 - A[q].x1, A[q].y2 - A[q].y1);
                double ang1 = ang + pi / 3;
                double ang2 = ang - pi / 3;
                double k1 = Math.Tan(ang1);
                double k2 = Math.Tan(ang2);*/
                double len = ((A[q].y2 - A[q].y1) * (A[q].y2 - A[q].y1) + (A[q].x2 - A[q].x1) * (A[q].x2 - A[q].x1)) / 9;
                double h = (3 * 1.0) / 4 * len;
                double mx = (A[q].x1 + A[q].x2) / 2;
                double my = (A[q].y1 + A[q].y2) / 2;
                double k1;
                if (k == 0)
                {
                    k1 = 100000;
                }
                else
                {
                    k1 = -1 / k;
                }
                double xx = -Math.Sqrt(h / (k1 * k1 + 1));
                if ((A[q].x2 >= A[q].x1 && A[q].y2 < A[q].y1) || (A[q].x1 >= A[q].x2 && A[q].y2 < A[q].y1))
                {
                    xx = -xx;
                }
                double yy = xx * k1;
                int x3 = (int)(xx + mx);
                int y3 = (int)(yy + my);
                b.x1 = x1; b.y1 = y1; b.x2 = x3; b.y2 = y3;
                c.x1 = x3; c.y1 = y3; c.x2 = x2; c.y2 = y2;
                d.x1 = x2; d.y1 = y2; d.x2 = A[q].x2; d.y2 = A[q].y2;
                A[q] = a;
                A[i] = b;
                A[i + 1] = c;
                A[i + 2] = d;
                i += 3;
                //painting();
            }
            painting();
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
