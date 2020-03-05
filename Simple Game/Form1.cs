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
        int[,] A = new int[20, 2];
        bool[] F = new bool[20];
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyValue){
                /*case ((int)Keys.Space):
                    pink();
                    break;
                */
                case ((int)Keys.W):
                    Win();
                    break;
                case ((int)Keys.S):
                    label1.Hide();
                    pictureBox1.Show();
                    a();
                    break;
                case ((int)Keys.Space):
                    Catch();
                    break;
                case ((int)Keys.R):
                    label1.Hide();
                    pictureBox1.Show();
                    //lost = true;
                    Restart();
                    break;
                case ((int)Keys.Left):
                    k = -k;
                    break;
            }
        }
        private int Abs(int a)
        {
            if (a < 0)
            {
                a = -a;
            }
            return a;
        }
        private void Form1_Load(object sender, EventArgs e)
        { }
        System.Windows.Forms.Timer aTimer = new System.Windows.Forms.Timer();
        //private static System.Timers.Timer aTimer;
        //private static System.Timers.Timer bTimer;
        int x = 15, y = 15, k = 5;
        bool lost = true;
        public void a()
        {
            Restart();
            SetTimer();
            //Console.WriteLine("\nPress the Enter key to exit the application...\n");
            //Console.WriteLine("The application started at {0:HH:mm:ss.fff}", DateTime.Now);
            //Console.ReadLine();
            //aTimer.Stop();
            //aTimer.Dispose();
            //bTimer.Stop();
            //bTimer.Dispose();
        }
        private void SetTimer()
        {
            // Create a timer with a two second interval.
            aTimer.Tick += new EventHandler(Event1);
            aTimer.Interval = 10;
            aTimer.Start();
            //bTimer = new System.Timers.Timer(10000);
            // Hook up the Elapsed event for the timer. 
            //aTimer.Elapsed += Event1;
            //aTimer.AutoReset = false;
            //aTimer.Enabled = true;
            //bTimer.Elapsed += Event1;
            //bTimer.AutoReset = true;
            //bTimer.Enabled = true;
        }
        /*private void SetbTimer()
        {
            bTimer = new System.Timers.Timer(1000);
            bTimer.Elapsed += Event1;
            bTimer.AutoReset = true;
            bTimer.Enabled = true;
        }*/
        Color color = Color.Black;
        private void Run()
        {
            a();
            /*
            Bitmap screen = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            int q, w;
            for (q = 0; q < pictureBox1.Width; q++)
            {
                for (w = 0; w < pictureBox1.Height; w++)
                {
                    screen.SetPixel(q, w, color);
                }
            }
            pictureBox1.Image = (Image)screen;
            */
        }
        private void pink() {
            int q, w;
            //Bitmap screen = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            for (q = 0; q < pictureBox1.Width; q++)
            {
                for (w = 0; w < pictureBox1.Height; w++)
                {
                    screen.SetPixel(q, w, Color.HotPink);          
                }
            }
            pictureBox1.Image = (Image)screen;
        }
        /*private void Move(Object source, ElapsedEventArgs e)
        {
            int q, w, r;
            x = x + 60;
            if (x >= pictureBox1.Width)
            {
                x = 1;
                y = y + 60;
            }
            if (y > 500)
            {
                Ifwin();
            }
            else
            {
                for (q = 0; q < pictureBox1.Width; q++)
                {
                    for (w = 0; w < pictureBox1.Height; w++)
                    {
                        Color color = Color.White;
                        for (r = 0; r < 20; r++)
                        {
                            if (Abs(A[r, 0] - q) < 10 && Abs(A[r, 1] - w) < 10)
                            {
                                if (F[r])
                                color = Color.Black;
                            }
                        }
                        if (Abs(x - q) < 30 && Abs(w - y) < 30)
                        {
                            color = Color.HotPink;
                        }
                        screen.SetPixel(q, w, color);
                    }
                }
            }  
            pictureBox1.Image = (Image)screen;
            aTimer.Enabled = true;
        }*/
        private void NewMove()
        {
            int q, w, r, x1, y1;
            x1 = x;
            y1 = y;
            x = x + k;
            if (x >= pictureBox1.Width)
            {
                x = 1;
                y = y + 60;
            }
            if (x < 0)
            {
                x = pictureBox1.Width - 1;
                y = y + 60;
            }
            if (y > 500)
            {
                Ifwin();
            }
            else
            {
                for (q = Math.Max(x1 - 29, 1); q <= Math.Min(x1 + 29, 499); q++)
                {
                    for (w = Math.Max(y1 - 30, 1); w <= Math.Min(y1 + 30, 499); w++)
                    {
                        screen.SetPixel(q, w, Color.White);
                    }
                }
                for (r = 0; r < 20; r++)
                {
                    for (q = Math.Max(A[r, 0] - 10, 1); q <= Math.Min(A[r, 0] + 10, 499); q++)
                    {
                        for (w = Math.Max(A[r, 1] - 10, 1); w <= Math.Min(A[r, 1] + 10, 499); w++)
                        {
                            if (F[r])
                            {
                                screen.SetPixel(q, w, Color.White);
                            }
                        }
                    }
                }
                for (r = 0; r < 20; r++)
                {
                    for (q = Math.Max(A[r, 0] - 10, 1); q <= Math.Min(A[r, 0] + 10, 499); q++)
                    {
                        for (w = Math.Max(A[r, 1] - 10, 1); w <= Math.Min(A[r, 1] + 10, 499); w++)
                        {
                            if (!F[r])
                            {
                                screen.SetPixel(q, w, Color.Black);
                            }
                        }
                    }
                }
                for (q = Math.Max(x - 29, 1); q < Math.Min(x + 30, 499); q++)
                {
                    for (w = Math.Max(y - 29, 1); w < Math.Min(y + 30, 499); w++)
                    {
                        screen.SetPixel(q, w, Color.HotPink);
                    }
                }
                pictureBox1.Image = screen;
                aTimer.Start();
            }
        }
        private void Catch()
        {
            int q;
            bool did = false;
            for (q = 0; q < 20; q++)
            {
                if (Abs(x - A[q, 0]) < 60 && Abs(y - A[q, 1]) < 60 && !F[q])
                {
                    did = true;
                    F[q] = true;
                }
            }
            if (!did)
            {
                lost = true;
            }
        }
        private void Restart()
        {
            x = 15;
            y = 15;
            int q, w;
            for (q = 0; q < 20; q++)
            {
                F[q] = false;
            }
            for (q = 1; q < 499; q++)
            {
                for (w = 1; w < 499; w++)
                {
                    screen.SetPixel(q, w, Color.White);
                }
            }
            pictureBox1.Image = screen;
            lost = false;
            Reshuffle();
            aTimer.Start() ;
        }
        private void Ifwin()
        {
            int q;
            aTimer.Stop();
            bool win = true;
            for (q = 0; q < 20; q++)
            {
                if (!F[q])
                {
                    win = false;
                    break;
                }
            }
            if (win)
            {
                Win();
            }
            else
            {
                Restart();
            }
        }
        private void Win()
        {
            int q, w;
            for (q = 0; q < 500; q++)
            {
                for (w = 0; w < 500; w++)
                {
                    screen.SetPixel(q, w, Color.White);
                }
            }
            pictureBox1.Hide();
            label1.Show();
            k = k + 2;
        }
        private void Reshuffle()
        {
            int q, w;
            for (q = 0; q < 20; q++)
            {
                for (w = 0; w < 2; w++)
                {
                    A[q, w] = random.Next(10, 450);
                }
            }
        }
        private void Event1(Object source, EventArgs e)
        {
            if (lost)
            {
                Restart();
            }
            else
            {
                NewMove();
            }
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
