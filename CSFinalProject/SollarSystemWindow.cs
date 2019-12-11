using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSFinalProject
{
    public partial class SollarSystemWindow : Form
    {
        Galaxy _galaxy;
        SolarSystem _solarSys;
        DateAndTime _date;
        double _presist;
        bool _coord;
        private PictureBox pictureBox1 = new PictureBox();
        private PictureBox pictureBox2 = new PictureBox();
        public SollarSystemWindow(Galaxy galaxy,SolarSystem solar, DateAndTime date)
        {
            _galaxy = galaxy;
            _date = date;
            _solarSys = solar;
            _presist = 1;
            _coord = false;
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

            comboBox2.Items.Add("29");
            comboBox2.Items.Add("23");
            comboBox2.Items.Add("19");
            comboBox2.Items.Add("17");
            comboBox2.Items.Add("13");
            comboBox2.Items.Add("11");
            comboBox2.Items.Add("7");
            comboBox2.Items.Add("5");
            comboBox2.Items.Add("3");
            comboBox2.Items.Add("2");
            comboBox2.Items.Add("1");
            comboBox2.Text = "1";
        }

        private void SollarSystemWindow_Load(object sender, EventArgs e)
        {
            /*  pictureBox1.Dock = DockStyle.Fill;
               pictureBox1.BackColor = Color.White;
               // Connect the Paint event of the PictureBox to the event handler method.
               pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
               pictureBox2.Dock = DockStyle.Fill;
               pictureBox2.BackColor = Color.White;
               // Connect the Paint event of the PictureBox to the event handler method.
               pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox2_Paint);

               this.Controls.Add(pictureBox1);*/
            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.Invalidate();


        }
        //Draw fone
        /*      private void pictureBox1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
              {
                  base.OnPaint(e);
                  //Screen 1920x1080
                  // 1 pixel = 10^6 km
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
                  //Drawing Circles 
                  for (int i = 0; i < 1920 / 2; i += 10)
                  {
                      Rectangle r = new Rectangle(xCenter - i, yCenter - i, 2 * i, 2 * i);
                      g.DrawEllipse(redPen, r);
                  }

              }
              //Draw coordinates of planets
              private void pictureBox2_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
              {

                  //Screen 1920x1080
                  // 1 pixel = 10^6 km
                  int xCenter = 1920 / 2;
                  int yCenter = 1080 / 2;
                  base.OnPaint(e);
                  Graphics g = pictureBox1.CreateGraphics();
                  #region Pens
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
                  #endregion 
                  g.DrawString($"Date: {_date.ToString()}", font, aBrushBlack, 1720, 20);
                  g.FillRectangle(aBrushBlack, xCenter, yCenter, 2, 2); // Drawing center of map 

                  //Drawing Elipses of Planets
                  foreach (var pl in _solarSys.Planets)
                  {
                      Rectangle r = new Rectangle(xCenter - (int)(pl.ELlipseParamA * _presist), yCenter - (int)(pl.ELlipseParamB * _presist),
                                              2 * (int)(pl.ELlipseParamA * _presist), 2 * (int)(pl.ELlipseParamB * _presist));
                      g.DrawEllipse(bluePen, r);
                  }
                  //Drawing coordinates of SUN
                  g.FillRectangle(aBrushDarckBlue, (float)(_solarSys.SunProp.Coordinates.Item1 * _presist) + xCenter,
                                  yCenter - (float)(_solarSys.SunProp.Coordinates.Item2 * _presist), 5, 5);
                  g.DrawString($"{_solarSys.SunProp.Name} : {0} {0}", font, aBrushBlack, xCenter, yCenter);

                  //Drawing Planets in Solar System
                  foreach (var planet in _solarSys.Planets)
                  {
                      g.FillRectangle(aBrushGreen, (float)(planet.Coordinates.Item1 * _presist) + xCenter, -(float)(planet.Coordinates.Item2 * _presist) + yCenter, 10, 10);
                      g.DrawString($"{planet.Planet.Name} : {(float)(planet.Coordinates.Item1 * _presist)} {(float)(planet.Coordinates.Item2 * _presist)}", font, aBrushBlack,
                                                    (float)(planet.Coordinates.Item1 * _presist) + xCenter, -(float)(planet.Coordinates.Item2 * _presist) + yCenter);

                  }

              }*/

        protected override void OnPaint(PaintEventArgs e)
        {
            //Screen 1920x1080
            // 1 pixel = 10^6 km
            int xCenter = 1920 / 2;
            int yCenter = 1080 / 2;
            base.OnPaint(e);
            Graphics g = e.Graphics;
            #region Pens
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
            #endregion 
            g.DrawString($"Date: {_date.ToString()}", font, aBrushBlack, 1720, 20);
            g.FillRectangle(aBrushBlack, xCenter, yCenter, 2, 2); // Drawing center of map 

            //Drawing Circles 
            Thread[] threads = new Thread[192 / 2];
            int count = 0; ;
            for (int i = 0; i < 1920 / 2; i += 10)
            {
                Rectangle r = new Rectangle((int)xCenter - (int)i, (int)yCenter - (int)i, (int)2 * (int)i, (int)2 * (int)i);
                Rectangle n_r = r;
               /* threads[count] = new Thread(() =>*/g.DrawEllipse(redPen, n_r);
               // threads[count++].Start();

            }
            foreach(var x in threads)
            {
          //      x.Join();
            }
            
            //Drawing Elipses of Planets
            foreach (var pl in _solarSys.Planets)
            {
                Rectangle r = new Rectangle(xCenter - (int)(pl.ELlipseParamA * _presist), yCenter - (int)(pl.ELlipseParamB * _presist),
                                        2 * (int)(pl.ELlipseParamA * _presist), 2 * (int)(pl.ELlipseParamB * _presist));
                g.DrawEllipse(bluePen, r);
            }
            //Drawing coordinates of SUN
            g.FillRectangle(aBrushDarckBlue, (float)(_solarSys.SunProp.Coordinates.Item1 * _presist) + xCenter,
                            yCenter - (float)(_solarSys.SunProp.Coordinates.Item2 * _presist), 5, 5);
            g.DrawString($"{_solarSys.SunProp.Name} : {0} {0}", font, aBrushBlack, xCenter, yCenter);


            //Drawing Planets in Solar System
            foreach (var planet in _solarSys.Planets)
            {
                g.FillRectangle(aBrushGreen, (float)(planet.Coordinates.Item1 * _presist) + xCenter, -(float)(planet.Coordinates.Item2 * _presist) + yCenter, 10, 10);
                g.DrawString($"{planet.Planet.Name} : {(float)(planet.Coordinates.Item1 * _presist)} {(float)(planet.Coordinates.Item2 * _presist)}", font, aBrushBlack,
                                              (float)(planet.Coordinates.Item1 * _presist) + xCenter, -(float)(planet.Coordinates.Item2 * _presist) + yCenter);

            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            _date.AddYears(_galaxy, 1);
            this.Invalidate();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            _date.SubtractYears(_galaxy, 1);
            this.Invalidate();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            _date.AddMonths(_galaxy, 1);
            this.Invalidate();
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            _date.SubtractMonths(_galaxy, 1);
            this.Invalidate();
        }

        private void Button6_Click(object sender, EventArgs e)
        {
           
            _date.AddDays(_galaxy, 1);
            this.Invalidate();

        }

        private void Button7_Click(object sender, EventArgs e)
        {
            _date.SubtractDays(_galaxy, 1);
            this.Invalidate();
        }

        private void Button10_Click(object sender, EventArgs e)
        {
            _date.AddYears(_galaxy, 100);
            this.Invalidate();
        }

        private void Button9_Click(object sender, EventArgs e)
        {
            _date.AddYears(_galaxy,10);
            this.Invalidate();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            _date.SubtractYears(_galaxy, 10);
            this.Invalidate();
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            _date.SubtractYears(_galaxy, 100);
            this.Invalidate();
        }

        private void Button11_Click(object sender, EventArgs e)
        {

            var newWindow = new Characteristics(_galaxy,_solarSys);
            newWindow.Show();
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Button12_Click(object sender, EventArgs e)
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

        private void Button13_Click(object sender, EventArgs e)
        {
            int days = Convert.ToInt32(comboBox2.Text);
            //Performe animation
            for (int i = 0; i < days; i++)
            {
               /* Thread t = new Thread(() => _date.AddDays(_galaxy, 1));
                t.Start();
                Thread.Sleep(1000);
                t.Join();*/
                this.Invalidate();

            }
        }
    }
}
