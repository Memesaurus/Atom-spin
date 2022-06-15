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

        class Figure
        {
            public int n;
            public int RotationSpeed;
            public int Angle;
            public int[] RotateAngles;
        }

        Figure figure = new Figure();
        Graphics G;
        Rectangle R = new Rectangle(100, 100, 60, 120);
        Pen RPen = new Pen(Color.Red, 2);
        Point Center = new Point(130, 160);

        private void button1_Click(object sender, EventArgs e)
        {
            figure.n = Convert.ToInt32(numOfElementsTextBox.Text);
            figure.RotationSpeed = Convert.ToInt32(speedTextBox.Text);
            figure.Angle = 360/ Convert.ToInt32(numOfElementsTextBox.Text) / 2;
            figure.RotateAngles = new int[Convert.ToInt32(numOfElementsTextBox.Text)];
            G = this.CreateGraphics();
            G.Clear(Color.White);
            for (int i = 0; i < figure.n; i++)
            {
                Matrix M = new Matrix();
                GraphicsPath P = new GraphicsPath();
                P.AddEllipse(R);
                M.RotateAt(figure.Angle * i, Center);
                figure.RotateAngles[i] = (figure.Angle * i);
                P.Transform(M);
                G.DrawPath(RPen,P);
            }
        }

        bool flag = false;

        private void button2_Click(object sender, EventArgs e)
        {
            figure.RotationSpeed = Convert.ToInt32(speedTextBox.Text);
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

            for (int i = 0; i < figure.n; i++)
            {
                Matrix M = new Matrix();
                GraphicsPath P = new GraphicsPath();
                P.AddEllipse(R);
                M.RotateAt(figure.RotateAngles[i] + 1, Center);
                figure.RotateAngles[i]+= figure.RotationSpeed;
                P.Transform(M);
                G.DrawPath(RPen, P);
            }
        }
    }
}
