using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Графика_8
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        const int n = 5; // количество эллипсов, которые рисует программа
        const int RotationSpeed = 10; // Скорость вращения фигуры
        Graphics G;
        int Angle = 360 / n / 2;
        int[] RotateAngles = new int[n];
        Rectangle R = new Rectangle(100, 100, 60, 120);
        Pen RPen = new Pen(Color.Red, 2);
        Point Center = new Point(130, 160);

        private void button1_Click(object sender, EventArgs e)
        {
            G = this.CreateGraphics();
            G.Clear(Color.White);
            for (int i = 0; i < n; i++)
            {
                Matrix M = new Matrix();
                GraphicsPath P = new GraphicsPath();
                P.AddEllipse(R);
                M.RotateAt(Angle * i, Center);
                RotateAngles[i] = (Angle * i);
                P.Transform(M);
                G.DrawPath(RPen,P);
            }
        }

        bool flag = false;

        private void button2_Click(object sender, EventArgs e)
        {
            if (!flag)
            {
                timer1.Start();
                flag = true;
            }
            else
            {
                timer1.Stop();
                flag = false;
            }
        }



        private void timer1_Tick(object sender, EventArgs e)
        {
            G = this.CreateGraphics();
            G.Clear(Color.White);

            for (int i = 0; i < n; i++)
            {
                Matrix M = new Matrix();
                GraphicsPath P = new GraphicsPath();
                P.AddEllipse(R);
                M.RotateAt(RotateAngles[i] + 1, Center);
                RotateAngles[i]+= RotationSpeed;
                P.Transform(M);
                G.DrawPath(RPen, P);
            }
        }
    }
}
