using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSFinalProject
{
    public partial class GalaxyWindow : Form
    {
        Galaxy _galaxy;
        DateAndTime _date;
        double _presist;
        public GalaxyWindow(Galaxy galaxy, DateAndTime date)
        {
            _date = date;
            _galaxy = galaxy;
            _presist = 1;
            InitializeComponent();
            comboBox1.Items.Add("4*X");
            comboBox1.Items.Add("3*X");
            comboBox1.Items.Add("2*X");
            comboBox1.Items.Add("X");
            comboBox1.Items.Add("0.5*X");
            comboBox1.Items.Add("0.3*X");
            comboBox1.Items.Add("0.2*X");
            comboBox1.Items.Add("0.15*X");
            comboBox1.Items.Add("0.1*X");
            comboBox1.Items.Add("0.05*X");
            comboBox1.Text = "X";
        }

        private void BindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void GalaxyWindow_Load(object sender, EventArgs e)
        {
             
            this.Invalidate();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            //Screen 1920x1080
            // 1 pixel = 10^20 km
            int xCenter = 1920 / 2;
            int yCenter = 1080 / 2;
            base.OnPaint(e);
            Graphics g = e.Graphics;

            Brush aBrushBlack = (Brush)Brushes.Black; // Center of map && Text
            Brush aBrushDarckBlue = (Brush)Brushes.DarkBlue; // Center of galaxy
            Brush aBrushGreen = (Brush)Brushes.Green; //Coordinates of Sollar Systems

            FontFamily fontFamily = new FontFamily("Arial");
            Font font = new Font(
                                fontFamily,
                                16,
                                FontStyle.Regular,
                                GraphicsUnit.Pixel);

            Pen redPen = new Pen(Color.Red, 1);  // map's circles
            Pen bluePen = new Pen(Color.Blue, 2);
            Pen greenPen = new Pen(Color.Green, 3); //Coordinates of Sollar Systems
            Pen blackPen = new Pen(Color.Black, 4);

            g.DrawString($"Date: {_date.ToString()}",font, aBrushBlack, 1720, 20);
            g.FillRectangle(aBrushBlack, xCenter, yCenter, 2, 2); // Drawing center of map 

            //Drawing Circles 
            for(int i = 0; i < 1920/2; i += 10)
            {
                Rectangle r = new Rectangle(xCenter - i, yCenter - i, 2*i, 2*i);
                g.DrawEllipse(redPen, r);
            }
            //Drawing coordinates of Galaxy
            g.FillRectangle(aBrushDarckBlue,   xCenter, yCenter, 4, 4);
            g.DrawString($"Center of Galxy : {0} {0}", font, aBrushBlack,
                                                xCenter,  yCenter);
            //Drawing Solar Systems in Galaxy
            foreach (var solar in _galaxy.SolarSystems)
            {
                float X_solar = (float)solar.Coordinates.Item1  ;
                float Y_solar = -(float)solar.Coordinates.Item2 ;
                g.FillRectangle(aBrushGreen, (float)(X_solar* _presist) + xCenter, yCenter + (float)(Y_solar* _presist), 10, 10);
                g.DrawString($"{solar.Name} : {(float)(solar.Coordinates.Item1* _presist)} {(float)(solar.Coordinates.Item2* _presist)}", font, aBrushBlack,
                                              (float)(X_solar* _presist) + xCenter, yCenter +(float)( Y_solar * _presist));
                //Drawing Lines of Solar system way
                float x1 = (float)(X_solar* _presist);
                float y1 = (float)(-Y_solar * _presist);
                float x2 = (float)(solar.Vector.Item1* _presist) + (float)(X_solar * _presist);
                float y2 = (float)(solar.Vector.Item2* _presist) - (float)(Y_solar * _presist);
                float xNew1 = -xCenter;
                float xNew2 = xCenter;
                float yNew1 = y1 + ((y2 - y1) / (x2 - x1)) * (xNew1 - x1);
                float yNew2 = y1 + ((y2 - y1) / (x2 - x1)) * (xNew2 - x1);
                PointF[] points = new PointF[2];
                points[0] = new PointF(xNew1 + xCenter,yCenter - yNew1);
                points[1] = new PointF(xNew2 + xCenter,yCenter - yNew2);
                g.DrawCurve(blackPen, points);
            }





        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            _date.AddYears(_galaxy,1);
            this.Invalidate();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            _date.SubtractYears(_galaxy, 1);
            this.Invalidate();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            _date.AddMonths(_galaxy, 1);
            this.Invalidate();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            _date.SubtractMonths(_galaxy, 1);
            this.Invalidate();
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            _date.AddDays(_galaxy, 1);
            this.Invalidate();
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            _date.SubtractDays(_galaxy, 1);
            this.Invalidate();
        }

        private void Button16_Click(object sender, EventArgs e)
        {
            _date.AddYears(_galaxy, 1);
            this.Invalidate();
        }

        private void Button9_Click(object sender, EventArgs e)
        {
            _date.AddYears(_galaxy, 10);
            this.Invalidate();
        }

        private void Button10_Click(object sender, EventArgs e)
        {
            _date.AddYears(_galaxy, 100);
            this.Invalidate();
        }

        private void Button15_Click(object sender, EventArgs e)
        {
            _date.SubtractYears(_galaxy, 1);
            this.Invalidate();
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            _date.SubtractYears(_galaxy, 10);
            this.Invalidate();
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            _date.SubtractYears(_galaxy, 100);
            this.Invalidate();
        }

        private void Button14_Click(object sender, EventArgs e)
        {
            _date.AddMonths(_galaxy, 1);
            this.Invalidate();
        }

        private void Button13_Click(object sender, EventArgs e)
        {
            _date.SubtractMonths(_galaxy, 1);
            this.Invalidate();
        }

        private void Button12_Click(object sender, EventArgs e)
        {
            _date.AddDays(_galaxy, 1);
            this.Invalidate();
        }

        private void Button11_Click(object sender, EventArgs e)
        {
            _date.SubtractDays(_galaxy, 1);
            this.Invalidate();
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Button1_Click_1(object sender, EventArgs e)
        {
            switch (comboBox1.Text)
            {
                case "4*X":
                    _presist = 4;
                    break;
                case "3*X":
                    _presist = 3;
                    break;
                case "2*X":
                    _presist = 2;
                    break;
                case "X":
                    _presist = 1;
                    break;
                case "0.5*X":
                    _presist = 0.5;
                    break;
                case "0.3*X":
                    _presist = 0.3;
                    break;
                case "0.2*X":
                    _presist = 0.2;
                    break;
                case "0.15*X":
                    _presist = 0.15;
                    break;
                case "0.1*X":
                    _presist = 0.1;
                    break;
                case "0.05*X":
                    _presist = 0.05;
                    break;
                default:
                    throw new System.Exception("Class SollarSystemWindow, button Refresh: out of the range");

            }
            this.Invalidate();
        }
    }
}
