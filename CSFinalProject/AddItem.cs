using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace CSFinalProject
{
    public partial class AddItem : Form
    {
        SolarSystem _solarSystem;
        Galaxy _galaxy;
        PlanetSystem _planetSys;
        Planet _planet;
        Moon _moon;
        public AddItem(Galaxy gal, SolarSystem sol)
        {
            
            _solarSystem = sol;
            _galaxy = gal;
            InitializeComponent();
            textBox19.Text = sol.Name;
            textBox19.ReadOnly = true;
        }

        private void Label13_Click(object sender, EventArgs e)
        {

        }


        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void TextBox19_TextChanged(object sender, EventArgs e)
        {

            
        }

        private void TextBox3_TextChanged(object sender, EventArgs e)
        {
            
            
        }

        private void TextBox4_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void TextBox5_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void TextBox6_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void AddItem_Load(object sender, EventArgs e)
        {

        }

        private void TextBox7_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void TextBox8_TextChanged(object sender, EventArgs e)
        {
        }

        private void TextBox9_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void IsMoon_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void TextBox15_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void TextBox14_TextChanged_1(object sender, EventArgs e)
        {
        
        }

        private void TextBox13_TextChanged_1(object sender, EventArgs e)
        {
            
        }

        private void TextBox12_TextChanged_1(object sender, EventArgs e)
        {
            
        }

        private void TextBox11_TextChanged_1(object sender, EventArgs e)
        {
            
        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {
        }

        private void Button1_Click(object sender, EventArgs e)
        {

            _planet = new Planet();
            _planet.Name = textBox1.Text;
            _planet.Coordinates = new Tuple<double, double>(Convert.ToDouble(textBox3.Text.Split('-')[0]),
                                                             Convert.ToDouble(textBox3.Text.Split('-')[1]));
            _planet.Mass = Convert.ToDouble(textBox4.Text);
            _planet.Diametr = Convert.ToDouble(textBox5.Text);
            _planet.ELlipseParamA = Convert.ToDouble(textBox6.Text);
            _planet.ELlipseParamB = Convert.ToDouble(textBox7.Text);
            _planet.OrbitalPeriod = Convert.ToDouble(textBox8.Text);
            _planet.Speed = Convert.ToDouble(textBox9.Text);


            if (IsMoon.Checked == true)
            {
                _moon = new Moon();
                _moon.Coordinates = new Tuple<double, double>(Convert.ToDouble(textBox15.Text.Split('-')[0]),
                                                             Convert.ToDouble(textBox15.Text.Split('-')[1]));
                _moon.Mass = Convert.ToDouble(textBox14.Text);
                _moon.Diametr = Convert.ToDouble(textBox13.Text);
                _moon.EllipseA = Convert.ToDouble(textBox12.Text);
                _moon.EllipseB = Convert.ToDouble(textBox11.Text);
                _moon.Speed = Convert.ToDouble(textBox2.Text);

                _planetSys = new PlanetSystem(_planet, new List<Moon>() { _moon });
            }
            else
            {
                _planetSys = new PlanetSystem(_planet);
            }
            _solarSystem.Planets.Add(_planetSys);
            Application.Exit();
        }

        private void BackgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }


    }
}
