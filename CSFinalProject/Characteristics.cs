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
    public partial class Characteristics : Form
    {
        SolarSystem _solarSys;
        Galaxy _galaxy;
        DataTable dt ;
        public Characteristics(Galaxy gal,SolarSystem solar)
        {
            try
            {
                _solarSys = solar;
                _galaxy = gal;
                InitializeComponent();
                //Printting Sun
                textBox1.Text = _solarSys.Name;
                textBox3.Text = "Milky Way";
                textBox2.Text = _solarSys.SunProp.Name;
                textBox4.Text = _solarSys.SunProp.Color;
                textBox5.Text = Convert.ToString(_solarSys.SunProp.Mass);
                textBox6.Text = Convert.ToString(_solarSys.SunProp.Tempertura);
                textBox7.Text = Convert.ToString(_solarSys.SunProp.Luminiosity);
                comboBox1.Items.Add("Sort by name");
                comboBox1.Items.Add("Sort by distanse from Sun");
                comboBox1.Items.Add("Sort by amount of moons");
            }
            catch (Exception e)
            {
                throw new System.Exception($"Class {this.GetType().Name}, method {System.Reflection.MethodBase.GetCurrentMethod().Name}" + e.Message);

            }
        }

        private void Characteristics_Load(object sender, EventArgs e)
        {
            
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Label13_Click(object sender, EventArgs e)
        {

        }


        private void DataGridView1_CellContentClick_2(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void PrintDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {

            dt = new DataTable();
            dt.Columns.Add("Planet Name", typeof(string));
            dt.Columns.Add("Coord", typeof(Tuple<double, double>));
            dt.Columns.Add("Mass", typeof(double));
            dt.Columns.Add("Diametr", typeof(double));
            dt.Columns.Add("EllipsA", typeof(double));
            dt.Columns.Add("EllipsB", typeof(double));
            dt.Columns.Add("OrbitalPeri", typeof(double));
            dt.Columns.Add("Speed", typeof(double));
            dt.Columns.Add("Months", typeof(int));
            // dt.Rows.Add(dc1); dc1 is a column not a row   >>>
            // DataRow dr = dt.NewRow();  not necessary
            dataGridView1.DataSource = dt;

            Context context;
            //Strategy Using
            if(comboBox1.Text == "Sort by name")
            {
                context = new Context(new NameStrategy());
                context.ContextInterface(dt,_solarSys);
            } else if (comboBox1.Text == "Sort by distanse from Sun")
            {
                context = new Context(new DistanceStrategy());
                context.ContextInterface(dt,_solarSys);
            }
            else if (comboBox1.Text == "Sort by amount of moons")
            {
                context = new Context(new MoonsStrategy());
                context.ContextInterface(dt,_solarSys);
            }
            else
            {
                MessageBox.Show($"Class {this.GetType().Name}, method {System.Reflection.MethodBase.GetCurrentMethod().Name}");
            }
   
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            var newWindow = new AddItem(_galaxy, _solarSys);
            newWindow.Show();
        }

        private void TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
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

        private void TextBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
